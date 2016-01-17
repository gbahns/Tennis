<Serializable()> _
Public Class PlayerMatch
    Inherits ReadOnlyBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerMatch).ToString())

#Region "Private Data"
    Private _ID As Int32
    Private _MatchDate As New SmartDate
    Private _EventID As Int32
    Private _EventName As String = ""
    Private _ClassID As Int32
    Private _ClassName As String = ""
    Private _Result As String = ""
    Private _OpponentID As Int32
    Private _OpponentName As String = ""
    Private _Score As New MatchScore
#End Region

#Region "Business Properties and Methods"
	''' <summary>
	''' Unique identifier in the database table for this match.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property ID() As Int32
		Get
			Return _ID
		End Get
	End Property

	''' <summary>
	''' Date that this match was played.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MatchDate() As SmartDate
		Get
			Return _MatchDate
		End Get
		Set(ByVal value As SmartDate)
			_MatchDate = value
		End Set
	End Property

	''' <summary>
	''' Date that this match was played.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property MatchDateAsDate() As Date
		Get
			Return _MatchDate.Date
		End Get
		Set(ByVal value As Date)
			_MatchDate.Date = value
		End Set
	End Property

	'Public Property Sets() As MatchScore.MatchSet()
	'	Get
	'		Return _Sets
	'	End Get
	'	Set(ByVal value As MatchScore.MatchSet())
	'		_Sets = value
	'	End Set
	'End Property

	'Public Property LoserDefaulted() As Boolean
	'	Get
	'		Return _LoserDefaulted
	'	End Get
	'	Set(ByVal value As Boolean)
	'		_LoserDefaulted = value
	'	End Set
	'End Property

    Public ReadOnly Property EventID() As Int32
        Get
            Return _EventID
        End Get
    End Property

    Public ReadOnly Property EventName() As String
        Get
            Return _EventName
        End Get
    End Property

    Public ReadOnly Property ClassID() As Int32
        Get
            Return _ClassID
        End Get
    End Property

    Public ReadOnly Property ClassName() As String
        Get
            Return _ClassName
        End Get
    End Property

	''' <summary>
	''' Returns W or L to indicate whether the player won or lost the match.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property Result() As String
		Get
			Return _Result
		End Get
	End Property

	''' <summary>
	''' Unique identifier in the database table for the opponent played in this match.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property OpponentID() As Int32
		Get
			Return _OpponentID
		End Get
	End Property


	''' <summary>
	''' Name of the opponent played in this match.
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property OpponentName() As String
		Get
			Return _OpponentName
		End Get
	End Property

	''' <summary>
	''' Return a string showing the score for the match, e.g. "6-4 3-6 7-6"
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property Score() As String
		Get
			Return _Score.ToString()
		End Get
	End Property

	''' <summary>
	''' Return a string showing the score for the match, beginning with a W or L to indicate
	''' whether the player won or lost, e.g. "W 6-4 3-6 7-6"
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property ResultScore() As String
		Get
			Return Result & " " & Score
		End Get
	End Property
#End Region

#Region "System.Object Overrides"
    Public Overrides Function ToString() As String
        'todo: implement ToString()
        'Return String.Format("{0}", ID)
        Return ""
    End Function

    Public Overloads Function Equals(ByVal A As PlayerMatch) As Boolean
        'todo: implement Equals
        'Return _ID = A._ID
        Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
        'todo: implement GetHashCode()
        'Return _ID.GetHashCode()
        Return MyBase.GetHashCode()
    End Function
#End Region

#Region "Shared Methods"
    Public Shared Function Fetch(ByVal dr As SafeDataReader) As PlayerMatch
        Return New PlayerMatch(dr)
    End Function

    Public Shared Function Copy(ByVal Match As Match, ByVal PlayerID As Integer) As PlayerMatch
        Return New PlayerMatch(Match, PlayerID)
    End Function
#End Region

#Region "Constructors"
    Private Sub New()
    End Sub

    Private Sub New(ByVal dr As SafeDataReader)
        _Fetch(dr)
    End Sub

    Private Sub New(ByVal Match As Match, ByVal PlayerID As Integer)
        _ID = Match.ID
        _MatchDate.Text = Match.MatchDate

        Dim TennisEvent As TennisEvent = Match.Events.Find(Match.EventID)
        _EventID = TennisEvent.ID
        _EventName = TennisEvent.Name
        _ClassID = TennisEvent.ClassificationID
        _ClassName = ""

        _Result = IIf(PlayerID = Match.WinnerID, "W", "L")
        _OpponentID = IIf(PlayerID = Match.WinnerID, Match.LoserID, Match.WinnerID)
        _OpponentName = Match.Winners.Find(_OpponentID).FullName
        _Score = Match.Score
    End Sub
#End Region

#Region "Data Access"
    Private Sub _Fetch(ByVal dr As SafeDataReader)
        _ID = dr.GetInt32
        _MatchDate = dr.GetSmartDate
        _EventID = dr.GetInt32
        _EventName = dr.GetString
        _ClassID = dr.GetInt32
        _ClassName = dr.GetString
        _Result = dr.GetString
        _OpponentID = dr.GetInt32
        _OpponentName = dr.GetString
        _Score.Fetch(dr)
    End Sub
#End Region

End Class
