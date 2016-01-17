<Serializable()> _
Public Class TennisEvent
    Inherits BusinessBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(TennisEvent).ToString())

#Region "Events"
    'these events only occur when updating to the database
    'maybe they should happen when ApplyEdit is called?
    'maybe they should happen when IsDirtyChanged is raised?
    'hmmm....
    'maybe ApplyEdit is the best time, but how do we hook into that?

    Public Shared Event Created(ByVal obj As TennisEvent)
    Public Shared Event Updated(ByVal obj As TennisEvent)
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
    Private _ID As Integer
    Private _Name As String = ""
    'Private _Classification As Classification
    Private _ClassificationID As Integer
    Private _BeginDate As New SmartDate(True)
    Private _EndDate As New SmartDate(False)
    Private _TeamPlay As Boolean
    Private _EventType As EventTypeEnum
#End Region

#Region "Business Properties and Methods"
    Public Enum EventTypeEnum As Short
        Normal = 0
        League = 1
        Tournament = 2
    End Enum

    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            If _Name = value Then Return
            _Name = value
            MarkDirty()
            ValidateProperty("Name", _Name)
            BrokenRules.Assert("EventNameRequired", "Please enter a name for this event", "Name", Name.Length = 0)
        End Set
    End Property

    Public Property ClassificationID() As Integer
        Get
            Return _ClassificationID
        End Get
        Set(ByVal value As Integer)
            If _ClassificationID = value Then Return
            _ClassificationID = value
            MarkDirty()
            ValidateProperty("ClassificationID", _ClassificationID)
            BrokenRules.Assert("SelectClassification", "Please select a classification", "ClassificationID", _ClassificationID = 0)
        End Set
    End Property

    Public Property BeginDate() As Date
        Get
            Return _BeginDate.Date
        End Get
        Set(ByVal value As Date)
            If _BeginDate.Date = value Then Return
            _BeginDate.Date = value
            MarkDirty()
            ValidateProperty("BeginDate", _BeginDate)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "BeginDate", _EventID = 0)
        End Set
    End Property

    Public Property BeginDateText() As String
        Get
            Return _BeginDate.Text
        End Get
        Set(ByVal value As String)
            If _BeginDate.Text = value Then Return
            _BeginDate.Text = value
            MarkDirty()
            ValidateProperty("BeginDate", _BeginDate)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "BeginDate", _EventID = 0)
        End Set
    End Property

    Public Property EndDate() As Date
        Get
            Return _EndDate.Date
        End Get
        Set(ByVal value As Date)
            If _EndDate.Date = value Then Return
            _EndDate.Date = value
            MarkDirty()
            ValidateProperty("EndDate", _EndDate)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "EndDate", _EndDate = 0)
        End Set
    End Property

    Public Property EndDateText() As String
        Get
            Return _EndDate.Text
        End Get
        Set(ByVal value As String)
            If _EndDate.Text = value Then Return
            _EndDate.Text = value
            MarkDirty()
            ValidateProperty("EndDate", _EndDate)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "EndDate", _EndDate = 0)
        End Set
    End Property

    Public Property TeamPlay() As Boolean
        Get
            Return _TeamPlay
        End Get
        Set(ByVal value As Boolean)
            If _TeamPlay = value Then Return
            _TeamPlay = value
            MarkDirty()
            'ValidateProperty("TeamPlay", _TeamPlay)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "TeamPlay", _TeamPlay = 0)
        End Set
    End Property

    Public Property EventType() As EventTypeEnum
        Get
            Return _EventType
        End Get
        Set(ByVal value As EventTypeEnum)
            If _EventType = value Then Return
            _EventType = value
            MarkDirty()
            'ValidateProperty("EventType", _EventType)
        End Set
    End Property

    Public Property IsLeague() As Boolean
        Get
            Return EventType = EventTypeEnum.League
        End Get
        Set(ByVal value As Boolean)
            EventType = IIf(value, EventTypeEnum.League, EventTypeEnum.Normal)
        End Set
    End Property

    Public Property IsTournament() As Boolean
        Get
            Return EventType = EventTypeEnum.Tournament
        End Get
        Set(ByVal value As Boolean)
            EventType = IIf(value, EventTypeEnum.Tournament, EventTypeEnum.Normal)
        End Set
    End Property

    Public Overrides Function Save() As BusinessBase
        Dim creating As Boolean = IsNew
        Dim TennisEvent As TennisEvent = DirectCast(MyBase.Save(), TennisEvent)
        If creating Then
            TennisEvent.OnCreated()
        ElseIf IsNew Then
            TennisEvent.OnDeleted()
        Else
            TennisEvent.OnUpdated()
        End If
        Return TennisEvent
    End Function

