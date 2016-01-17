Public Partial Class ViewPlayerList
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
		Me.dgPlayerList = New System.Windows.Forms.DataGridView
		CType(Me.dgPlayerList, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'dgPlayerList
		'
		Me.dgPlayerList.AutoSize = True
		Me.dgPlayerList.BackgroundColor = System.Drawing.Color.Tan
		Me.dgPlayerList.BorderStyle = System.Windows.Forms.BorderStyle.None
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SaddleBrown
		Me.dgPlayerList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.OldLace
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.0!)
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.dgPlayerList.DefaultCellStyle = DataGridViewCellStyle2
		Me.dgPlayerList.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgPlayerList.Font = New System.Drawing.Font("Tahoma", 8.0!)
		Me.dgPlayerList.GridColor = System.Drawing.Color.Tan
		Me.dgPlayerList.Location = New System.Drawing.Point(0, 0)
		Me.dgPlayerList.Name = "dgPlayerList"
		Me.dgPlayerList.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.dgPlayerList.Size = New System.Drawing.Size(403, 374)
		Me.dgPlayerList.TabIndex = 1
		'
		'ViewPlayerList
		'
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
		Me.ClientSize = New System.Drawing.Size(403, 374)
		Me.Controls.Add(Me.dgPlayerList)
		Me.Name = "ViewPlayerList"
		Me.Text = "ViewPlayerList"
		CType(Me.dgPlayerList, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents dgPlayerList As System.Windows.Forms.DataGridView
End Class
