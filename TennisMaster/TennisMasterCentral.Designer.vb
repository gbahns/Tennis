Partial Public Class TennisMasterCentral
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EventSummaryToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tabMainForm = New System.Windows.Forms.TabControl
        Me.tabEventSummary = New System.Windows.Forms.TabPage
        Me.cmbMatchCount = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbEventTimeSpan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgEventSummary = New System.Windows.Forms.DataGridView
        Me.tabOpponentSummary = New System.Windows.Forms.TabPage
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgOpponentSummary = New System.Windows.Forms.DataGridView
        Me.tabMatchHistory = New System.Windows.Forms.TabPage
        Me.cmbMatchRange = New System.Windows.Forms.ComboBox
        Me.lblMatchRange = New System.Windows.Forms.Label
        Me.dgMatchList = New System.Windows.Forms.DataGridView
        Me.tabPlayerList = New System.Windows.Forms.TabPage
        Me.dgPlayerList = New System.Windows.Forms.DataGridView
        Me.MatchContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tabMainForm.SuspendLayout()
        Me.tabEventSummary.SuspendLayout()
        CType(Me.dgEventSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOpponentSummary.SuspendLayout()
        CType(Me.dgOpponentSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMatchHistory.SuspendLayout()
        CType(Me.dgMatchList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPlayerList.SuspendLayout()
        CType(Me.dgPlayerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MatchContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'EventSummaryToolStripButton
        '
        Me.EventSummaryToolStripButton.Name = "EventSummaryToolStripButton"
        Me.EventSummaryToolStripButton.Size = New System.Drawing.Size(23, 23)
        Me.EventSummaryToolStripButton.Text = "Event Summary"
        '
        'tabMainForm
        '
        Me.tabMainForm.Controls.Add(Me.tabEventSummary)
        Me.tabMainForm.Controls.Add(Me.tabOpponentSummary)
        Me.tabMainForm.Controls.Add(Me.tabMatchHistory)
        Me.tabMainForm.Controls.Add(Me.tabPlayerList)
        Me.tabMainForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMainForm.Location = New System.Drawing.Point(0, 0)
        Me.tabMainForm.Name = "tabMainForm"
        Me.tabMainForm.SelectedIndex = 0
        Me.tabMainForm.Size = New System.Drawing.Size(653, 442)
        Me.tabMainForm.TabIndex = 1
        '
        'tabEventSummary
        '
        Me.tabEventSummary.Controls.Add(Me.cmbMatchCount)
        Me.tabEventSummary.Controls.Add(Me.Label2)
        Me.tabEventSummary.Controls.Add(Me.cmbEventTimeSpan)
        Me.tabEventSummary.Controls.Add(Me.Label1)
        Me.tabEventSummary.Controls.Add(Me.dgEventSummary)
        Me.tabEventSummary.Location = New System.Drawing.Point(4, 22)
        Me.tabEventSummary.Name = "tabEventSummary"
        Me.tabEventSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEventSummary.Size = New System.Drawing.Size(645, 416)
        Me.tabEventSummary.TabIndex = 0
        Me.tabEventSummary.Text = "Event Summary"
        '
        'cmbMatchCount
        '
        Me.cmbMatchCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatchCount.FormattingEnabled = True
        Me.cmbMatchCount.Items.AddRange(New Object() {"All", "At least 2", "At least 5", "At least 10"})
        Me.cmbMatchCount.Location = New System.Drawing.Point(137, 19)
        Me.cmbMatchCount.Name = "cmbMatchCount"
        Me.cmbMatchCount.Size = New System.Drawing.Size(105, 21)
        Me.cmbMatchCount.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Match Count"
        '
        'cmbEventTimeSpan
        '
        Me.cmbEventTimeSpan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEventTimeSpan.FormattingEnabled = True
        Me.cmbEventTimeSpan.Items.AddRange(New Object() {"Last 10", "Last Month", "Last 3 Months", "Last Year", "All"})
        Me.cmbEventTimeSpan.Location = New System.Drawing.Point(9, 19)
        Me.cmbEventTimeSpan.Name = "cmbEventTimeSpan"
        Me.cmbEventTimeSpan.Size = New System.Drawing.Size(121, 21)
        Me.cmbEventTimeSpan.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Time Span"
        '
        'dgEventSummary
        '
        Me.dgEventSummary.AllowUserToAddRows = False
        Me.dgEventSummary.AllowUserToDeleteRows = False
        Me.dgEventSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgEventSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgEventSummary.Location = New System.Drawing.Point(3, 47)
        Me.dgEventSummary.Name = "dgEventSummary"
        Me.dgEventSummary.ReadOnly = True
        Me.dgEventSummary.Size = New System.Drawing.Size(639, 366)
        Me.dgEventSummary.TabIndex = 1
        '
        'tabOpponentSummary
        '
        Me.tabOpponentSummary.Controls.Add(Me.ComboBox1)
        Me.tabOpponentSummary.Controls.Add(Me.Label3)
        Me.tabOpponentSummary.Controls.Add(Me.ComboBox2)
        Me.tabOpponentSummary.Controls.Add(Me.Label4)
        Me.tabOpponentSummary.Controls.Add(Me.dgOpponentSummary)
        Me.tabOpponentSummary.Location = New System.Drawing.Point(4, 22)
        Me.tabOpponentSummary.Name = "tabOpponentSummary"
        Me.tabOpponentSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOpponentSummary.Size = New System.Drawing.Size(645, 416)
        Me.tabOpponentSummary.TabIndex = 1
        Me.tabOpponentSummary.Text = "Opponent Summary"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"All", "At least 2", "At least 5", "At least 10"})
        Me.ComboBox1.Location = New System.Drawing.Point(137, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(105, 21)
        Me.ComboBox1.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Match Count"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Last 10", "Last Month", "Last 3 Months", "Last Year", "All"})
        Me.ComboBox2.Location = New System.Drawing.Point(9, 19)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Time Span"
        '
        'dgOpponentSummary
        '
        Me.dgOpponentSummary.AllowUserToAddRows = False
        Me.dgOpponentSummary.AllowUserToDeleteRows = False
        Me.dgOpponentSummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOpponentSummary.Location = New System.Drawing.Point(3, 47)
        Me.dgOpponentSummary.Name = "dgOpponentSummary"
        Me.dgOpponentSummary.ReadOnly = True
        Me.dgOpponentSummary.Size = New System.Drawing.Size(639, 366)
        Me.dgOpponentSummary.TabIndex = 0
        '
        'tabMatchHistory
        '
        Me.tabMatchHistory.Controls.Add(Me.cmbMatchRange)
        Me.tabMatchHistory.Controls.Add(Me.lblMatchRange)
        Me.tabMatchHistory.Controls.Add(Me.dgMatchList)
        Me.tabMatchHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabMatchHistory.Name = "tabMatchHistory"
        Me.tabMatchHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMatchHistory.Size = New System.Drawing.Size(645, 416)
        Me.tabMatchHistory.TabIndex = 2
        Me.tabMatchHistory.Text = "Match History"
        '
        'cmbMatchRange
        '
        Me.cmbMatchRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMatchRange.FormattingEnabled = True
        Me.cmbMatchRange.Items.AddRange(New Object() {"Last 10", "Last Month", "Last 3 Months", "Last Year", "All"})
        Me.cmbMatchRange.Location = New System.Drawing.Point(9, 19)
        Me.cmbMatchRange.Name = "cmbMatchRange"
        Me.cmbMatchRange.Size = New System.Drawing.Size(121, 21)
        Me.cmbMatchRange.TabIndex = 2
        '
        'lblMatchRange
        '
        Me.lblMatchRange.AutoSize = True
        Me.lblMatchRange.Location = New System.Drawing.Point(9, 7)
        Me.lblMatchRange.Name = "lblMatchRange"
        Me.lblMatchRange.Size = New System.Drawing.Size(58, 13)
        Me.lblMatchRange.TabIndex = 3
        Me.lblMatchRange.Text = "Time Span"
        '
        'dgMatchList
        '
        Me.dgMatchList.AllowUserToAddRows = False
        Me.dgMatchList.AllowUserToDeleteRows = False
        Me.dgMatchList.AllowUserToOrderColumns = True
        Me.dgMatchList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMatchList.CausesValidation = False
        Me.dgMatchList.Location = New System.Drawing.Point(0, 47)
        Me.dgMatchList.Name = "dgMatchList"
        Me.dgMatchList.ReadOnly = True
        Me.dgMatchList.ShowCellToolTips = False
        Me.dgMatchList.Size = New System.Drawing.Size(645, 369)
        Me.dgMatchList.TabIndex = 0
        '
        'tabPlayerList
        '
        Me.tabPlayerList.Controls.Add(Me.dgPlayerList)
        Me.tabPlayerList.Location = New System.Drawing.Point(4, 22)
        Me.tabPlayerList.Name = "tabPlayerList"
        Me.tabPlayerList.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPlayerList.Size = New System.Drawing.Size(645, 416)
        Me.tabPlayerList.TabIndex = 3
        Me.tabPlayerList.Text = "Player List"
        '
        'dgPlayerList
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPlayerList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgPlayerList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPlayerList.Location = New System.Drawing.Point(3, 3)
        Me.dgPlayerList.Name = "dgPlayerList"
        Me.dgPlayerList.Size = New System.Drawing.Size(639, 410)
        Me.dgPlayerList.TabIndex = 0
        '
        'MatchContextMenu
        '
        Me.MatchContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteMatchToolStripMenuItem})
        Me.MatchContextMenu.Name = "MatchContextMenu"
        Me.MatchContextMenu.Size = New System.Drawing.Size(149, 26)
        '
        'DeleteMatchToolStripMenuItem
        '
        Me.DeleteMatchToolStripMenuItem.Name = "DeleteMatchToolStripMenuItem"
        Me.DeleteMatchToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteMatchToolStripMenuItem.Text = "Delete Match"
        '
        'TennisMasterCentral
        '
        Me.Controls.Add(Me.tabMainForm)
        Me.Name = "TennisMasterCentral"
        Me.Size = New System.Drawing.Size(653, 442)
        Me.tabMainForm.ResumeLayout(False)
        Me.tabEventSummary.ResumeLayout(False)
        Me.tabEventSummary.PerformLayout()
        CType(Me.dgEventSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOpponentSummary.ResumeLayout(False)
        Me.tabOpponentSummary.PerformLayout()
        CType(Me.dgOpponentSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMatchHistory.ResumeLayout(False)
        Me.tabMatchHistory.PerformLayout()
        CType(Me.dgMatchList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPlayerList.ResumeLayout(False)
        CType(Me.dgPlayerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MatchContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EventSummaryToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabMainForm As System.Windows.Forms.TabControl
    Friend WithEvents tabEventSummary As System.Windows.Forms.TabPage
    Friend WithEvents dgEventSummary As System.Windows.Forms.DataGridView
    Friend WithEvents tabOpponentSummary As System.Windows.Forms.TabPage
    Friend WithEvents dgOpponentSummary As System.Windows.Forms.DataGridView
    Friend WithEvents tabMatchHistory As System.Windows.Forms.TabPage
    Friend WithEvents cmbMatchRange As System.Windows.Forms.ComboBox
    Friend WithEvents lblMatchRange As System.Windows.Forms.Label
    Friend WithEvents dgMatchList As System.Windows.Forms.DataGridView
    Friend WithEvents tabPlayerList As System.Windows.Forms.TabPage
    Friend WithEvents dgPlayerList As System.Windows.Forms.DataGridView
    Friend WithEvents cmbEventTimeSpan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMatchCount As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MatchContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
