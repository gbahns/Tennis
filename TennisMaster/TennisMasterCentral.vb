Imports Microsoft.VisualBasic

Public Class TennisMasterCentral

#Region "Main"
    Private Sub TennisMasterCentral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Return
        Login()
    End Sub

    Private Sub tabMainForm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMainForm.SelectedIndexChanged
        tabMainForm.SelectedTab.Focus()
    End Sub
#End Region

#Region "Player Event Summary"
    Private Sub dgEventSummary_InitializeGrid()
        If Not DataLayerReady() Then Return
        Try
            If dgEventSummary.ColumnCount > 0 Then Return
            If dgEventSummary.DataSource Is Nothing Then
                AddColumn(dgEventSummary, "Event", "TennisEvent")
                AddColumn(dgEventSummary, "Date", "StartDate")
                AddColumn(dgEventSummary, "Matches", "MatchesPlayed", True)
                AddColumn(dgEventSummary, "W", "MatchesWon", True)
                AddColumn(dgEventSummary, "L", "MatchesLost", True)
                AddColumn(dgEventSummary, "Pct", "MatchesPct", True, "0.000")
                AddColumn(dgEventSummary, "S-W", "SetsWon", True)
                AddColumn(dgEventSummary, "S-L", "SetsLost", True)
                AddColumn(dgEventSummary, "S-Pct", "SetsPct", True, "0.000")
                AddColumn(dgEventSummary, "G-W", "GamesWon", True)
                AddColumn(dgEventSummary, "G-L", "GamesLost", True)
                AddColumn(dgEventSummary, "G-Pct", "GamesPct", True, "0.000")
                PrepareDataView(dgEventSummary, PlayerEventSummaryList.GetPlayerEventSummaryList(1))
            End If
            dgEventSummary.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgEventSummary.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
        Catch ex As Exception
            log.Warn("dgEventSummary_InitializeGrid failed", ex)
        End Try
    End Sub

    Private Sub tabEventSummary_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEventSummary.GotFocus
        dgEventSummary.Focus()
    End Sub

    Private Sub tabEventSummary_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles tabEventSummary.Layout
        dgEventSummary.Focus()
    End Sub

    Private Sub tabEventSummary_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabEventSummary.Enter
        dgEventSummary.Focus()
    End Sub

    Private Sub dgEventSummary_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgEventSummary.CellMouseDoubleClick
        'todo: open event record for editing when a cell containing the event name is clicked
    End Sub

    Private Sub dgEventSummary_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgEventSummary.Paint
        dgEventSummary_InitializeGrid()
    End Sub
#End Region

#Region "Player Opponent Summary"
    Private Sub tabOpponentSummary_InitializeGrid()
        If Not DataLayerReady() Then Return
        Try
            If dgOpponentSummary.ColumnCount > 0 Then Return
            If dgOpponentSummary.DataSource Is Nothing Then
                AddColumn(dgOpponentSummary, "Opponent", "Name")
                AddColumn(dgOpponentSummary, "Matches", "MatchesPlayed", True)
                AddColumn(dgOpponentSummary, "W", "MatchesWon", True)
                AddColumn(dgOpponentSummary, "L", "MatchesLost", True)
                AddColumn(dgOpponentSummary, "Pct", "MatchesPct", True, "0.000")
                AddColumn(dgOpponentSummary, "S-W", "SetsWon", True)
                AddColumn(dgOpponentSummary, "S-L", "SetsLost", True)
                AddColumn(dgOpponentSummary, "S-Pct", "SetsPct", True, "0.000")
                AddColumn(dgOpponentSummary, "G-W", "GamesWon", True)
                AddColumn(dgOpponentSummary, "G-L", "GamesLost", True)
                AddColumn(dgOpponentSummary, "G-Pct", "GamesPct", True, "0.000")
				PrepareDataView(dgOpponentSummary, PlayerOpponentSummaryList.GetPlayerEventSummaryList(1))
            End If
        Catch ex As Exception
            log.Warn("tabOpponentSummary_Layout failed", ex)
        End Try
    End Sub

    Private Sub tabOpponentSummary_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabOpponentSummary.GotFocus
        dgOpponentSummary.Focus()
    End Sub

    Private Sub tabOpponentSummary_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabOpponentSummary.Enter
        dgOpponentSummary.Focus()
    End Sub

    Private Sub dgOpponentSummary_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgOpponentSummary.CellMouseDoubleClick
        Try
            If e.ColumnIndex = 0 Then
                Dim list As PlayerOpponentSummaryList = DirectCast(dgOpponentSummary.DataSource, PlayerOpponentSummaryList)
                EditObject(Player.Fetch(list(e.RowIndex).ID))
            End If
        Catch ex As Exception
            log.Error("dgOpponentSummary_CellMouseDoubleClick", ex)
        End Try
    End Sub

    Private Sub dgOpponentSummary_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgOpponentSummary.Paint
        tabOpponentSummary_InitializeGrid()
    End Sub
