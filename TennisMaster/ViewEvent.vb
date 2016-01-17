Public Class ViewEvent

    'Private WithEvents Event As Event
    Public Property [Event]() As TennisEvent
        Get
            Return DirectCast(_BusinessObject, TennisEvent)
        End Get
        Set(ByVal value As TennisEvent)
            _BusinessObject = value
        End Set
    End Property

    Private Shared _ClassificationList As ClassificationList

#Region "Helper Methods"
    Private ReadOnly Property Classifications() As ClassificationList
        Get
            If _ClassificationList Is Nothing Then
                _ClassificationList = ClassificationList.GetList()
            End If
            Return _ClassificationList
        End Get
    End Property

    Private Function GetClassificationStrings() As AutoCompleteStringCollection
        Dim strings As New AutoCompleteStringCollection
        For Each Classification As Classification In Classifications
            strings.Add(Classification.Name)
        Next
        Return strings
    End Function

    Private Sub ConfigureAutoComplete(ByVal comboBox As ComboBox, ByVal strings As AutoCompleteStringCollection)
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        comboBox.AutoCompleteCustomSource = strings
    End Sub
#End Region

    Protected Overrides Sub DataBind()
        MyBase.DataBind()

        BindField(txtName, "Text", [Event], "Name")
        BindField(cmbClassification, "SelectedValue", [Event], "ClassificationID", Classifications, "ID", "Name")
        BindField(dtBeginDate, "Text", [Event], "BeginDateText")
        BindField(dtEndDate, "Text", [Event], "EndDateText")
        BindField(chkLeague, "Checked", [Event], "IsLeague")
        BindField(chkTournament, "Checked", [Event], "IsTournament")
        BindField(chkTeamPlay, "Checked", [Event], "TeamPlay")

        ConfigureAutoComplete(cmbClassification, GetClassificationStrings)
    End Sub

    Private Sub ViewEvent_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        txtName.Focus()
    End Sub

    Private Sub ViewEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Return

        log.Debug("loading event " & [Event].ToString)

        Me.Text = IIf([Event].IsNew, "New Event", String.Format("Event {0}", [Event]))

        'todo: check the user's role to see if they have rights to view or edit players
        'some user's have rights to edit themselves only
        'some have rights to edit members of their team

        InfoMessage = "View event or make desired changes"

        log.Debug("event loaded")

        txtName.Focus()
    End Sub


    ''' <summary>
    ''' Handle the validating event for any of our combo boxes to ensure that auto-complete text gets
    ''' mapped to the correct item in the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbClassification.Validating
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        'log.Info(String.Format("{5}_Validating: SelectedIndex={0}, SelectedItem={1}, SelectedText={2}, SelectedValue={3}, Text={4}", cmb.SelectedIndex, cmb.SelectedItem, cmb.SelectedText, cmb.SelectedValue, cmb.Text, cmb.Name))
        If cmb.SelectedIndex = -1 And cmb.Text.Length > 0 Then
            cmb.SelectedIndex = cmb.FindString(cmb.Text)
        End If
    End Sub

    Private Sub NewClassificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewClassificationToolStripMenuItem.Click
        EditNewClassification()
    End Sub

    Private Sub EditClassificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditClassificationToolStripMenuItem.Click
        'EditClassification()
    End Sub
End Class