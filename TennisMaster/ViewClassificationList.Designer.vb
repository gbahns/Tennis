Partial Public Class ClassificationListForm
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
		Me.ClassificationListView = New System.Windows.Forms.DataGridView
		CType(Me.ClassificationListView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'ClassificationListView
		'
		Me.ClassificationListView.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ClassificationListView.Location = New System.Drawing.Point(0, 0)
		Me.ClassificationListView.Name = "ClassificationListView"
		Me.ClassificationListView.Size = New System.Drawing.Size(315, 289)
		Me.ClassificationListView.TabIndex = 0
		'
		'ClassificationListForm
		'
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
		Me.ClientSize = New System.Drawing.Size(315, 289)
		Me.Controls.Add(Me.ClassificationListView)
		Me.Name = "ClassificationListForm"
		Me.Text = "Classifications"
		CType(Me.ClassificationListView, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents ClassificationListView As System.Windows.Forms.DataGridView
End Class
