Public Class ViewMatch

    'for information on formatting dates:
    'ms-help://MS.VSCC.v80/MS.MSDNQTR.v80.en/MS.MSDN.v80/MS.VisualStudio.v80.en/dv_fxfund/html/98b374e3-0cc2-4c78-ab44-efb671d71984.htm

#Region " Data Members"
    Public Property Match() As Match
        Get
            Return DirectCast(_BusinessObject, Match)
        End Get
        Set(ByVal value As Match)
            _BusinessObject = value
        End Set
    End Property

    Private WithEvents ShowAllEventsMenuItem As ToolStripMenuItem
    Private WithEvents ShowAllLeagueEventsMenuItem As ToolStripMenuItem
    Private WithEvents ShowAllTournamentEventsMenuItem As ToolStripMenuItem

    Private WithEvents ShowLastNamesFirstMenuItem As ToolStripMenuItem
#End Region

#Region " Helper Methods"
    Protected Overrides Sub DataBind()
        MyBase.DataBind()

        BindField(Me, "Text", Match, "ResultString")

        BindField(cmbEvent, Match, "EventID", "Events", "ID", "Name")
        BindField(dtMatchDate, "Text", Match, "MatchDate")
        BindField(cmbWinner, Match, "WinnerID", "Winners", "ID", "FullName")
        BindField(cmbLoser, Match, "LoserID", "Losers", "ID", "FullName")

        For Each SetScore As SetScoreTextBoxes In pnlSetControls.Controls
            BindField(SetScore.txtWGames, "Text", Match.Score.Sets(SetScore.SetNumber - 1), "WGames")
            BindField(SetScore.txtLGames, "Text", Match.Score.Sets(SetScore.SetNumber - 1), "LGames")
            BindField(SetScore.txtWTiebreak, "Text", Match.Score.Sets(SetScore.SetNumber - 1), "WTiebreak")
            BindField(SetScore.txtLTiebreak, "Text", Match.Score.Sets(SetScore.SetNumber - 1), "LTiebreak")

            Util.BindField(SetScore, "Visible", Match.Score.ShowSet(SetScore.SetNumber - 1), "")
        Next

        BindField(Me.chkLoserDefaulted, "Checked", Match.Score, "LoserDefaulted")

        'UI enabledness
        'BindField(DeleteEventToolStripMenuItem, "Enabled", cmbEvent, "SelectedIndex > -1")
    End Sub

#End Region

#Region " Form Events"
    Private Sub ViewMatch_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        cmbEvent.Focus()
    End Sub

    Private Sub ViewMatch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Return

        log.Debug("loading match " & Match.ToString)

        'Me.Text = Match.ToString()

        'todo: check the user's role to see if they have rights to view or edit players
        'some user's have rights to edit themselves only
        'some have rights to edit members of their team

        InfoMessage = "View match or make desired changes"

        log.Debug("match loaded")

        With cmbEvent
            .AddMenuSeparator()
            ShowAllEventsMenuItem = .AddMenuCheck("ShowAll", "Show All", Keys.Alt Or Keys.A)
            ShowAllLeagueEventsMenuItem = .AddMenuCheck("ShowAllLeagues", "Show All Leagues", Keys.Alt Or Keys.L)
            ShowAllTournamentEventsMenuItem = .AddMenuCheck("ShowAllTournaments", "Show All Tournaments", Keys.Alt Or Keys.T)
        End With

        With cmbWinner
            .AddMenuSeparator()
            ShowLastNamesFirstMenuItem = .AddMenuCheck("ShowLastNamesFirst", "Last Names First")
        End With

        With cmbLoser
            .AddMenuSeparator()
            ShowLastNamesFirstMenuItem = .AddMenuCheck("ShowLastNamesFirst", "Last Names First")
        End With

        cmbEvent.Focus()
    End Sub
#End Region

#Region " Match Score Events"
    Private Function GetSet(ByVal setIndex As Integer) As SetScoreTextBoxes
        For Each SetScore As SetScoreTextBoxes In pnlSetControls.Controls
            If SetScore.SetNumber = setIndex Then Return SetScore
        Next
        'Return Nothing
        Throw New ArgumentOutOfRangeException("setIndex", setIndex, "The set index must be from 1 to 5")
    End Function

    Private Sub Match_ScoreChanged(ByVal sender As SetScoreTextBoxes, ByVal e As System.EventArgs) Handles set1.ScoreChanged, set2.ScoreChanged, set3.ScoreChanged, set4.ScoreChanged, set5.ScoreChanged
        'if the set score was changed to 0-0, the following set should be hidden
        If sender.SetNumber < 5 Then
            Dim NextSet As SetScoreTextBoxes = GetSet(sender.SetNumber + 1)
            NextSet.Visible = sender.ShowNextSet
            'sender.Focus()
        End If
    End Sub
