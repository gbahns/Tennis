Imports CSLA.Data

<Serializable()> _
Public Class PlayerList
    Inherits Csla.ReadOnlyCollectionBase

	Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerList).ToString())

#Region "Private Data"
    ''' <summary>
    ''' Cached list of players from database.
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
    Private Shared _AllPlayers As PlayerList
#End Region

#Region "Business Properties and Methods"
	Default Public ReadOnly Property item(ByVal index As Integer) As Player
		Get
			Return CType(List.Item(index), Player)
		End Get
    End Property

    Public Function Find(ByVal ID As Integer) As Player
        For Each player As Player In InnerList
            If player.ID = ID Then Return player
        Next
        Return Nothing
    End Function

	Public Sub Add()
        List.Add(Player.Create())
    End Sub

    Public Sub AddBlankSelection()
        'hack: using InnerList because the player object does not call MarkAsChild
        InnerList.Insert(0, Player.Create())
    End Sub

	Public Sub Remove(ByVal Child As Player)
		List.Remove(Child)
	End Sub
#End Region

#Region "Contains"
	Public Overloads Function Contains(ByVal item As Player) As Boolean
		Dim child As Player
		For Each child In List
			If child.Equals(item) Then
				Return True
			End If
		Next
		Return False
	End Function

    'Public Overloads Function ContainsDeleted(ByVal item As Player) As Boolean
    '	Dim child As Player
    '	For Each child In deletedList
    '		If child.Equals(item) Then
    '			Return True
    '		End If
    '	Next
    '	Return False
    '   End Function

    Public Function IndexOf(ByVal ID As Integer) As Integer
        For i As Integer = 0 To Count - 1
            If Me(i).ID = ID Then
                Return i
            End If
        Next
        Return -1
    End Function
#End Region

#Region "System.Object Overrides"
	'normally these overrides don't make sense for collection objects

	'Public Overrides Function ToString() As String
	'	'todo: return a useful string representation of the object
	'	Return MyBase.ToString()
	'End Function

	'Public Overloads Function Equals(ByVal A As String) As Boolean
	'	'todo: implement comparison logic
	'	Return False
	'End Function

	'Public Overrides Function GetHashCode() As Integer
	'	'todo: return a hash value for the object
	'	'for example, a common approach is to return ID.GetHashCode()
	'	Return MyBase.GetHashCode()
	'End Function
#End Region

#Region "Shared Methods"
    Public Shared Function CreateList() As PlayerList
        Return New PlayerList()
    End Function

    ''' <summary>
    ''' Retrieves a complete list of all players.
    ''' </summary>
    ''' <returns>List of all players.</returns>
    ''' <remarks>
    ''' This method executes on the client side.  If the player list is stored
    ''' in the client's cache, it is returned without going to the server.
    ''' If not, the DataPortal is used to retrieve the list from the server
    ''' and then it is stored in the cache.
    ''' </remarks>
    Public Shared Function GetList(Optional ByVal forceReload As Boolean = False) As PlayerList
        If _AllPlayers Is Nothing Or forceReload Then
            _AllPlayers = DirectCast(DataPortal.Fetch(New Criteria(forceReload)), PlayerList)
        End If
        Return _AllPlayers
    End Function

    Public Shared Function GetDropdownList(Optional ByVal forceReload As Boolean = False) As PlayerList
        Dim list As PlayerList = DirectCast(GetList(forceReload).Clone(), PlayerList)
        list.AddBlankSelection()
        Return list
    End Function

    Public Shared Sub DeleteList()
        DataPortal.Delete(New Criteria())
    End Sub
#End Region

#Region "Constructors"
    Private Sub New()
        AllowSort = True
        AddHandlers()
    End Sub

    Protected Overrides Sub Deserialized()
        MyBase.Deserialized()
        'when an object is deserialized, such as happens with the Clone method, 
        'the event handlers need to be re-hooked
        AddHandlers()
    End Sub

    Private Sub AddHandlers()
        AddHandler Player.Created, AddressOf NewPlayer
        AddHandler Player.Updated, AddressOf UpdatedPlayer
        AddHandler Player.Deleted, AddressOf DeletedPlayer
    End Sub

    ''' <summary>
    ''' Whenever a new event is created, automatically add it to the list.
    ''' </summary>
    ''' <param name="Player"></param>
    ''' <remarks></remarks>
    Private Sub NewPlayer(ByVal Player As Player)
        Dim i As Integer = Me.InnerList.Add(Player)
        MyBase.OnInsertComplete(i, Me.InnerList(i))
    End Sub

    Private Sub UpdatedPlayer(ByVal Player As Player)
        Dim i As Integer = IndexOf(Player.ID)
        Dim OldPlayer As Player = Me(i)
        Locked = False
        List(i) = Player
        Locked = True
        MyBase.OnSetComplete(i, OldPlayer, Player)
    End Sub

    Private Sub DeletedPlayer(ByVal ID As Integer)
        'Dim BindingList As System.ComponentModel.IBindingList = Me
        'Dim i As Integer = BindingList.Find("ID", ID)
        Dim i As Integer = IndexOf(ID)
        If i = -1 Then Return
        Locked = False
        RemoveAt(i)
        'MyBase.OnRemoveComplete(i, value)
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
    Const spFetch As String = "csla_get_playerlist"

    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
        If _AllPlayers Is Nothing Or crit.ForceReload Then
			Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader(spFetch))
            Try
                Locked = False
                While dr.Read()
                    List.Add(Player.Fetch(dr))
                End While
            Finally
                Locked = True
                dr.Close()
            End Try
        Else
            Me.InnerList.AddRange(_AllPlayers)
        End If
    End Sub

    'Protected Overrides Sub DataPortal_Update()
    '    'loop through each deleted child object and call its update method
    '    For Each Player As Player In deletedList
    '        Player.Update(Me)
    '    Next

    '    'then clear the list of deleted objects because they are truly gone now
    '    deletedList.Clear()

    '    'loop through each non-deleted child object and call its update method
    '    For Each Player As Player In List
    '        Player.Update(Me)
    '    Next
    'End Sub

    'DataPortal_Delete supports direct object deletion.  If we don't want to
    'support direct delition, delete this method. 
    'Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object)
    '    Dim crit As Criteria = CType(Criteria, Criteria)
    '    'delete all Player data that matches the criteria
    'End Sub
#End Region

End Class
