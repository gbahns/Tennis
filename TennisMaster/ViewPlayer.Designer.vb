Partial Public Class ViewPlayer
	Inherits BaseForm

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal obj As Player)
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
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.lblWelcome = New System.Windows.Forms.Label
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_tooltip
        '
        Me._tooltip.AutoPopDelay = 5000
        Me._tooltip.InitialDelay = 1000
        Me._tooltip.ReshowDelay = 500
        Me._tooltip.ShowAlways = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(13, 45)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Last Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(13, 103)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.TabIndex = 4
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(142, 103)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.TabIndex = 5
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Location = New System.Drawing.Point(13, 13)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(51, 14)
        Me.lblWelcome.TabIndex = 8
        Me.lblWelcome.Text = "Welcome"
        '
        'ViewPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.ClientSize = New System.Drawing.Size(285, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewPlayer"
        Me.ShowInTaskbar = False
        Me.Text = "Player"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtID, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtFirstName, 0)
        Me.Controls.SetChildIndex(Me.txtLastName, 0)
        Me.Controls.SetChildIndex(Me.lblWelcome, 0)
        CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    'Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider

End Class
