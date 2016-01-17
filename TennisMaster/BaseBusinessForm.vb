Public Class BaseBusinessForm
	Protected _tooltip As New ToolTip
	Protected _HelpProvider As New HelpProvider
	'Protected _BusinessObject As CSLA.BusinessBase

	Private Sub BaseBusinessForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		' Set up the delays for the ToolTip.
		_tooltip.AutoPopDelay = 5000
		_tooltip.InitialDelay = 1000
		_tooltip.ReshowDelay = 500

		' Force the ToolTip text to be displayed whether or not the form is active.
		_tooltip.ShowAlways = True
	End Sub

	'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
	'	log.Debug("Cancel")
	'	_BusinessObject.CancelEdit()
	'	Me.Close()
	'End Sub

	'Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
	'	log.Debug("OK")
	'	_BusinessObject.ApplyEdit()
	'	_BusinessObject = _BusinessObject.Save()
	'	Me.Close()
	'End Sub

	'Private Sub ViewPlayer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
	'	log.Debug("Form Closing")
	'	_BusinessObject.CancelEdit()
	'End Sub

	Public Sub BindField( _
	ByVal control As Control, _
	ByVal propertyName As String, _
	ByVal dataSource As Csla.Core.BusinessBase, _
	ByVal dataMember As String)

		Util.BindField(control, propertyName, dataSource, dataMember)

		'regular tooltips appear when the mouse is hovered over a control and disappear
		'automatically.  Regular tooltips might typically contain lighter-weight text
		'compared to help tooltips.
		'todo: make this work again: _tooltip.SetToolTip(control, "tooltip: " & dataSource.Rules.Tooltip(dataMember))

		'help tooltips appear when the user presses F1 while the control has focus
		'and disappear when the user presses a key or clicks the tooltip.  Help tooltips
		'might typically contain heavier-weight text compared to regular tooltips.
		'todo: make this work again: _HelpProvider.SetHelpString(control, "helptip: " & dataSource.Rules.Tooltip(dataMember))

		'sets the key string used to look up the help topic in the help file.
		'todo: this should be a fully-qualified property name, including the namespace and class name
		'todo: make this work again: _HelpProvider.SetHelpKeyword(control, dataSource.HelpTopic(dataMember))
		'log.Debug("HelpKeyword: " & dataSource.HelpTopic(dataMember))

		'instructs the help provider to jump to the help topic based on the help keyword
		'this should start the help system in the table of contents with the matching topic selected
		_HelpProvider.SetHelpNavigator(control, HelpNavigator.KeywordIndex)

		'_HelpProvider.SetShowHelp(control, False)

		If TypeOf control Is TextBox Then
			Dim TextBox As TextBox = CType(control, TextBox)
			'todo: make this work again: TextBox.MaxLength = dataSource.Rules.MaxLength(dataMember)
		End If
	End Sub

	Public Sub BindField( _
	 ByVal control As ComboBox, _
	 ByVal propertyName As String, _
	 ByVal dataSource As Csla.Core.BusinessBase, _
	 ByVal dataMember As String, _
	 ByVal listSource As Object, _
	 ByVal listValueMember As String, _
	 ByVal listDisplayMember As String)

		control.DataSource = listSource
		control.DisplayMember = listDisplayMember
		control.ValueMember = listValueMember

		BindField(control, propertyName, dataSource, dataMember)

	End Sub

End Class