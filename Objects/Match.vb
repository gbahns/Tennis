''' <summary>
''' Represents a tennis match from an objective point of view.  
''' </summary>
''' <remarks>
''' Specifies the event that this match was part of, the date it was started, 
''' the winner and loser, and the score.  The 'W' fields in the score indicate
''' the number of games won by the winner, and the 'L' fields indicate the
''' number of games won by the loser.
''' </remarks>
<Serializable()> _
Public Class Match
	Inherits BusinessBase

	Private Shared log As ILog = LogManager.GetLogger(GetType(Match).ToString())

#Region "Events"
    Public Shared Event Created(ByVal obj As Match)
    Public Shared Event Updated(ByVal obj As Match)
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
    Private _EventID As Int32
    Private _MatchDate As New SmartDate(DateTime.Now.Date)
    Private _WinnerID As Int32
    Private _LoserID As Int32
    Private WithEvents _Score As New MatchScore
    <NonSerialized(), NotUndoable()> Private _Players As PlayerList = PlayerList.GetList()
    <NonSerialized(), NotUndoable()> Private _Winners As PlayerList = PlayerList.GetDropdownList()
    <NonSerialized(), NotUndoable()> Private _Losers As PlayerList = PlayerList.GetDropdownList()
    <NonSerialized(), NotUndoable()> Private _Events As EventList = EventList.GetList()
    <NonSerialized(), NotUndoable()> Private _ShowAllEvents As Boolean = False
#End Region

#Region "Business Properties and Methods"
	Public ReadOnly Property ID() As Int32
		Get
			Return _ID
		End Get
	End Property

	Public Property EventID() As Int32
		Get
			Return _EventID
		End Get
		Set(ByVal value As Int32)
			If _EventID = value Then Return
			_EventID = value
			MarkDirty()
            ValidateProperty("EventID", _EventID)
            'BrokenRules.Assert("SelectEvent", "Please select an event", "EventID", _EventID = 0)
            BrokenRules.CheckRules("EventID")
		End Set
	End Property

	Public Property MatchDate() As String
		Get
			Return _MatchDate.Date.ToShortDateString()
		End Get
		Set(ByVal value As String)
			If _MatchDate.Equals(value) Then Return
			_MatchDate.Text = value
			MarkDirty()
			'todo: ValidateProperty("MatchDate", _MatchDate)
			'BrokenRules.Assert("SpecifyMatchDate", "Please specify a date", "MatchDate", _MatchDate.IsEmpty)
			BrokenRules.CheckRules("MatchDate")
		End Set
	End Property

	Public Property MatchTime() As String
		Get
			Return _MatchDate.Date.ToShortTimeString()
		End Get
		Set(ByVal value As String)
			If _MatchDate.Equals(value) Then Return
			_MatchDate.Text = value
			MarkDirty()
			'todo: ValidateProperty("MatchDate", _MatchDate)
			'BrokenRules.Assert("SpecifyMatchDate", "Please specify a date", "MatchDate", _MatchDate.IsEmpty)
			BrokenRules.CheckRules("MatchDate")
		End Set
	End Property

	Public Property WinnerID() As Int32
		Get
			Return _WinnerID
		End Get
		Set(ByVal value As Int32)
			If _WinnerID = value Then Return
			_WinnerID = value
			MarkDirty()
			'ValidateProperty("WinnerID", _WinnerID)
			'BrokenRules.Assert("SelectWinner", "Please select a winner", "WinnerID", _WinnerID = 0)
			BrokenRules.CheckRules("WinnerID")
			'BrokenRules.CheckRules("WinnerNotLoser")
		End Set
	End Property

	Public Property LoserID() As Int32
		Get
			Return _LoserID
		End Get
		Set(ByVal value As Int32)
            If _LoserID = value Then Return
			_LoserID = value
			MarkDirty()
            'ValidateProperty("LoserID", _LoserID)
            'BrokenRules.Assert("SelectLoser", "Please select a loser", "LoserID", _LoserID = 0)
            BrokenRules.CheckRules("LoserID")
            'BrokenRules.CheckRules("WinnerNotLoser")
        End Set
    End Property

    Public ReadOnly Property Winner() As Player
        Get
            Return _Players.Find(_WinnerID)
        End Get
    End Property

    Public ReadOnly Property Loser() As Player
        Get
            Return _Players.Find(_LoserID)
        End Get
    End Property

    Public ReadOnly Property Score() As MatchScore
        Get
            Return _Score
        End Get
    End Property

    Public ReadOnly Property ResultString() As String
        Get
            Return ToString()
        End Get
    End Property

    'Private Function CreatePlayerDropdownList() As PlayerList
    '    Dim list As PlayerList = DirectCast(PlayerList.GetList().Clone(), PlayerList)
    '    list.AddBlankSelection()
    '    Return list
    'End Function

    Public ReadOnly Property Winners() As PlayerList
        Get
            Return _Winners
        End Get
    End Property

    Public ReadOnly Property Losers() As PlayerList
        Get
            Return _Losers
        End Get
    End Property

    Public ReadOnly Property Events() As EventList
        Get
            Return _Events
        End Get
    End Property

    'Public Property ShowAllEvents() As Boolean
    '    Get
    '        Return _ShowAllEvents
    '    End Get
    '    Set(ByVal value As Boolean)
    '        If _ShowAllEvents = value Then Return
    '        _ShowAllEvents = value
    '        If _ShowAllEvents Then
    '            _Events = EventInfoList.GetListAll
    '        Else
    '            _Events = EventInfoList.GetList
    '        End If
    '        OnIsDirtyChanged()
    '    End Set
    'End Property

    Public Sub FilterEvents(ByVal allLeagues As Boolean, ByVal allTournaments As Boolean)
        _Events = EventList.GetList(allLeagues, allTournaments, _EventID)
        OnIsDirtyChanged()
    End Sub

    Public Overrides Function Save() As BusinessBase
        Dim creating As Boolean = IsNew
        Dim Match As Match = DirectCast(MyBase.Save(), Match)
        If creating Then
            Match.OnCreated()
        ElseIf IsNew Then
            Match.OnDeleted()
        Else
            Match.OnUpdated()
        End If
        Return Match
    End Function
#End Region

#Region "System.Object Overrides"
    Public Overrides Function ToString() As String
        Dim winner As Player = Me.Winner
        Dim loser As Player = Me.Loser
        If winner Is Nothing Or loser Is Nothing Then
            Return IIf(IsNew, "New Match", "Edit Match")
        Else
            Return String.Format("{0} d. {1} {2}", winner.FullName, loser.FullName, _Score)
        End If
        'Return String.Format("{0} d. {1}", WinnerID, LoserID)
        'Return _ID.ToString
    End Function

    Public Overloads Function Equals(ByVal A As Match) As Boolean
        Return _ID = A._ID
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _ID.GetHashCode()
    End Function
#End Region

#Region " IsValid and IsDirty "
    Public Overrides ReadOnly Property IsValid() As Boolean
        Get
            Return MyBase.IsValid AndAlso _Score.IsValid
        End Get
    End Property

    Public Overrides ReadOnly Property IsDirty() As Boolean
        Get
            Return MyBase.IsDirty OrElse _Score.IsDirty
        End Get
    End Property
#End Region

#Region "Shared Methods"
    Public Shared Function Create() As Match
        Return New Match()
    End Function

    ''' <summary>
    ''' Retrieve match as child object
    ''' </summary>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fetch(ByVal dr As SafeDataReader) As Match
        Dim Match As New Match()
        Match.MarkAsChild()
        Match._Fetch(dr)
        Return Match
    End Function

    ''' <summary>
    ''' Retrieve match as root object
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fetch(ByVal ID As Int32) As Match
        Return DirectCast(DataPortal.Fetch(New Criteria(ID)), Match)
    End Function

    Public Overloads Shared Sub Delete(ByVal ID As Integer)
        DataPortal.Delete(New Criteria(ID))
        OnDeleted(ID)
    End Sub
