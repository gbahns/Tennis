Imports System.Collections.Generic

<Serializable()> _
Public Class Player
	Inherits BusinessBase

	Private Shared log As ILog = LogManager.GetLogger(GetType(Player).ToString())

#Region "Events"
    Public Shared Event Created(ByVal obj As Player)
    Public Shared Event Updated(ByVal obj As Player)
    Public Shared Event Deleted(ByVal ID As Integer)

    Public Sub OnCreated()
        RaiseEvent Created(Me)
    End Sub

    Public Sub OnUpdated()
        RaiseEvent Updated(Me)
    End Sub

    Public Sub OnDeleted()
        RaiseEvent Deleted(Me.ID)
    End Sub

    Public Shared Sub OnDeleted(ByVal ID As Integer)
        RaiseEvent Deleted(ID)
    End Sub
#End Region

#Region "Private Data"
	Private _ID As Int32
	Private _FirstName As String = ""
	Private _LastName As String = ""
#End Region

#Region "Business Properties and Methods"
	Public ReadOnly Property ID() As Int32
		Get
			Return _ID
		End Get
	End Property

	Public Property FirstName() As String
		Get
			Return _FirstName
		End Get
		Set(ByVal value As String)
			If _FirstName = value Then Return
			_FirstName = value
			MarkDirty()
			ValidateProperty("FirstName", _FirstName)
		End Set
	End Property

	Public Property LastName() As String
		Get
			Return _LastName
		End Get
		Set(ByVal value As String)
			If _LastName = value Then Return
			_LastName = value
			MarkDirty()
			ValidateProperty("LastName", _LastName)
		End Set
	End Property

    Public Property FullName() As String
        Get
            If FirstName.Length = 0 And LastName.Length = 0 Then Return ""
            Return String.Format("{0} {1}", FirstName, LastName)
        End Get
        Set(ByVal value As String)
            Dim array As String() = value.Split(" ".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries)
            If array.Length > 0 Then
                FirstName = array(0)
                If array.Length > 1 Then
                    LastName = array(1)
                End If
            End If
        End Set
    End Property

    Public Overrides Function Save() As BusinessBase
        Dim creating As Boolean = IsNew
        Dim Player As Player = DirectCast(MyBase.Save(), Player)
        If creating Then
            Player.OnCreated()
        ElseIf IsNew Then
            Player.OnDeleted()
        Else
            Player.OnUpdated()
        End If
        Return Player
    End Function
#End Region

#Region "System.Object Overrides"
	Public Overrides Function ToString() As String
		'Return String.Format("{0} {1} ({2})", FirstName, LastName, ID)
		Return FullName
	End Function

	Public Overloads Function Equals(ByVal A As Player) As Boolean
		Return _ID = A._ID
	End Function

	Public Overrides Function GetHashCode() As Integer
		Return _ID.GetHashCode()
	End Function
#End Region

#Region "Shared Methods"
    Public Shared Function Create(Optional ByVal initialName As String = "") As Player
        'todo: make sure MarkChild is set when the new player is being created as a child object
        Return New Player(initialName)
    End Function

    Public Shared Function Fetch(ByVal dr As SafeDataReader) As Player
        Dim Player As New Player
        Player.MarkAsChild()
        Player._Fetch(dr)
        Return Player
    End Function

    Public Shared Function Fetch(ByVal ID As Int32) As Player
        Return DirectCast(DataPortal.Fetch(New Criteria(ID)), Player)
    End Function

    Public Overloads Shared Sub Delete(ByVal ID As Int32)
        DataPortal.Delete(New Criteria(ID))
        OnDeleted(ID)
    End Sub
#End Region

#Region "Constructors"
    Private Sub New()
    End Sub

    Private Sub New(ByVal initialName As String)
        FullName = initialName
    End Sub
#End Region

#Region "Criteria"
    <Serializable()> _
    Private Class Criteria
        Public ID As Int32
        Public Sub New()
        End Sub
        Public Sub New(ByVal ID As Int32)
            Me.ID = ID
        End Sub
    End Class
#End Region

#Region "Data Access"
    Private Sub _Fetch(ByVal dr As SafeDataReader)
        _ID = dr.GetInt32()
        _FirstName = dr.GetString()
        _LastName = dr.GetString()
    End Sub

    Friend Sub Update(ByVal Parent As PlayerList)
        'todo: insert or update object data into database
    End Sub

    Protected Sub FetchMaxLengths(ByVal dr As SafeDataReader)
        MyRules.MaxLength("FirstName") = dr.GetMaxLength(1)
        MyRules.MaxLength("LastName") = dr.GetMaxLength()
    End Sub

    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = CType(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_player", crit.ID))
        Try
            If Not dr.Read() Then
                Throw New ApplicationException(String.Format("Player not found (ID:{0})", crit.ID))
            End If
            'Dim SchemaTable As DataTable = dr.GetSchemaTable()
            'For Each row As DataRow In SchemaTable.Rows
            '	For Each column As DataColumn In SchemaTable.Columns
            '		log.Debug(String.Format("{0}:{1} [{2}] ", column.Ordinal, column.ColumnName, row(column.ColumnName)))
            '	Next
            'Next
            _Fetch(dr)
            'If Not AreMaxLengthsSet Then
            '	LoadRules()
            '	FetchMaxLengths(dr)
            'End If
            'log.Debug(String.Format("Business Rules: {0}{1}", ControlChars.CrLf, Rules))
        Finally
            dr.Close()
        End Try
        MarkOld()
    End Sub

    Protected Overrides Sub DataPortal_Update()
        If Me.IsDeleted Then
            If Not Me.IsNew Then
                DataAccess.ExecUpdate("csla_delete_player", _ID)
            End If
            MarkNew()
        Else
            Dim ret As ArrayList = DataAccess.ExecUpdate("csla_save_player", _
                IDParam(_ID, IsNew), _
                _FirstName, _
                _LastName)
            If IsNew Then
                _ID = CInt(ret(0))
                log.Info(String.Format("New id is {0}", _ID))
            End If
            MarkOld()
        End If
    End Sub

    'DataPortal_Delete supports direct object deletion.  If we don't want to
    'support direct deletion, delete this method. 
    Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
        Try
            DataAccess.ExecUpdate("csla_delete_player", crit.ID)
        Catch ex As Exception
            log.Error("error in DataPortal_Delete", ex)
            Throw New Library.DataPortalException("error in DataPortal_Delete", ex)
        End Try
    End Sub
#End Region

End Class
