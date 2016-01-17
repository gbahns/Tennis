<Serializable()> _
Public Class PlayerEventSummary
    Inherits ReadOnlyBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerEventSummary).ToString())

#Region "Private Data"
    Private _TennisEvent As String
    Private _Matches As WinLossRecord
    Private _Sets As WinLossRecord
    Private _Games As WinLossRecord
    Private mStartDate As SmartDate
#End Region


#Region "Business Properties and Methods"
    Public ReadOnly Property TennisEvent() As String
        Get
            Return _TennisEvent
        End Get
    End Property

    Public ReadOnly Property Matches() As WinLossRecord
        Get
            Return _Matches
        End Get
    End Property

    Public ReadOnly Property Sets() As WinLossRecord
        Get
            Return _Sets
        End Get
    End Property

    Public ReadOnly Property Games() As WinLossRecord
        Get
            Return _Games
        End Get
    End Property

    Public ReadOnly Property StartDate() As SmartDate
        Get
            Return mStartDate
        End Get
    End Property
#End Region

#Region "Additional Properties for Data Binding"
    Public ReadOnly Property MatchesPlayed() As Long
        Get
            Return Matches.Won + Matches.Lost
        End Get
    End Property
    Public ReadOnly Property MatchesWon() As Long
        Get
            Return Matches.Won
        End Get
    End Property
    Public ReadOnly Property MatchesLost() As Long
        Get
            Return Matches.Lost
        End Get
    End Property
    Public ReadOnly Property MatchesPct() As Double
        Get
            Return Matches.Pct
        End Get
    End Property

    Public ReadOnly Property SetsWon() As Long
        Get
            Return Sets.Won
        End Get
    End Property
    Public ReadOnly Property SetsLost() As Long
        Get
            Return Sets.Lost
        End Get
    End Property
    Public ReadOnly Property SetsPct() As Double
        Get
            Return Sets.Pct
        End Get
    End Property

    Public ReadOnly Property GamesWon() As Long
        Get
            Return Games.Won
        End Get
    End Property
    Public ReadOnly Property GamesLost() As Long
        Get
            Return Games.Lost
        End Get
    End Property
    Public ReadOnly Property GamesPct() As Double
        Get
            Return Games.Pct
        End Get
    End Property

#End Region

#Region "System.Object Overrides"
    Public Overrides Function ToString() As String
        Return String.Format("{0} ({1})", TennisEvent, Matches)
    End Function

    Public Overloads Function Equals(ByVal A As PlayerEventSummary) As Boolean
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
    Public Shared Function GetPlayerEventSummary(ByVal dr As SafeDataReader) As PlayerEventSummary
        Dim PlayerEventSummary As New PlayerEventSummary
        PlayerEventSummary.Fetch(dr)
        Return PlayerEventSummary
    End Function
#End Region

#Region "Constructors"
    Private Sub New()
        'Prevent direction creation
    End Sub
#End Region

#Region "Data Access"
    Private Sub Fetch(ByVal dr As SafeDataReader)
        _TennisEvent = dr.GetString()
        mStartDate = dr.GetSmartDate()
        mStartDate.FormatString = "Short Date"
        _Matches.Won = dr.GetInt32()
        _Matches.Lost = dr.GetInt32()
        _Sets.Won = dr.GetInt32()
        _Sets.Lost = dr.GetInt32()
        _Games.Won = dr.GetInt32()
        _Games.Lost = dr.GetInt32()
    End Sub
#End Region

End Class
