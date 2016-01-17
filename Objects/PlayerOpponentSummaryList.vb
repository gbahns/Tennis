<Serializable()> _
Public Class PlayerOpponentSummaryList
    Inherits Csla.ReadOnlyCollectionBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(PlayerOpponentSummaryList).ToString())

#Region "Business Properties and Methods"
    Default Public ReadOnly Property item(ByVal index As Int32) As PlayerOpponentSummary
        Get
            Return CType(List.Item(index), PlayerOpponentSummary)
        End Get
    End Property
#End Region

#Region "Contains"
    Public Overloads Function Contains(ByVal item As PlayerOpponentSummary) As Boolean
        For Each child As PlayerOpponentSummary In List
            If child.Equals(item) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "Shared Methods"
    Public Shared Function GetPlayerOpponentSummaryList(ByVal PlayerID As Int32) As PlayerOpponentSummaryList
        Return CType(DataPortal.Fetch(New Criteria(PlayerID)), PlayerOpponentSummaryList)
    End Function
#End Region

#Region "Constructors"
    Private Sub New()
        'Prevent direction creation
        AllowSort = True
    End Sub
#End Region

#Region "Criteria"
    <Serializable()> _
    Private Class Criteria
        Public PlayerID As Int32
        Public Sub New(ByVal PlayerID As Int32)
            Me.PlayerID = PlayerID
        End Sub
    End Class
#End Region

#Region "Data Access"
    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Locked = False
        Dim crit As Criteria = CType(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_player_summary_opponents", crit.PlayerID))
        Try
            While dr.Read()
                List.Add(PlayerOpponentSummary.GetPlayerOpponentSummary(dr))
            End While
        Finally
            dr.Close()
        End Try
    End Sub
#End Region

End Class
