Public Class ViewPlayer

	Public Property Player() As Player
		Get
			Return DirectCast(_BusinessObject, Player)
		End Get
		Set(ByVal value As Player)
			_BusinessObject = value
		End Set
	End Property

    Protected Overrides Sub DataBind()
        MyBase.DataBind()
        BindField(txtID, "Text", Player, "ID")
        BindField(txtFirstName, "Text", Player, "FirstName")
        BindField(txtLastName, "Text", Player, "LastName")
    End Sub

    Private Sub ViewPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then Return

        ''todo: remove this welcome text from the Player form
        'lblWelcome.Text = "Welcome, " + System.Threading.Thread.CurrentPrincipal.Identity.Name()

        'Me.Text = Player.ToString()

        ''todo: check the user's role to see if they have rights to view or edit players
        ''some user's have rights to edit themselves only
        ''some have rights to edit members of their team

        '_HelpProvider.HelpNamespace = "Tennis.chm"
        ''_HelpProvider.SetHelpNavigator(Me.txtFirstName, HelpNavigator.Index)
        txtFirstName.Focus()
    End Sub

End Class