#End Region

#Region "System.Object Overrides"
    Public Overrides Function ToString() As String
        'todo: return a useful string representation of the object
        Return MyBase.ToString()
    End Function

    Public Overloads Function Equals(ByVal A As String) As Boolean
        'todo: implement comparison logic
        Return False
    End Function

    Public Overrides Function GetHashCode() As Integer
        'todo: return a hash value for the object
        'for example, a common approach is to return ID.GetHashCode()
        Return MyBase.GetHashCode()
    End Function
#End Region

#Region "Shared Methods"
    Public Shared Function Create(Optional ByVal initialName As String = "") As TennisEvent
        Return New TennisEvent(initialName)
    End Function

    Public Shared Function Fetch(ByVal ID As Integer) As TennisEvent
        Return DirectCast(DataPortal.Fetch(New Criteria(ID)), TennisEvent)
    End Function

    Public Shared Function Fetch(ByVal dr As SafeDataReader) As TennisEvent
        Dim TennisEVent As New TennisEvent
        TennisEVent.MarkAsChild()
        TennisEVent._Fetch(dr)
        Return TennisEVent
    End Function

    Public Overloads Shared Sub Delete(ByVal ID As Integer)
        DataPortal.Delete(New Criteria(ID))
        OnDeleted(ID)
    End Sub
#End Region

#Region "Constructors"
    Private Sub New()
    End Sub

    Private Sub New(ByVal initialName As String)
        Name = initialName
    End Sub
#End Region

#Region "Criteria"
    <Serializable()> _
    Private Class Criteria
        Public ID As Int32
        Public Sub New(ByVal ID As Int32)
            Me.ID = ID
        End Sub
    End Class
#End Region

#Region "Data Access"
    Const spFetch As String = "csla_get_event"
    Const spUpdate As String = "csla_save_event"
    Const spDelete As String = "csla_delete_event"

    Private Sub _Fetch(ByVal dr As SafeDataReader)
        _ID = dr.GetInt32
        _Name = dr.GetString
        _ClassificationID = dr.GetInt32
        _BeginDate = dr.GetSmartDate(_BeginDate.EmptyIsMin)
        _EndDate = dr.GetSmartDate(_EndDate.EmptyIsMin)
        _EventType = DirectCast(dr.GetInt16, EventTypeEnum)
        _TeamPlay = dr.GetBoolean
    End Sub

    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader(spFetch, crit.ID))
        Try
            If Not dr.Read() Then
                Throw New ApplicationException(String.Format("Event not found (ID:{0})", crit.ID))
            End If
            _Fetch(dr)
            'If Not AreMaxLengthsSet Then
            '	LoadRules()
            'End If
            'log.Debug(String.Format("Business Rules: {0}{1}", ControlChars.CrLf, Rules))
        Finally
            dr.Close()
        End Try
        MarkOld()
    End Sub

    Protected Overrides Sub DataPortal_Update()
        'insert or update object data into database
        log.Debug("updating event " & ToString())

        Try
            If Me.IsDeleted Then
                If Not Me.IsNew Then
                    DataAccess.ExecUpdate(spDelete, ID)
                End If
                MarkNew()
            Else
                'DataAccess.GetParameter("@ID", IDParam(_ID, IsNew), ParameterDirection.InputOutput),
                Dim ret As ArrayList = DataAccess.ExecUpdate(spUpdate, _
                      IDParam(_ID, IsNew), _
                     _Name, _
                     _ClassificationID, _
                     _BeginDate.DBValue, _
                     _EndDate.DBValue, _
                     _EventType, _
                     _TeamPlay)
                If IsNew Then
                    _ID = CInt(ret(0))
                    log.Info(String.Format("New id is {0}", _ID))
                End If
                MarkOld()
            End If
        Catch ex As Exception
            log.Error("error in DataPortal_Update", ex)
            Throw New Library.DataPortalException("error in DataPortal_Update", ex)
        End Try

    End Sub

    Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
        Try
            DataAccess.ExecUpdate(spDelete, crit.ID)
        Catch ex As Exception
            log.Error("error in DataPortal_Delete", ex)
            Throw New Library.DataPortalException("error in DataPortal_Delete", ex)
        End Try
    End Sub
#End Region

End Class
