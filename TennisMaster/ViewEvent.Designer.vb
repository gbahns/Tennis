Partial Public Class ViewEvent
    Inherits BaseForm

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()
        log.Debug("ViewEvent constructor")

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        log.Debug("ViewEvent constructor complete")
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal obj As TennisEvent)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewEvent))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtBeginDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.ClassificationContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewClassificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditClassificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmbClassification = New System.Windows.Forms.ComboBox
        Me.chkTeamPlay = New System.Windows.Forms.CheckBox
        'Me.leftRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.rightRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.topRaftingContainer = New System.Windows.Forms.RaftingContainer
        'Me.bottomRaftingContainer = New System.Windows.Forms.RaftingContainer
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.chkLeague = New System.Windows.Forms.CheckBox
        Me.chkTournament = New System.Windows.Forms.CheckBox
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ClassificationContextMenu.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Event &Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "&Begin Date"
        '
        'dtBeginDate
        '
        Me.dtBeginDate.Checked = False
        Me.dtBeginDate.CustomFormat = "MM/dd/yyyy"
        Me.dtBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtBeginDate.Location = New System.Drawing.Point(14, 134)
        Me.dtBeginDate.Name = "dtBeginDate"
        Me.dtBeginDate.ShowCheckBox = True
        Me.dtBeginDate.Size = New System.Drawing.Size(98, 20)
        Me.dtBeginDate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ContextMenuStrip = Me.ClassificationContextMenu
        Me.Label3.Location = New System.Drawing.Point(14, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "&Classification"
        '
        'ClassificationContextMenu
        '
        Me.ClassificationContextMenu.AllowDrop = True
        Me.ClassificationContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEventToolStripMenuItem, Me.NewClassificationToolStripMenuItem, Me.EditClassificationToolStripMenuItem})
        Me.ClassificationContextMenu.Location = New System.Drawing.Point(24, 57)
        Me.ClassificationContextMenu.Name = "ContextMenuStrip1"
        Me.ClassificationContextMenu.Size = New System.Drawing.Size(151, 70)
        '
        'AddEventToolStripMenuItem
        '
        Me.AddEventToolStripMenuItem.Name = "AddEventToolStripMenuItem"
        'Me.AddEventToolStripMenuItem.SettingsKey = "ViewEvent.AddEventToolStripMenuItem"
        Me.AddEventToolStripMenuItem.Text = "Add Classification"
        '
        'NewClassificationToolStripMenuItem
        '
        Me.NewClassificationToolStripMenuItem.Name = "NewClassificationToolStripMenuItem"
        'Me.NewClassificationToolStripMenuItem.SettingsKey = "ViewEvent.NewClassificationToolStripMenuItem"
        Me.NewClassificationToolStripMenuItem.Text = "New Classification"
        '
        'EditClassificationToolStripMenuItem
        '
        Me.EditClassificationToolStripMenuItem.Name = "EditClassificationToolStripMenuItem"
        'Me.EditClassificationToolStripMenuItem.SettingsKey = "ViewEvent.EditEventToolStripMenuItem"
        Me.EditClassificationToolStripMenuItem.Text = "Edit Classification"
        '
        'cmbClassification
        '
        Me.cmbClassification.ContextMenuStrip = Me.ClassificationContextMenu
        Me.cmbClassification.FormattingEnabled = True
        Me.cmbClassification.Location = New System.Drawing.Point(14, 76)
        Me.cmbClassification.Name = "cmbClassification"
        Me.cmbClassification.Size = New System.Drawing.Size(206, 21)
        Me.cmbClassification.TabIndex = 3
        '
        'chkTeamPlay
        '
        Me.chkTeamPlay.AutoSize = True
        Me.chkTeamPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTeamPlay.Location = New System.Drawing.Point(163, 183)
        Me.chkTeamPlay.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.chkTeamPlay.Name = "chkTeamPlay"
        Me.chkTeamPlay.Size = New System.Drawing.Size(65, 16)
        Me.chkTeamPlay.TabIndex = 10
        Me.chkTeamPlay.Text = "&Team Play"
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
        'dtEndDate
        '
        Me.dtEndDate.Checked = False
        Me.dtEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(130, 134)
        Me.dtEndDate.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.ShowCheckBox = True
        Me.dtEndDate.Size = New System.Drawing.Size(98, 20)
        Me.dtEndDate.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(130, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&End Date"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(14, 27)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(206, 20)
        Me.txtName.TabIndex = 1
        '
        'chkLeague
        '
        Me.chkLeague.AutoSize = True
        Me.chkLeague.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLeague.Location = New System.Drawing.Point(14, 183)
        Me.chkLeague.Name = "chkLeague"
        Me.chkLeague.Size = New System.Drawing.Size(52, 16)
        Me.chkLeague.TabIndex = 8
        Me.chkLeague.Text = "&League"
        '
        'chkTournament
        '
        Me.chkTournament.AutoSize = True
        Me.chkTournament.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTournament.Location = New System.Drawing.Point(79, 183)
        Me.chkTournament.Name = "chkTournament"
        Me.chkTournament.Size = New System.Drawing.Size(71, 16)
        Me.chkTournament.TabIndex = 9
        Me.chkTournament.Text = "&Tournament"
        '
        'ViewEvent
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(236, 267)
        Me.Controls.Add(Me.chkTournament)
        Me.Controls.Add(Me.chkLeague)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.dtEndDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkTeamPlay)
        Me.Controls.Add(Me.cmbClassification)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtBeginDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        'Me.Controls.Add(Me.leftRaftingContainer)
        'Me.Controls.Add(Me.rightRaftingContainer)
        'Me.Controls.Add(Me.topRaftingContainer)
        'Me.Controls.Add(Me.bottomRaftingContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewEvent"
        Me.ShowInTaskbar = False
        Me.Text = "Event"
        'Me.Controls.SetChildIndex(Me.bottomRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.topRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.rightRaftingContainer, 0)
        'Me.Controls.SetChildIndex(Me.leftRaftingContainer, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.dtBeginDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmbClassification, 0)
        Me.Controls.SetChildIndex(Me.chkTeamPlay, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.dtEndDate, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.chkLeague, 0)
        Me.Controls.SetChildIndex(Me.chkTournament, 0)
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ClassificationContextMenu.ResumeLayout(False)
        'CType(Me.leftRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.rightRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.topRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.bottomRaftingContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtBeginDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbClassification As System.Windows.Forms.ComboBox
    Friend WithEvents chkTeamPlay As System.Windows.Forms.CheckBox
    'Friend WithEvents leftRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents rightRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents topRaftingContainer As System.Windows.Forms.RaftingContainer
    'Friend WithEvents bottomRaftingContainer As System.Windows.Forms.RaftingContainer
    Friend WithEvents ClassificationContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddEventToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditClassificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents NewClassificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkLeague As System.Windows.Forms.CheckBox
    Friend WithEvents chkTournament As System.Windows.Forms.CheckBox
End Class