#End Region

#Region "Constructors"
    Private Sub New()
        'todo: make sure MarkChild is set when the new match is being created as a child object
        'MarkAsChild()
        AddBusinessRules()
        BrokenRules.CheckRules()
    End Sub

    'Sub Score_IsDirtyChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _Score.IsDirtyChanged
    '    Me.OnIsDirtyChanged()
    'End Sub
#End Region

#Region "Business Rules"
    Protected Overrides Sub AddBusinessRules()
        With BrokenRules
            .SetTargetObject(Me)
            '.AddRule(AddressOf EventRequired, "EventID", "EventID")
            .AddRule(AddressOf ComboRequired, "EventID", "EventID")
            .AddRule(AddressOf DateRequired, "MatchDate", "MatchDate")
            .AddRule(AddressOf DateIsInPast, "MatchDate", "MatchDate")

            .AddRule(AddressOf ComboRequired, "WinnerID", "WinnerID")
            .AddRule(AddressOf ComboRequired, "LoserID", "LoserID")
            .AddRule(AddressOf WinnerNotLoser, "WinnerID", "WinnerID")
            .AddRule(AddressOf WinnerNotLoser, "LoserID", "LoserID")
        End With
        AddHandler _Score.IsDirtyChanged, AddressOf Child_IsDirtyChanged
    End Sub

    <BrokenRules.Description("Match winner cannot also be the loser")> _
    Private Function WinnerNotLoser(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        'if the winner has not been selected, don't enforse this rule
        Return _WinnerID = 0 Or _WinnerID <> _LoserID
    End Function

    Private Function SetWinnerIsTiebreakWinner(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        Return True
    End Function

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
    Const spFetch As String = "csla_get_match"
    Const spUpdate As String = "csla_save_match"
    Const spDelete As String = "csla_delete_match"

    Private Sub _Fetch(ByVal dr As SafeDataReader)
        _ID = dr.GetInt32
        _EventID = dr.GetInt32
        _MatchDate = dr.GetSmartDate
        _WinnerID = dr.GetInt32
        _LoserID = dr.GetInt32
        _Score.Fetch(dr)
    End Sub

    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader(spFetch, crit.ID))

        Try
            If Not dr.Read() Then
                Throw New ApplicationException(String.Format("Match not found (ID:{0})", crit.ID))
            End If
            _Fetch(dr)

            'If Not AreMaxLengthsSet Then
            '	LoadRules()
            'End If
            'log.Debug(String.Format("Business Rules: {0}{1}", ControlChars.CrLf, Rules))
            If Not _Events.Contains(_EventID) Then
                FilterEvents(False, False)
            End If
        Finally
            dr.Close()
        End Try
        BrokenRules.CheckRules()
        MarkOld()
    End Sub

    Protected Overrides Sub DataPortal_Update()
        'insert or update object data into database
        log.Debug("updating match " & ToString())

        Try
            'Throw New Exception("Dummy exception to test error handling")

            If Me.IsDeleted Then
                If Not Me.IsNew Then
                    DataAccess.ExecUpdate(spDelete, ID)
                End If
                MarkNew()
            Else
                Dim ret As ArrayList = DataAccess.ExecUpdate(spUpdate, _
                     IDParam(_ID, IsNew), _
                     _EventID, _
                     _MatchDate.DBValue, _
                     _WinnerID, _
                     _LoserID, _
                     _Score.Sets(0).WGames, _
                     _Score.Sets(0).LGames, _
                     _Score.Sets(0).WTiebreak, _
                     _Score.Sets(0).LTiebreak, _
                     _Score.Sets(1).WGames, _
                     _Score.Sets(1).LGames, _
                     _Score.Sets(1).WTiebreak, _
                     _Score.Sets(1).LTiebreak, _
                     _Score.Sets(2).WGames, _
                     _Score.Sets(2).LGames, _
                     _Score.Sets(2).WTiebreak, _
                     _Score.Sets(2).LTiebreak, _
                     _Score.Sets(3).WGames, _
                     _Score.Sets(3).LGames, _
                     _Score.Sets(3).WTiebreak, _
                     _Score.Sets(3).LTiebreak, _
                     _Score.Sets(4).WGames, _
                     _Score.Sets(4).LGames, _
                     _Score.Sets(4).WTiebreak, _
                     _Score.Sets(4).LTiebreak, _
                     _Score.LoserDefaulted)
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

    'DataPortal_Delete supports direct object deletion.  If we don't want to
    'support direct deletion, delete this method. 
    Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object)
        Dim crit As Criteria = DirectCast(Criteria, Criteria)
        Try
            DataAccess.ExecUpdate("csla_delete_match", crit.ID)
        Catch ex As Exception
            log.Error("error in DataPortal_Delete", ex)
            Throw New Library.DataPortalException("error in DataPortal_Delete", ex)
        End Try
    End Sub

#End Region

End Class
