Imports CSLA.Data

<Serializable()> _
Public Class EventList
    Inherits Csla.ReadOnlyCollectionBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(EventList).ToString())

    ''' <summary>
    ''' Cached list of events from database.
    ''' </summary>
    ''' <remarks>
    ''' When deployed in an n-tier model, this cached list exists both on
    ''' the client and on the server.  Both caches are useful.  
    ''' 
    ''' The cache on each client means that each client only needs to retrieve 
    ''' the list from the server once.
    ''' 
    ''' The cach on the server means that the server only needs to retrieve
    ''' the list from the database once, and then distribute it to each
    ''' client upon request.
    ''' </remarks>
    Private Shared _AllEvents As EventList

    '_FilteredEvents is used client-side only; it is a view
    Private Shared _FilteredEvents As EventList


#Region "Business Properties and Methods"
    Default Public ReadOnly Property item(ByVal index As Integer) As TennisEvent
        Get
            Return DirectCast(List.Item(index), TennisEvent)
        End Get
    End Property
#End Region

#Region "Contains"
    Public Overloads Function Contains(ByVal item As TennisEvent) As Boolean
        Return Contains(item.ID)
    End Function

    Public Overloads Function Contains(ByVal ID As Integer) As Boolean
        For Each child As TennisEvent In List
            If child.ID = ID Then
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

    Public Function Find(ByVal ID As Integer) As TennisEvent
        Dim i As Integer = IndexOf(ID)
        If i = -1 Then Return Nothing
        Return Me(i)
    End Function

#End Region

#Region "Shared Methods"
    Public Shared Function GetList(Optional ByVal forceReload As Boolean = False) As EventList
        Return GetList(False, False, -1)
    End Function

    Public Shared Function GetList(ByVal allLeagues As Boolean, ByVal allTournaments As Boolean, ByVal specificID As Integer, Optional ByVal forceReload As Boolean = False) As EventList
        'make sure the main list has been initialized
        GetListAll(forceReload)
        If allLeagues And allTournaments Then Return _AllEvents

        Dim now As Date = Date.Now
        _FilteredEvents = Nothing
        _FilteredEvents = New EventList
        For Each TennisEvent As TennisEvent In _AllEvents
            If (TennisEvent.BeginDate < now AndAlso TennisEvent.EndDate > now) _
            OrElse (allTournaments AndAlso TennisEvent.IsTournament) _
            OrElse (allLeagues AndAlso TennisEvent.IsLeague) _
            OrElse (TennisEvent.ID = specificID) Then
                _FilteredEvents.InnerList.Add(TennisEvent)
            End If
        Next
        Return _FilteredEvents
    End Function

    Public Shared Function GetListAll(Optional ByVal forceReload As Boolean = False) As EventList
        If forceReload Then _AllEvents = Nothing
        If _AllEvents Is Nothing Then
            'when refreshing _AllEvents, _CurrentEvents should also be refreshed
            _AllEvents = DirectCast(DataPortal.Fetch(New Criteria(forceReload)), EventList)
            _AllEvents.Locked = False
            _AllEvents.List.Insert(0, TennisEvent.Create())
            _AllEvents.Locked = True
        End If
        Return _AllEvents
    End Function
#End Region

#Region "Constructors"
    Private Sub New()
        AllowSort = True
        AddHandlers()
    End Sub

    Private Sub AddHandlers()
        AddHandler TennisEvent.Created, AddressOf NewTennisEvent
        AddHandler TennisEvent.Updated, AddressOf UpdatedTennisEvent
        AddHandler TennisEvent.Deleted, AddressOf DeletedTennisEvent
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
    ''' <param name="TennisEvent"></param>
    ''' <remarks></remarks>
    Private Sub NewTennisEvent(ByVal TennisEvent As TennisEvent)
        Dim i As Integer = Me.InnerList.Add(TennisEvent)
        MyBase.OnInsertComplete(i, Me.InnerList(i))
    End Sub

    Private Sub UpdatedTennisEvent(ByVal TennisEvent As TennisEvent)
        Dim i As Integer = IndexOf(TennisEvent.ID)
        Dim OldTennisEvent As TennisEvent = Me(i)
        Locked = False
        List(i) = TennisEvent
        Locked = True
        MyBase.OnSetComplete(i, OldTennisEvent, TennisEvent)
    End Sub

    Private Sub DeletedTennisEvent(ByVal ID As Integer)
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
        Public ForceReload As Boolean
        Public Sub New(Optional ByVal forceReload As Boolean = False)
            Me.ForceReload = forceReload
        End Sub
    End Class
#End Region

#Region "Data Access"
    Const spFetch As String = "csla_get_eventlist"

    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
        If _AllEvents Is Nothing Or crit.ForceReload Then
			Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader(spFetch))
            Try
                Locked = False
                While dr.Read()
                    List.Add(TennisEvent.Fetch(dr))
                End While
            Finally
                Locked = True
                dr.Close()
            End Try
        Else
            Me.InnerList.AddRange(_AllEvents)
        End If
    End Sub
#End Region
End Class

