Imports Microsoft.VisualBasic

<Serializable()> _
Public Class PlayerMatchList
	Inherits CSLA.ReadOnlyCollectionBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerMatchList).ToString())

    Private Const PlayerPointOfViewID As Integer = 1

#Region "Business Properties and Methods"
	Default Public ReadOnly Property item(ByVal index As Integer) As PlayerMatch
		Get
			Return CType(List.Item(index), PlayerMatch)
		End Get
	End Property
#End Region

#Region "Contains"
	Public Overloads Function Contains(ByVal item As PlayerMatch) As Boolean
		For Each child As PlayerMatch In List
			If child.Equals(item) Then
				Return True
			End If
		Next
		Return False
    End Function

    Public Function IndexOf(ByVal ID As Integer) As Integer
        For i As Integer = 0 To Count - 1
            If Me(i).ID = ID Then
                Return i
            End If
        Next
        Return -1
    End Function
#End Region

#Region "Shared Methods"
	Public Shared Function GetPlayerMatchList() As PlayerMatchList
        Return DirectCast(DataPortal.Fetch(New Criteria()), PlayerMatchList)
    End Function

    Public Shared Function SelectRecentMatches(ByVal source As PlayerMatchList, ByVal count As Integer) As PlayerMatchList
        Dim target As New PlayerMatchList()
        For i As Integer = source.Count - count To source.Count - 1
            target.InnerList.Add(source.InnerList(i))
        Next
        Return target
    End Function

    Public Shared Function SelectRecentMatches(ByVal source As PlayerMatchList, ByVal count As Integer, ByVal dateInterval As DateInterval) As PlayerMatchList
        Dim target As New PlayerMatchList()
        For Each match As PlayerMatch In source
            If match.MatchDate.Date > DateAdd(dateInterval, -count, Date.Today) Then
                target.InnerList.Add(match)
            End If
        Next
        Return target
    End Function

    Public Shared Function SelectMatchesByEvent(ByVal source As PlayerMatchList, ByVal eventID As Integer) As PlayerMatchList
        Dim target As New PlayerMatchList()
        For Each match As PlayerMatch In source
            If match.EventID = eventID Then
                target.InnerList.Add(match)
            End If
        Next
        Return target
    End Function

    Public Shared Function SelectMatchesByOpponent(ByVal source As PlayerMatchList, ByVal opponentID As Integer) As PlayerMatchList
        Dim target As New PlayerMatchList()
        For Each match As PlayerMatch In source
            If match.OpponentID = opponentID Then
                target.InnerList.Add(match)
            End If
        Next
        Return target
    End Function

#End Region

#Region "Constructors"
    Private Sub New()
        AllowSort = True
        AddHandlers()
    End Sub

    Private Sub AddHandlers()
        AddHandler Match.Created, AddressOf NewMatch
        AddHandler Match.Updated, AddressOf UpdatedMatch
        AddHandler Match.Deleted, AddressOf DeletedMatch
    End Sub

    Protected Overrides Sub Deserialized()
        MyBase.Deserialized()
        'when an object is deserialized, such as happens with the Clone method, 
        'the event handlers need to be re-hooked
        AddHandlers()
    End Sub

    ''' <summary>
    ''' Whenever a new event is created, automatically add it to the list.
    ''' </summary>
    ''' <param name="Match"></param>
    ''' <remarks></remarks>
    Private Sub NewMatch(ByVal Match As Match)
        Dim i As Integer = Me.InnerList.Add(PlayerMatch.Copy(Match, PlayerPointOfViewID))
        MyBase.OnInsertComplete(i, Me.InnerList(i))
    End Sub

    Private Sub UpdatedMatch(ByVal Match As Match)
        Dim i As Integer = IndexOf(Match.ID)
        If i >= 0 Then
            Dim OldMatch As PlayerMatch = Me(i)
            Locked = False
            List(i) = PlayerMatch.Copy(Match, PlayerPointOfViewID)
            Locked = True
            MyBase.OnSetComplete(i, OldMatch, Match)
        End If
    End Sub

    Private Sub DeletedMatch(ByVal ID As Integer)
        'Dim BindingList As System.ComponentModel.IBindingList = Me
        'Dim i As Integer = BindingList.Find("ID", ID)
        Dim i As Integer = IndexOf(ID)
        If i = -1 Then Return
        Locked = False
        RemoveAt(i)
        Locked = True
    End Sub
#End Region

#Region "Criteria"
	<Serializable()> _
	Private Class Criteria
		Public Sub New()
		End Sub
	End Class
#End Region

#Region "Data Access"
	Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
		Locked = False
		Dim crit As Criteria = CType(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_matchlist_personal", PlayerPointOfViewID))
        Try
            While dr.Read()
                List.Add(PlayerMatch.Fetch(dr))
            End While
        Finally
            dr.Close()
        End Try
    End Sub
#End Region

End Class