#End Region

#Region "Match History"
    Private _FullMatchList As PlayerMatchList
    Private _DisplayMatchList As PlayerMatchList

    Private Sub RefreshMatchHistoryDisplay(ByVal MatchRange As String)
        Static LastMatchRange As String
        If MatchRange = LastMatchRange Then Return
        LastMatchRange = MatchRange
        Select Case MatchRange
            Case "Last 10"
                _DisplayMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 10)
            Case "Last Month"
                _DisplayMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Month)
            Case "Last 3 Months"
                _DisplayMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Quarter)
            Case "Last Year"
                _DisplayMatchList = PlayerMatchList.SelectRecentMatches(_FullMatchList, 1, DateInterval.Year)
            Case "All"
                _DisplayMatchList = _FullMatchList
            Case Else
                _DisplayMatchList = _FullMatchList
        End Select
        PrepareDataView(dgMatchList, _DisplayMatchList)
    End Sub

    Private Sub dgMatchList_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgMatchList.CellFormatting
        If e.ColumnIndex = 3 Then
            Dim list As PlayerMatchList = DirectCast(dgMatchList.DataSource, PlayerMatchList)
            If list(e.RowIndex).Result = "L" Then
                e.CellStyle.BackColor = Color.LightPink
            End If
        End If
    End Sub

    Private Sub dgMatchList_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgMatchList.CellMouseClick
        If e.RowIndex = -1 Then Return
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'MessageBox.Show(String.Format("you right-clicked a cell (row={0}, column={1})", e.RowIndex, e.ColumnIndex))
            dgMatchList.ClearSelection()
            Dim row As DataGridViewRow = dgMatchList.Rows(e.RowIndex)
            row.Selected = True
            MatchContextMenu.Show(Control.MousePosition)
        End If
    End Sub

    Private Sub dgMatchList_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgMatchList.CellMouseDoubleClick
        If e.RowIndex = -1 Then Return
        Dim list As PlayerMatchList = DirectCast(dgMatchList.DataSource, PlayerMatchList)
        Debug.WriteLine(dgMatchList.Columns(e.ColumnIndex).Name)
        Select Case dgMatchList.Columns(e.ColumnIndex).Name
            Case "MatchDate", "Score"
                log.Debug("Opening and displaying match")
                EditObject(Match.Fetch(list(e.RowIndex).ID))
                log.Debug("Opening and displaying match - complete")
            Case "EventName"
                log.Debug("Filtering matches by event")
                _DisplayMatchList = PlayerMatchList.SelectMatchesByEvent(_FullMatchList, list(e.RowIndex).EventID)
                PrepareDataView(dgMatchList, _DisplayMatchList)
            Case "OpponentName"
                log.Debug("Filtering matches by opponent")
                _DisplayMatchList = PlayerMatchList.SelectMatchesByOpponent(_FullMatchList, list(e.RowIndex).OpponentID)
                PrepareDataView(dgMatchList, _DisplayMatchList)
        End Select
    End Sub

	Private Sub DeleteMatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMatchToolStripMenuItem.Click
		If dgMatchList.SelectedRows.Count <> 1 Then
			MsgBox("Please select exactly one match to delete")
			Return
		End If

		Try
			Dim index As Integer = dgMatchList.SelectedRows(0).Index
			Dim list As PlayerMatchList = DirectCast(dgMatchList.DataSource, PlayerMatchList)
			Dim match As PlayerMatch = list(index)
			If DialogResult.Yes = MsgBox(String.Format("Are you sure you want to delete match: {0} vs. {1} on {2}", match.ResultScore, match.OpponentName, match.MatchDate), MsgBoxStyle.YesNo, "Confirm Delete") Then
				For Each row As DataGridViewRow In dgMatchList.SelectedRows
					TennisObjects.Match.Delete(match.ID)
				Next
			End If
		Catch ex As Exception
			log.Error("Failed to delete match", ex)
			MsgBox("Failed to delete match")
		End Try

	End Sub

	'Private Sub btnAddMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMatch.Click
	'    Dim match As Match = EditNewMatch()
	'    _FullMatchList = PlayerMatchList.GetPlayerMatchList
	'    RefreshMatchHistoryDisplay(cmbMatchRange.Text)
	'End Sub

    Private Sub cmbMatchRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMatchCount.SelectedIndexChanged, cmbEventTimeSpan.SelectedIndexChanged, ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged, cmbMatchRange.SelectedIndexChanged
        If cmbMatchRange.SelectedIndex = -1 Then Return
        RefreshMatchHistoryDisplay(cmbMatchRange.Text)
    End Sub


    Private Sub tabMatchHistory_InitializeGrid()
        If Not DataLayerReady() Then Return
        Try
            Dim dv As DataGridView = dgMatchList
            If dv.ColumnCount > 0 Then Return
            If dv.DataSource Is Nothing Then
                AddColumn(dv, "Date", "MatchDate")
                AddColumn(dv, "Event", "EventName")
                AddColumn(dv, "Opponent", "OpponentName")
                'AddColumn(dv, "Result", "Result")
                AddColumn(dv, "Score", "ResultScore")
                With dv.Columns("ResultScore")
                    .DefaultCellStyle.Font = New Font("Courier New", 8)
                    .DefaultCellStyle.BackColor = Color.LightGreen
                End With
                _FullMatchList = PlayerMatchList.GetPlayerMatchList
                RefreshMatchHistoryDisplay("Last 10")
                cmbMatchRange.SelectedIndex = 0

                'attaching the context menu to each cell works, but it doesn't seem to highlight 
                'the clicked cell or give us the opportunity to do anything else
                'For Each row As DataGridViewRow In dv.Rows
                '    row.ContextMenuStrip = MatchContextMenu
                'Next
            End If
            dv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dv.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
        Catch ex As Exception
            log.Warn("tabMatchHistory_InitializeGrid failed", ex)
        End Try
    End Sub

    Private Sub tabMatchHistory_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tabMatchHistory.Paint
        tabMatchHistory_InitializeGrid()
    End Sub
#End Region

#Region "Player List"
    Private Sub tabPlayerList_InitializeGrid()
        If Not DataLayerReady() Then Return
        Try
            If dgPlayerList.ColumnCount > 0 Then Return
            If dgPlayerList.DataSource Is Nothing Then
                AddColumn(dgPlayerList, "ID", "ID")
                AddColumn(dgPlayerList, "First Name", "FirstName")
                AddColumn(dgPlayerList, "Last Name", "LastName")
                PrepareDataView(dgPlayerList, PlayerList.GetList())
            End If
        Catch ex As Exception
            log.Warn("tabPlayerList_InitializeGrid failed", ex)
        End Try
    End Sub

    Private Sub tabPlayerList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabPlayerList.Enter
        dgPlayerList.Focus()
    End Sub

    Private Sub dgPlayerList_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgPlayerList.CellMouseDoubleClick

    End Sub

    Private Sub dgPlayerList_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dgPlayerList.Paint
        tabPlayerList_InitializeGrid()
    End Sub
#End Region

End Class
