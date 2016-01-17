Partial Public Class ViewMatch
    Inherits BaseForm

    '<System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()
        log.Debug("ViewMatch constructor")

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        log.Debug("ViewMatch constructor complete")
    End Sub

    '<System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal obj As Match)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _BusinessObject = obj
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewMatch))
        Me.cmbEvent = New Tennis.Master.AutoComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtMatchDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbWinner = New Tennis.Master.AutoComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbLoser = New Tennis.Master.AutoComboBox
        Me.chkLoserDefaulted = New System.Windows.Forms.CheckBox
        Me.set1 = New Tennis.Master.SetScoreTextBoxes
        Me.set2 = New Tennis.Master.SetScoreTextBoxes
        Me.set3 = New Tennis.Master.SetScoreTextBoxes
        Me.set4 = New Tennis.Master.SetScoreTextBoxes
        Me.set5 = New Tennis.Master.SetScoreTextBoxes
        Me.pnlSetControls = New System.Windows.Forms.Panel
        'Me.leftRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.rightRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.topRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.bottomRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.AddPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeletePlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LastNamesFirstToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSetControls.SuspendLayout()
        'CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.rightRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_tooltip
        '
        Me._tooltip.AutoPopDelay = 5000
        Me._tooltip.InitialDelay = 1000
        Me._tooltip.ReshowDelay = 500
        Me._tooltip.ShowAlways = True
        '
        'cmbEvent
        '
        Me.cmbEvent.AutoCompleteMode = CType((System.Windows.Forms.AutoCompleteMode.Suggest Or System.Windows.Forms.AutoCompleteMode.Append), System.Windows.Forms.AutoCompleteMode)
        Me.cmbEvent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbEvent.FormattingEnabled = True
        Me.cmbEvent.ItemName = "Event"
        Me.cmbEvent.Location = New System.Drawing.Point(14, 26)
        Me.cmbEvent.MaxDropDownItems = 20
        Me.cmbEvent.Name = "cmbEvent"
        Me.cmbEvent.Size = New System.Drawing.Size(206, 21)
        Me.cmbEvent.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Event"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Date"
        '
        'dtMatchDate
        '
        Me.dtMatchDate.CustomFormat = "M/d/yyyy hh:mm tt"
        Me.dtMatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtMatchDate.Location = New System.Drawing.Point(241, 27)
        Me.dtMatchDate.Name = "dtMatchDate"
        Me.dtMatchDate.Size = New System.Drawing.Size(206, 20)
        Me.dtMatchDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Winner"
        '
        'cmbWinner
        '
        Me.cmbWinner.AutoCompleteMode = CType((System.Windows.Forms.AutoCompleteMode.Suggest Or System.Windows.Forms.AutoCompleteMode.Append), System.Windows.Forms.AutoCompleteMode)
        Me.cmbWinner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbWinner.FormattingEnabled = True
        Me.cmbWinner.ItemName = ""
        Me.cmbWinner.Location = New System.Drawing.Point(14, 76)
        Me.cmbWinner.Name = "cmbWinner"
        Me.cmbWinner.Size = New System.Drawing.Size(206, 21)
        Me.cmbWinner.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&Loser"
        '
        'cmbLoser
        '
        Me.cmbLoser.AutoCompleteMode = CType((System.Windows.Forms.AutoCompleteMode.Suggest Or System.Windows.Forms.AutoCompleteMode.Append), System.Windows.Forms.AutoCompleteMode)
        Me.cmbLoser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbLoser.FormattingEnabled = True
        Me.cmbLoser.ItemName = ""
        Me.cmbLoser.Location = New System.Drawing.Point(241, 76)
        Me.cmbLoser.Name = "cmbLoser"
        Me.cmbLoser.Size = New System.Drawing.Size(206, 21)
        Me.cmbLoser.TabIndex = 7
        '
        'chkLoserDefaulted
        '
        Me.chkLoserDefaulted.AutoSize = True
        Me.chkLoserDefaulted.Location = New System.Drawing.Point(350, 114)
        Me.chkLoserDefaulted.Name = "chkLoserDefaulted"
        Me.chkLoserDefaulted.Size = New System.Drawing.Size(97, 17)
        Me.chkLoserDefaulted.TabIndex = 9
        Me.chkLoserDefaulted.Text = "Loser De&faulted"
        '
        'set1
        '
        Me.set1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.set1.Location = New System.Drawing.Point(4, 14)
        Me.set1.Name = "set1"
        Me.set1.SetNumber = 1
        Me.set1.Size = New System.Drawing.Size(223, 20)
        Me.set1.TabIndex = 0
        '
        'set2
        '
        Me.set2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.set2.Location = New System.Drawing.Point(4, 41)
        Me.set2.Name = "set2"
        Me.set2.SetNumber = 2
        Me.set2.Size = New System.Drawing.Size(223, 20)
        Me.set2.TabIndex = 1
        '
        'set3
        '
        Me.set3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.set3.Location = New System.Drawing.Point(4, 68)
        Me.set3.Name = "set3"
        Me.set3.SetNumber = 3
        Me.set3.Size = New System.Drawing.Size(223, 20)
        Me.set3.TabIndex = 2
        '
        'set4
        '
        Me.set4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.set4.Location = New System.Drawing.Point(4, 95)
        Me.set4.Name = "set4"
        Me.set4.SetNumber = 4
        Me.set4.Size = New System.Drawing.Size(223, 20)
        Me.set4.TabIndex = 3
        '
        'set5
        '
        Me.set5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.set5.Location = New System.Drawing.Point(4, 122)
        Me.set5.Name = "set5"
        Me.set5.SetNumber = 5
        Me.set5.Size = New System.Drawing.Size(223, 20)
        Me.set5.TabIndex = 4
        '
        'pnlSetControls
        '
        Me.pnlSetControls.Controls.Add(Me.set5)
        Me.pnlSetControls.Controls.Add(Me.set4)
        Me.pnlSetControls.Controls.Add(Me.set3)
        Me.pnlSetControls.Controls.Add(Me.set2)
        Me.pnlSetControls.Controls.Add(Me.set1)
        Me.pnlSetControls.Location = New System.Drawing.Point(10, 114)
        Me.pnlSetControls.Name = "pnlSetControls"
        Me.pnlSetControls.Size = New System.Drawing.Size(232, 154)
        Me.pnlSetControls.TabIndex = 8
        '
        'leftRaftingContainer
        '
        'Me.leftRaftingContainer.Dock = System.Windows.Forms.DockStyle.Left
        'Me.leftRaftingContainer.Name = "leftRaftingContainer"
        '
        'rightRaftingContainer
        '
        'Me.rightRaftingContainer.Dock = System.Windows.Forms.DockStyle.Right
        'Me.rightRaftingContainer.Name = "rightRaftingContainer"
        '
        'topRaftingContainer
        '
        'Me.topRaftingContainer.Dock = System.Windows.Forms.DockStyle.Top
        'Me.topRaftingContainer.Name = "topRaftingContainer"
        '
        'bottomRaftingContainer
        '
        'Me.bottomRaftingContainer.Dock = System.Windows.Forms.DockStyle.Bottom
        'Me.bottomRaftingContainer.Name = "bottomRaftingContainer"
        '
        'AddPlayerToolStripMenuItem
        '
        Me.AddPlayerToolStripMenuItem.Name = "AddPlayerToolStripMenuItem"
        'Me.AddPlayerToolStripMenuItem.SettingsKey = "ViewMatch.AddPlayerToolStripMenuItem"
        Me.AddPlayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert
        Me.AddPlayerToolStripMenuItem.Text = "Add Player"
        '
        'EditPlayerToolStripMenuItem
        '
        Me.EditPlayerToolStripMenuItem.Name = "EditPlayerToolStripMenuItem"
        'Me.EditPlayerToolStripMenuItem.SettingsKey = "ViewMatch.EditPlayerToolStripMenuItem"
        Me.EditPlayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.EditPlayerToolStripMenuItem.Text = "Edit Player"
        '
        'DeletePlayerToolStripMenuItem
        '
        Me.DeletePlayerToolStripMenuItem.Name = "DeletePlayerToolStripMenuItem"
        'Me.DeletePlayerToolStripMenuItem.SettingsKey = "ViewMatch.DeletePlayerToolStripMenuItem"
        Me.DeletePlayerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.DeletePlayerToolStripMenuItem.Text = "Delete Player"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        'Me.ToolStripSeparator1.SettingsKey = "ViewMatch.ToolStripSeparator1"
        '
        'LastNamesFirstToolStripMenuItem
        '
        Me.LastNamesFirstToolStripMenuItem.CheckOnClick = True
        Me.LastNamesFirstToolStripMenuItem.Name = "LastNamesFirstToolStripMenuItem"
        'Me.LastNamesFirstToolStripMenuItem.SettingsKey = "ViewMatch.LastNamesFirstToolStripMenuItem"
        Me.LastNamesFirstToolStripMenuItem.Text = "Last Names First"
        '
        'ViewMatch
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(462, 290)
        Me.Controls.Add(Me.pnlSetControls)
        Me.Controls.Add(Me.chkLoserDefaulted)
        Me.Controls.Add(Me.cmbLoser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbWinner)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtMatchDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbEvent)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.leftRaftingContainer)
        'Me.Controls.Add(Me.rightRaftingContainer)
        'Me.Controls.Add(Me.topRaftingContainer)
        'Me.Controls.Add(Me.bottomRaftingContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewMatch"
        Me.ShowInTaskbar = False
        Me.Text = "Match"
        'Me.Controls.SetChildIndex(Me.bottomRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.topRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.rightRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.leftRaftingContainer, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbEvent, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dtMatchDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbWinner, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cmbLoser, 0)
        Me.Controls.SetChildIndex(Me.chkLoserDefaulted, 0)
        Me.Controls.SetChildIndex(Me.pnlSetControls, 0)
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSetControls.ResumeLayout(False)
        'CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.rightRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEvent As AutoComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtMatchDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbWinner As AutoComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbLoser As AutoComboBox
    Friend WithEvents chkLoserDefaulted As System.Windows.Forms.CheckBox
    Friend WithEvents set1 As Tennis.Master.SetScoreTextBoxes
    Friend WithEvents set2 As Tennis.Master.SetScoreTextBoxes
    Friend WithEvents set3 As Tennis.Master.SetScoreTextBoxes
    Friend WithEvents set4 As Tennis.Master.SetScoreTextBoxes
    Friend WithEvents set5 As Tennis.Master.SetScoreTextBoxes
    Friend WithEvents pnlSetControls As System.Windows.Forms.Panel
    'Friend WithEvents leftRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents rightRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents topRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents bottomRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents AddPlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletePlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LastNamesFirstToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
