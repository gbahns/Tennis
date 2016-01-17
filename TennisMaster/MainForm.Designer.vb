Public Partial Class MainForm
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
        Me.TennisMasterCentral1 = New Tennis.Master.TennisMasterCentral
        Me.SuspendLayout()
        '
        'TennisMasterCentral1
        '
        Me.TennisMasterCentral1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TennisMasterCentral1.Location = New System.Drawing.Point(0, 0)
        Me.TennisMasterCentral1.Name = "TennisMasterCentral1"
        Me.TennisMasterCentral1.Size = New System.Drawing.Size(737, 559)
        Me.TennisMasterCentral1.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.ClientSize = New System.Drawing.Size(737, 559)
        Me.Controls.Add(Me.TennisMasterCentral1)
        Me.Name = "MainForm"
        Me.Text = "Tennis Master Central"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TennisMasterCentral1 As Tennis.Master.TennisMasterCentral
End Class
