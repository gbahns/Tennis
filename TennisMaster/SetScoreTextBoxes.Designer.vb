Partial Public Class SetScoreTextBoxes
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
        Me.txtLTiebreak = New System.Windows.Forms.TextBox
        Me.txtWTiebreak = New System.Windows.Forms.TextBox
        Me.txtLGames = New System.Windows.Forms.TextBox
        Me.txtWGames = New System.Windows.Forms.TextBox
        Me.lblTiebreakParen1 = New System.Windows.Forms.Label
        Me.lblTiebreakParen2 = New System.Windows.Forms.Label
        Me.lblSet = New System.Windows.Forms.Label
        Me.lblGamesHyphen = New System.Windows.Forms.Label
        Me.lblTiebreakHyphen = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtLTiebreak
        '
        Me.txtLTiebreak.Location = New System.Drawing.Point(170, 0)
        Me.txtLTiebreak.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.txtLTiebreak.Name = "txtLTiebreak"
        Me.txtLTiebreak.Size = New System.Drawing.Size(30, 20)
        Me.txtLTiebreak.TabIndex = 20
        '
        'txtWTiebreak
        '
        Me.txtWTiebreak.Location = New System.Drawing.Point(127, 0)
        Me.txtWTiebreak.Margin = New System.Windows.Forms.Padding(3, 3, 1, 1)
        Me.txtWTiebreak.Name = "txtWTiebreak"
        Me.txtWTiebreak.Size = New System.Drawing.Size(30, 20)
        Me.txtWTiebreak.TabIndex = 19
        '
        'txtLGames
        '
        Me.txtLGames.Location = New System.Drawing.Point(78, 0)
        Me.txtLGames.Margin = New System.Windows.Forms.Padding(3, 0, 3, 1)
        Me.txtLGames.Name = "txtLGames"
        Me.txtLGames.Size = New System.Drawing.Size(30, 20)
        Me.txtLGames.TabIndex = 18
        '
        'txtWGames
        '
        Me.txtWGames.Location = New System.Drawing.Point(36, 0)
        Me.txtWGames.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.txtWGames.Name = "txtWGames"
        Me.txtWGames.Size = New System.Drawing.Size(30, 20)
        Me.txtWGames.TabIndex = 17
        '
        'lblTiebreakParen1
        '
        Me.lblTiebreakParen1.AutoSize = True
        Me.lblTiebreakParen1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiebreakParen1.Location = New System.Drawing.Point(116, -2)
        Me.lblTiebreakParen1.Name = "lblTiebreakParen1"
        Me.lblTiebreakParen1.Size = New System.Drawing.Size(14, 20)
        Me.lblTiebreakParen1.TabIndex = 21
        Me.lblTiebreakParen1.Text = "("
        '
        'lblTiebreakParen2
        '
        Me.lblTiebreakParen2.AutoSize = True
        Me.lblTiebreakParen2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiebreakParen2.Location = New System.Drawing.Point(199, -2)
        Me.lblTiebreakParen2.Name = "lblTiebreakParen2"
        Me.lblTiebreakParen2.Size = New System.Drawing.Size(14, 20)
        Me.lblTiebreakParen2.TabIndex = 22
        Me.lblTiebreakParen2.Text = ")"
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Location = New System.Drawing.Point(-1, 3)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(32, 13)
        Me.lblSet.TabIndex = 23
        Me.lblSet.Text = "Set 0"
        '
        'lblGamesHyphen
        '
        Me.lblGamesHyphen.AutoSize = True
        Me.lblGamesHyphen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGamesHyphen.Location = New System.Drawing.Point(66, 0)
        Me.lblGamesHyphen.Name = "lblGamesHyphen"
        Me.lblGamesHyphen.Size = New System.Drawing.Size(14, 20)
        Me.lblGamesHyphen.TabIndex = 24
        Me.lblGamesHyphen.Text = "-"
        '
        'lblTiebreakHyphen
        '
        Me.lblTiebreakHyphen.AutoSize = True
        Me.lblTiebreakHyphen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiebreakHyphen.Location = New System.Drawing.Point(158, 0)
        Me.lblTiebreakHyphen.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.lblTiebreakHyphen.Name = "lblTiebreakHyphen"
        Me.lblTiebreakHyphen.Size = New System.Drawing.Size(14, 20)
        Me.lblTiebreakHyphen.TabIndex = 25
        Me.lblTiebreakHyphen.Text = "-"
        '
        'SetScoreTextBoxes
        '
        Me.Controls.Add(Me.txtLTiebreak)
        Me.Controls.Add(Me.txtWTiebreak)
        Me.Controls.Add(Me.txtLGames)
        Me.Controls.Add(Me.lblTiebreakHyphen)
        Me.Controls.Add(Me.lblGamesHyphen)
        Me.Controls.Add(Me.lblSet)
        Me.Controls.Add(Me.lblTiebreakParen2)
        Me.Controls.Add(Me.lblTiebreakParen1)
        Me.Controls.Add(Me.txtWGames)
        Me.Name = "SetScoreTextBoxes"
        Me.Size = New System.Drawing.Size(227, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents txtLTiebreak As System.Windows.Forms.TextBox
	Friend WithEvents txtWTiebreak As System.Windows.Forms.TextBox
	Friend WithEvents txtLGames As System.Windows.Forms.TextBox
	Friend WithEvents txtWGames As System.Windows.Forms.TextBox
	Friend WithEvents lblTiebreakParen1 As System.Windows.Forms.Label
	Friend WithEvents lblTiebreakParen2 As System.Windows.Forms.Label
	Friend WithEvents lblSet As System.Windows.Forms.Label
	Friend WithEvents lblGamesHyphen As System.Windows.Forms.Label
	Friend WithEvents lblTiebreakHyphen As System.Windows.Forms.Label

End Class
