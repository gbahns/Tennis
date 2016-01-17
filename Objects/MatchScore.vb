Imports System.Math

<Serializable()> _
Public Class MatchScore
	Inherits BusinessBase

	Private Shared log As ILog = LogManager.GetLogger(GetType(MatchScore).ToString())

	''' <summary>
	''' MatchSet represents a single set from a match score.
	''' </summary>
	''' <remarks>
	''' MatchSet can be used to represent a match score in one of two ways: objectively and subjectively.
	''' 
	''' When used objectively, WGames and LGames represent the number of games won by the winner and loser, 
	''' respectively.  In this case, WGames is interpreted as "winner games won" (games won in this set by
	''' the winner of the match), and LGames is "loser games won".
	''' 
	''' When used subjectively, WGames and LGames represent the number of games won and lost
	''' by a specific player.   In this case, WGames and LGames are interpreted as "games won and lost by the
	''' player the player whose record is being retrieved".
	''' 
	''' MatchSet does not know which way it is being used, as it does not contain any information about the
	''' players.  It is up to the parent class to know which way it is using MatchSet.
	''' 
	''' Note that WGames and LGames are named with just 'W' and 'L' in order
	''' </remarks>
	<Serializable()> _
	Public Class MatchSet
		Inherits BusinessBase
		Private _WGames As Byte
		Private _LGames As Byte
		Private _WTiebreak As Byte
        Private _LTiebreak As Byte
        Private _SetNumber As Integer

        Friend Sub New(ByVal setNumber As Integer)
            _SetNumber = setNumber
        End Sub

        'if the tiebreak was played, the winner of the tiebreak must also be the winner of the set
        'todo: this rule is not true if the loser defaulted the match during the tiebreak
        'in this case the game score would be tied, and the tiebreak score could be anything
        Private Function IsScoreValid() As Boolean
            If TiebreakPlayed AndAlso _WGames <> _LGames Then
                Return Sign(_WGames.CompareTo(_LGames)) = Sign(_WTiebreak.CompareTo(_LTiebreak))
            End If
            Return True
        End Function

        Private Sub ValidateScore()
            'BrokenRules.Assert(propertyName & "_Score", "Score must be valid", propertyName, Not IsScoreValid())
            BrokenRules.Assert("Set" & _SetNumber & "_Score", String.Format("Set {0} winner must have also won the tiebreak", _SetNumber), "LTiebreak", Not IsScoreValid())
        End Sub

        Public Property WGames() As Byte
            Get
                Return _WGames
            End Get
            Set(ByVal value As Byte)
                If _WGames = value Then Return
                _WGames = value
                MarkDirty()
                ValidateProperty("WGames", _WGames)
                ValidateScore()
            End Set
        End Property
        Public Property LGames() As Byte
            Get
                Return _LGames
            End Get
            Set(ByVal value As Byte)
                If _LGames = value Then Return
                _LGames = value
                MarkDirty()
                ValidateProperty("LGames", _LGames)
                ValidateScore()
            End Set
        End Property
        Public Property WTiebreak() As Byte
            Get
                Return _WTiebreak
            End Get
            Set(ByVal value As Byte)
                If _WTiebreak = value Then Return
                _WTiebreak = value
                MarkDirty()
                ValidateProperty("WTiebreak", _WTiebreak)
                ValidateScore()
            End Set
        End Property
        Public Property LTiebreak() As Byte
            Get
                Return _LTiebreak
            End Get
            Set(ByVal value As Byte)
                If _LTiebreak = value Then Return
                _LTiebreak = value
                MarkDirty()
                ValidateProperty("LTiebreak", _LTiebreak)
                ValidateScore()
            End Set
        End Property

        Public ReadOnly Property SetPlayed() As Boolean
            Get
                Return WGames > 0 Or LGames > 0
            End Get
        End Property
        Public ReadOnly Property TiebreakPlayed() As Boolean
            Get
                Return WTiebreak > 0 Or LTiebreak > 0
            End Get
        End Property
        Public Overrides Function ToString() As String
            Return ToString(False)
        End Function
        Public Overloads Function ToString(ByVal IncludeTiebreaks As Boolean) As String
            If Not SetPlayed Then
                Return ""
            ElseIf TiebreakPlayed And IncludeTiebreaks Then
                Return String.Format("{0}-{1} ({2}-{3})", WGames, LGames, WTiebreak, LTiebreak)
            Else
                Return String.Format("{0}-{1}", WGames, LGames)
            End If
        End Function

        Friend Sub Fetch(ByVal dr As SafeDataReader)
            WGames = dr.GetByte
            LGames = dr.GetByte
            WTiebreak = dr.GetByte
            LTiebreak = dr.GetByte
            MarkOld()
        End Sub

        'Public Overrides ReadOnly Property IsValid() As Boolean
        '	Get
        '		If Not MyBase.IsValid Then Return False
        '              'If TiebreakPlayed AndAlso _WGames <> _LGames Then
        '              '	Return _WGames.CompareTo(_LGames) <> _WTiebreak.CompareTo(_LTiebreak)
        '              'End If
        '              'Return True
        '	End Get
        'End Property
    End Class

#Region "Private Data"
	Private _Sets(4) As MatchSet
	Private _LoserDefaulted As Boolean
#End Region

#Region "Business Properties and Methods"
	''' <summary>
	''' Returns the specified MatchSet object for the match (0-based).
	''' </summary>
	''' <param name="index">0-based index of the set</param>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property Sets(ByVal index As Integer) As MatchSet
		Get
			Return _Sets(index)
		End Get
	End Property

	''' <summary>
	''' Returns 0-based array of MatchSets for the match.
	''' This version is for C# compatibility (the Sets property is not
	''' available in C#).
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property MatchSets() As MatchSet()
		Get
			Return _Sets
		End Get
	End Property

	Public ReadOnly Property ShowSet(ByVal index As Integer) As Boolean
		Get
			Return index = 0 OrElse _Sets(index - 1).SetPlayed
		End Get
	End Property

	Public Property LoserDefaulted() As Boolean
		Get
			Return _LoserDefaulted
		End Get
		Set(ByVal value As Boolean)
			If _LoserDefaulted = value Then Return
			_LoserDefaulted = value
			MarkDirty()
			'ValidateProperty("LoserDefaulted", _LoserDefaulted)
		End Set
	End Property

	Public ReadOnly Property WSets() As Int32
		Get
			Dim n As Int32 = 0
			For i As Integer = 0 To 4
				If _Sets(i).WGames > _Sets(i).LGames Then n += 1
			Next
			Return n
		End Get
	End Property

	Public ReadOnly Property LSets() As Int32
		Get
			Dim n As Int32 = 0
			For i As Integer = 0 To 4
				If _Sets(i).LGames > _Sets(i).WGames Then n += 1
			Next
			Return n
		End Get
	End Property

#End Region

#Region " IsValid and IsDirty "
	Public Overrides ReadOnly Property IsValid() As Boolean
		Get
            If Not MyBase.IsValid Then Return False
			For i As Integer = 0 To 4
				If Not _Sets(i).IsValid Then Return False
			Next

			'if loser defaulted, no extra validation is needed
			If _LoserDefaulted Then Return True

			'otherwise check validity of match score
			'winner must have won more sets that loser
			If WSets <= LSets Then Return False

			Return True
		End Get
	End Property

	Public Overrides ReadOnly Property IsDirty() As Boolean
		Get
			If MyBase.IsDirty Then Return True
			For i As Integer = 0 To 4
				If _Sets(i).IsDirty Then Return True
			Next
		End Get
	End Property

    'Sub Set_IsDirtyChanged(ByVal sender As Object, ByVal e As EventArgs)
    '	Me.OnIsDirtyChanged()
    'End Sub
#End Region

#Region "System.Object Overrides"
	Public Overrides Function ToString() As String
		Return ToString(False)
	End Function

	Public Overloads Function ToString(ByVal IncludeTiebreaks As Boolean) As String
		Dim s As New System.Text.StringBuilder
		For i As Integer = 0 To 4
			s.Append(_Sets(i).ToString(IncludeTiebreaks))
			s.Append(" ")
		Next
		Return s.ToString.Trim()
	End Function

	Public Overloads Function Equals(ByVal A As MatchScore) As Boolean
		Return MyBase.Equals(A)
	End Function

	Public Overrides Function GetHashCode() As Integer
		Return MyBase.GetHashCode()
	End Function
#End Region

#Region "Constructors"
	Friend Sub New()
		'Prevent direction creation
		MarkAsChild()
		For i As Int16 = 0 To 4
            _Sets(i) = New MatchSet(i + 1)
            AddHandler _Sets(i).IsDirtyChanged, AddressOf Child_IsDirtyChanged
		Next
	End Sub
#End Region

#Region "Data Access"
	Friend Sub Fetch(ByVal dr As SafeDataReader)
		For i As Integer = 0 To 4
			_Sets(i).Fetch(dr)
		Next
		_LoserDefaulted = dr.GetBoolean
		MarkOld()
		LoadRules()
	End Sub
#End Region

End Class
