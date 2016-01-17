Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class MDIParent

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click, NewToolStripButton.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt"
        OpenFileDialog.ShowDialog(Me)

        Dim FileName As String = OpenFileDialog.FileName
        MsgBox(String.Format("<TODO: Add code to open {0}>", FileName))
    End Sub

    Private Sub SaveFile(ByVal sender As Object, ByVal e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        MsgBox("<TODO: Add code to save the currently open file.>")
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt"
        SaveFileDialog.ShowDialog(Me)

        Dim FileName As String = SaveFileDialog.FileName
        MsgBox(String.Format("<TODO: Add code to save the currently open file as {0}>", FileName))
    End Sub

    Private Sub Print(ByVal ShowPreview As Boolean)
        MsgBox("<TODO: Add code to print the currently open file.>")
    End Sub

    Private Sub Print(ByVal sender As Object, ByVal e As EventArgs) Handles PrintToolStripMenuItem.Click, PrintToolStripButton.Click
        Print(False)
    End Sub

    Private Sub PrintPreview(ByVal sender As Object, ByVal e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click, PrintPreviewToolStripButton.Click
        Print(True)
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrintSetupToolStripMenuItem.Click
        MsgBox("<TODO: Add code to bring up the Printer Setup dialog>")
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        'My.Application.Exit()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UndoToolStripMenuItem.Click
        MsgBox("<TODO: Add code to undo the most recent action>")
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RedoToolStripMenuItem.Click
        MsgBox("<TODO: Add code to redo the most recent action>")
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText("Cut Item")
        MsgBox("<TODO: Add code to cut an item and place it in the clipboard>")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText("Copy Item")
        MsgBox("<TODO: Add code to copy an item and place it in the clipboard>")
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        Dim ClipboardText As String = My.Computer.Clipboard.GetText()
        MsgBox(String.Format("<TODO: Add code to paste this text: '{0}'>", ClipboardText))
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        MsgBox("<TODO: Add code to select all the available items>")
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OptionsToolStripMenuItem.Click
        MsgBox("<TODO: Add code to show option dialog>")
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms(i).MdiParent Is Me Then
                My.Application.OpenForms(i).Close()
            End If
        Next
    End Sub

    Private Sub ShowContents(ByVal sender As Object, ByVal e As EventArgs) Handles ContentsToolStripMenuItem.Click, HelpToolStripButton.Click
        MsgBox("<TODO: Add code to show the help content>")
    End Sub

    Private Sub IndexToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IndexToolStripMenuItem.Click
        MsgBox("<TODO: Add code to show the help index>")
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SearchToolStripMenuItem.Click
        MsgBox("<TODO: Add code to show the help search dialog>")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("<TODO: Add an AboutBox form and code to show the form>")
    End Sub

    Private Sub EventListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EventListToolStripMenuItem.Click

    End Sub

    Private Sub PlayerListToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PlayerListToolStripMenuItem.Click
        ViewPlayerList.Show(Me)
    End Sub

    Private Sub ViewMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMenu.Click

    End Sub

    'Private Sub PlayerListToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerListToolStripButton.Click
    '    ViewPlayerList.Show(Me)
    'End Sub

	Private Sub MDIParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		log.Debug("MDI Parent closing" & Chr(13) & Chr(10) & _
		"----------------------------------------------------------------------------------------------------")
	End Sub

    Private Sub MDIParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not DataLayerReady() Then Return

        log4net.Config.DOMConfigurator.ConfigureAndWatch(New IO.FileInfo("log.config"))
        log.Debug("MDI Parent loading")

        Try
            Login()

            Util.MdiParent = Me

            'todo: move the opening of the MainForm to Util.vb
            'Dim frm As New MainForm
            'frm.MdiParent = Me
            'frm.Show()
        Catch ex As Exception
            log.Error("Unable to complete login process", ex)
            MessageBox.Show("The login process failed; shutting down", "Login failed")
            Me.Close()
        End Try
    End Sub

    Private Sub MenuStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStrip.Click

    End Sub

    Private Sub NewPlayerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewPlayerToolStripMenuItem.Click
		Dim obj As Player = EditObject(TennisObjects.Player.Create())
    End Sub

    Private Sub EditMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMenu.Click

    End Sub

    Private Sub ViewClassificationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewClassificationsToolStripMenuItem.Click
        Dim frm As New ClassificationListForm
        frm.MdiParent = Me
        frm.Show()
        'ClassificationListForm.ShowDialog()
    End Sub

    Private Sub AddMatchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMatchToolStripButton.Click
        EditObject(Match.Create())
    End Sub

    Private Sub AddEventToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEventToolStripButton.Click
        EditObject(TennisEvent.Create())
    End Sub

End Class
