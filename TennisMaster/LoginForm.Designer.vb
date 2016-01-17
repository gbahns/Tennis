Partial Public Class LoginForm
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
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.LogoPictureBox = New System.Windows.Forms.PictureBox
		Me.UsernameLabel = New System.Windows.Forms.Label
		Me.PasswordLabel = New System.Windows.Forms.Label
		Me.UsernameTextBox = New System.Windows.Forms.TextBox
		Me.PasswordTextBox = New System.Windows.Forms.TextBox
		Me.OK = New System.Windows.Forms.Button
		Me.Cancel = New System.Windows.Forms.Button
		CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'LogoPictureBox
		'
		Me.LogoPictureBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		'todo: make this work again: Me.LogoPictureBox.Image =  Tennis.Master.My.Resources.MyResources.TennisBall
		Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
		Me.LogoPictureBox.Name = "LogoPictureBox"
		Me.LogoPictureBox.Size = New System.Drawing.Size(80, 171)
		Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
		Me.LogoPictureBox.TabIndex = 0
		Me.LogoPictureBox.TabStop = False
		'
		'UsernameLabel
		'
		Me.UsernameLabel.Location = New System.Drawing.Point(85, 9)
		Me.UsernameLabel.Name = "UsernameLabel"
		Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
		Me.UsernameLabel.TabIndex = 0
		Me.UsernameLabel.Text = "&User name"
		Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PasswordLabel
		'
		Me.PasswordLabel.Location = New System.Drawing.Point(85, 66)
		Me.PasswordLabel.Name = "PasswordLabel"
		Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
		Me.PasswordLabel.TabIndex = 2
		Me.PasswordLabel.Text = "&Password"
		Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'UsernameTextBox
		'
		Me.UsernameTextBox.Location = New System.Drawing.Point(87, 29)
		Me.UsernameTextBox.Name = "UsernameTextBox"
		Me.UsernameTextBox.Size = New System.Drawing.Size(174, 20)
		Me.UsernameTextBox.TabIndex = 1
		'
		'PasswordTextBox
		'
		Me.PasswordTextBox.Location = New System.Drawing.Point(87, 86)
		Me.PasswordTextBox.Name = "PasswordTextBox"
		Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.PasswordTextBox.Size = New System.Drawing.Size(174, 20)
		Me.PasswordTextBox.TabIndex = 3
		'
		'OK
		'
		Me.OK.Location = New System.Drawing.Point(88, 127)
		Me.OK.Name = "OK"
		Me.OK.Size = New System.Drawing.Size(70, 23)
		Me.OK.TabIndex = 4
		Me.OK.Text = "&OK"
		'
		'Cancel
		'
		Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel.Location = New System.Drawing.Point(191, 127)
		Me.Cancel.Name = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(70, 23)
		Me.Cancel.TabIndex = 5
		Me.Cancel.Text = "&Cancel"
		'
		'LoginForm
		'
		Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
		Me.CancelButton = Me.Cancel
		Me.ClientSize = New System.Drawing.Size(289, 171)
		Me.Controls.Add(Me.Cancel)
		Me.Controls.Add(Me.OK)
		Me.Controls.Add(Me.PasswordTextBox)
		Me.Controls.Add(Me.UsernameTextBox)
		Me.Controls.Add(Me.PasswordLabel)
		Me.Controls.Add(Me.UsernameLabel)
		Me.Controls.Add(Me.LogoPictureBox)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "LoginForm"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "LoginForm"
		CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

End Class
