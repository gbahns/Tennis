Public Partial Class BaseBusinessForm
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
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOK = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'btnCancel
		'
		Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(205, 236)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.TabIndex = 15
		Me.btnCancel.Text = "Cancel"
		'
		'btnOK
		'
		Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnOK.Location = New System.Drawing.Point(123, 236)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.TabIndex = 14
		Me.btnOK.Text = "OK"
		'
		'BaseBusinessForm
		'
		Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(292, 271)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOK)
		Me.Name = "BaseBusinessForm"
		Me.Text = "BaseBusinessForm"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
