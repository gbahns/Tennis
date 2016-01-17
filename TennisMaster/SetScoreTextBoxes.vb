Public Class SetScoreTextBoxes

	Private _SetNumber As Integer = 0
	Private _ShowNextSet As Boolean = False

	Public Event ScoreChanged(ByVal sender As SetScoreTextBoxes, ByVal e As System.EventArgs)

	Protected Overridable Sub OnScoreChanged()
		RaiseEvent ScoreChanged(Me, EventArgs.Empty)
	End Sub

	Public Property SetNumber() As Integer
		Get
			Return _SetNumber
		End Get
		Set(ByVal value As Integer)
			_SetNumber = value
			Me.lblSet.Text = "Set &" & value.ToString
		End Set
	End Property

	Public ReadOnly Property ShowNextSet() As Boolean
		Get
			Return _ShowNextSet
		End Get
	End Property

    Private Sub GamesScoreChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLGames.TextChanged, txtWGames.TextChanged
        'todo: implement this as a business rule, publish a property called TiebreakVisible, and bind the visible property on the tiebreak edit boxes to the TiebreakVisible property
        Dim ShowTiebreak As Boolean = False
        Dim WGames As Integer
        Dim LGames As Integer
        Int32.TryParse(txtWGames.Text, WGames)
        Int32.TryParse(txtLGames.Text, LGames)
        ShowTiebreak = Math.Abs(WGames - LGames) = 1
        _ShowNextSet = WGames > 0 Or LGames > 0
        txtWTiebreak.Visible = ShowTiebreak
        txtLTiebreak.Visible = ShowTiebreak
        lblTiebreakHyphen.Visible = ShowTiebreak
        lblTiebreakParen1.Visible = ShowTiebreak
        lblTiebreakParen2.Visible = ShowTiebreak

        OnScoreChanged()
    End Sub
End Class
