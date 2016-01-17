<Serializable()> _
Public Class PlayerEventSummaryList
    Inherits Csla.ReadOnlyCollectionBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerEventSummaryList).ToString())

#Region "Business Properties and Methods"
    Default Public ReadOnly Property item(ByVal index As Integer) As PlayerEventSummary
        Get
            Return CType(List.Item(index), PlayerEventSummary)
        End Get
    End Property
#End Region

#Region "Contains"
    Public Overloads Function Contains(ByVal item As PlayerEventSummary) As Boolean
        For Each child As PlayerEventSummary In List
            If child.Equals(item) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "Shared Methods"
    Public Shared Function GetPlayerEventSummaryList(ByVal PlayerID As Long) As PlayerEventSummaryList
        Return CType(DataPortal.Fetch(New Criteria(PlayerID)), PlayerEventSummaryList)
    End Function
#End Region

#Region "Constructors"
    Private Sub New()
        AllowSort = True
    End Sub
#End Region

#Region "Criteria"
    <Serializable()> _
    Private Class Criteria
        Public PlayerID As Long
        Public Sub New(ByVal PlayerID As Long)
            Me.PlayerID = PlayerID
        End Sub
    End Class
#End Region

#Region "Data Access"
    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Locked = False
        Dim crit As Criteria = CType(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_player_summary_events", crit.PlayerID))
        Try
            While dr.Read()
                List.Add(PlayerEventSummary.GetPlayerEventSummary(dr))
            End While
        Finally
            dr.Close()
        End Try
    End Sub
#End Region

End Class