#End Region

#Region " Player ComboBox Events"
    Private Sub cmbPlayer_AddItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbWinner.AddItem, cmbLoser.AddItem
		Dim obj As Player = EditObject(TennisObjects.Player.Create(IIf(sender.SelectedIndex = -1, sender.Text, "")))
        If obj Is Nothing Then
            InfoMessage = ""
        Else
            InfoMessage = String.Format("Player '{0}' added", obj.FullName)
        End If
    End Sub

    Private Sub cmbPlayer_EditItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbWinner.EditItem, cmbLoser.EditItem
        Dim name As String = sender.Text
        Try
            EditObject(Player.Fetch(CInt(sender.SelectedValue)))
            InfoMessage = String.Format("Player '{0}' updated", name)
        Catch ex As Exception
            log.Warn(String.Format("Unable to update player '{0}'", name), ex)
            ErrorMessage = "Unable to update player"
        End Try
    End Sub

    Private Sub cmbPlayer_DeleteItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbWinner.DeleteItem, cmbLoser.DeleteItem
        Dim name As String = sender.Text
        Try
            If Windows.Forms.DialogResult.OK = MessageBox.Show(String.Format("Are you sure you want to delete player '{0}'?", name), _
                "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) Then
                Player.Delete(CInt(sender.SelectedValue))
                InfoMessage = String.Format("Player '{0}' deleted", name)
            End If
        Catch ex As Exception
            'typically the reason for failure is foreign key constraint when 
            'there are existing matches for the player
            log.Warn(String.Format("Unable to delete player '{0}'", name), ex)
            ErrorMessage = "Unable to delete player"
        End Try
    End Sub

    Private Sub LastNamesFirstToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LastNamesFirstToolStripMenuItem.Click
        'Match.PlayerLastNamesFirst = LastNamesFirstToolStripMenuItem.Checked
    End Sub
#End Region

#Region " Event ComboBox Events"
    Private Sub cmbEvent_AddItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbEvent.AddItem
		Dim obj As TennisEvent = EditObject(TennisObjects.TennisEvent.Create(IIf(sender.SelectedIndex = -1, sender.Text, "")))
        If obj Is Nothing Then
            InfoMessage = ""
        Else
            InfoMessage = String.Format("Event '{0}' added", obj.Name)
        End If
    End Sub

    Private Sub cmbEvent_EditItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbEvent.EditItem
        Dim name As String = sender.Text
        Try
            EditObject(TennisEvent.Fetch(CInt(sender.SelectedValue)))
            InfoMessage = String.Format("Event '{0}' updated", name)
        Catch ex As Exception
            log.Warn("Unable to update event", ex)
            ErrorMessage = String.Format("Unable to update event '{0}'", name)
        End Try
    End Sub

    Private Sub cmbEvent_DeleteItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs) Handles cmbEvent.DeleteItem
        Dim name As String = sender.Text
        Try
            If Windows.Forms.DialogResult.OK = MessageBox.Show(String.Format("Are you sure you want to delete event '{0}'?", name), _
                "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) Then
                TennisEvent.Delete(CInt(sender.SelectedValue))
                InfoMessage = String.Format("Event '{0}' deleted", name)
            End If
        Catch ex As Exception
            'typically the reason for failure is foreign key constraint when 
            'there are existing matches for the event
            log.Warn(String.Format("Unable to delete event '{0}'", name), ex)
            ErrorMessage = "Unable to delete event"
        End Try
    End Sub

    Private Sub UpdateEventList()
        If ShowAllEventsMenuItem.Checked Then
            Match.FilterEvents(True, True)
        Else
            Match.FilterEvents(ShowAllLeagueEventsMenuItem.Checked, ShowAllTournamentEventsMenuItem.Checked)
        End If
    End Sub

    Private Sub ShowAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllEventsMenuItem.Click
        ShowAllLeagueEventsMenuItem.Checked = False
        ShowAllTournamentEventsMenuItem.Checked = False
        UpdateEventList()
    End Sub

    Private Sub ShowAllLeaguesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllLeagueEventsMenuItem.Click
        ShowAllEventsMenuItem.Checked = False
        ShowAllTournamentEventsMenuItem.Checked = False
        UpdateEventList()
    End Sub

    Private Sub ShowAllTournamentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowAllTournamentEventsMenuItem.Click
        ShowAllEventsMenuItem.Checked = False
        ShowAllLeagueEventsMenuItem.Checked = False
        UpdateEventList()
    End Sub
#End Region

End Class