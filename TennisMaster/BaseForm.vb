''' <summary>
''' Provides a base form for business object editing.
''' </summary>
''' <remarks>
''' Steps to effectively use this base form class:
'''   1. derive your form from BaseForm
'''   2. provide buttons named "btnOk" and "btnCancel"
'''   3. call "RegisterBaseButtons" from your form's load method
'''   4. for convenience, pr
'''   4. override the DataBind method to bind your form's controls
'''      to your business objects properties
''' </remarks>
Public Class BaseForm
    Inherits System.Windows.Forms.Form

#Region " Data Members"
    Protected _tooltip As New ToolTip
    Protected _HelpProvider As New HelpProvider
	Protected WithEvents _BusinessObject As Csla.Core.BusinessBase
    Protected _ErrorProvider As New ErrorProvider(Me)
    Friend WithEvents chkIsDirty As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MainStatusStripPanel As System.Windows.Forms.ToolStripStatusLabel
    Private _ErrorPlacementControl As Control

	Public ReadOnly Property BusinessObject() As Csla.Core.BusinessBase
		Get
			Return _BusinessObject
		End Get
	End Property
#End Region

#Region " Windows Forms Designer"
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.chkIsDirty = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.MainStatusStripPanel = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIsDirty
        '
        Me.chkIsDirty.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkIsDirty.AutoSize = True
        Me.chkIsDirty.Location = New System.Drawing.Point(-100, -100)
        Me.chkIsDirty.Name = "chkIsDirty"
        Me.chkIsDirty.Size = New System.Drawing.Size(140, 17)
        Me.chkIsDirty.TabIndex = 0
        Me.chkIsDirty.TabStop = False
        Me.chkIsDirty.Text = "chkIsDirty (not displayed)"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(245, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 17
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(163, 0)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(332, 46)
        Me.Panel1.TabIndex = 18
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainStatusStripPanel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 27)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 12, 0)
        'Me.StatusStrip1.Raft = System.Windows.Forms.RaftingSides.None
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MainStatusStripPanel
        '
        Me.MainStatusStripPanel.Name = "MainStatusStripPanel"
        'Me.MainStatusStripPanel.SettingsKey = "ViewMatch.ViewmatchStatusStripPanel"
        Me.MainStatusStripPanel.Text = "Message Text"
        '
        'BaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5, 13)
        Me.ClientSize = New System.Drawing.Size(332, 203)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkIsDirty)
        Me.Name = "BaseForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Error Provider Helpers"
    Protected Sub SetErrorPlacementControl(ByVal ErrorPlacementControl As Control, Optional ByVal alignment As ErrorIconAlignment = ErrorIconAlignment.MiddleRight)
        _ErrorPlacementControl = ErrorPlacementControl
        _ErrorProvider.SetIconAlignment(ErrorPlacementControl, alignment)
    End Sub

    Protected Sub SetDataErrorInfo(ByVal control As Control)
        If control.DataBindings.Count > 0 Then
            'set property-level errors
            For Each binding As Binding In control.DataBindings
                If binding.IsBinding Then
                    Dim obj As System.ComponentModel.IDataErrorInfo = DirectCast(binding.DataSource, System.ComponentModel.IDataErrorInfo)
                    _ErrorProvider.SetError(control, obj.Item(binding.BindingMemberInfo.BindingField))
                End If
            Next

            'set form-level errors using the DataSource of the control's first binding
            If Not _ErrorPlacementControl Is Nothing Then
                _ErrorProvider.SetError(_ErrorPlacementControl, DirectCast(control.DataBindings(0).DataSource, System.ComponentModel.IDataErrorInfo).Item("ClassError"))
            End If
        End If
    End Sub

    Protected Sub SetDataErrorInfo(ByVal control As Control, ByVal message As String)
        _ErrorProvider.SetError(control, message)
    End Sub

    Private Sub Control_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        SetDataErrorInfo(DirectCast(sender, Control))
    End Sub

#End Region

#Region " Data Binding"
    ''' <summary>
    ''' Provides base data binding for the OK button and IsDirty checkbox.
    ''' Derived form classes should override this to bind their own fields.
    ''' The derived class should call MyBase.DataBind.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub DataBind()
        BindField(btnOK, "Enabled", _BusinessObject, "IsSavable")
        BindField(chkIsDirty, "Checked", _BusinessObject, "IsDirty")
        SetErrorPlacementControl(btnOK, ErrorIconAlignment.MiddleLeft)
    End Sub

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
		'and disappear when the user presses a key or clisk the tooltip.  Help tooltips
		'might typically contain heavier-weight text compared to regular tooltips.
		'todo: make this work again: _HelpProvider.SetHelpString(control, "helptip: " & dataSource.Rules.Tooltip(dataMember))

		'sets the key string used to look up the help topic in the help file.
		'todo: this should be a fully-qualified property name, including the namespace and class name
		'todo: make this work again: _HelpProvider.SetHelpKeyword(control, Csla.Core.BusinessBase(dataMember))
		'log.Debug("HelpKeyword: " & dataSource.HelpTopic(dataMember))

		'instructs the help provider to jump to the help topic based on the help keyword
		'this should start the help system in the table of contents with the matching topic selected
		_HelpProvider.SetHelpNavigator(control, HelpNavigator.KeywordIndex)

		'_HelpProvider.SetShowHelp(control, False)

		AddHandler control.Validated, AddressOf Control_Validated

		If TypeOf control Is TextBox Then
			Dim TextBox As TextBox = CType(control, TextBox)
			'todo: make this work again: TextBox.MaxLength = Csla.Core.BusinessBase.MaxLength(dataMember)
		End If
	End Sub

	Public Sub BindField( _
	 ByVal control As AutoComboBox, _
	 ByVal dataSource As Csla.Core.BusinessBase, _
	 ByVal dataMember As String, _
	 ByVal listMember As String, _
	 ByVal listValueMember As String, _
	 ByVal listDisplayMember As String)

		control.DisplayMember = listDisplayMember
		control.ValueMember = listValueMember
		BindField(control, "DataSource", dataSource, listMember)
		BindField(control, "SelectedValue", dataSource, dataMember)
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

#End Region

#Region " Message Display"
    Protected Property InfoMessage() As String
        Get
            Return MainStatusStripPanel.Text
        End Get
        Set(ByVal value As String)
            MainStatusStripPanel.Text = value
            MainStatusStripPanel.ForeColor = Color.Black
        End Set
    End Property

    Protected Property ErrorMessage() As String
        Get
            Return MainStatusStripPanel.Text
        End Get
        Set(ByVal value As String)
            MainStatusStripPanel.Text = value
            MainStatusStripPanel.ForeColor = Color.Red
        End Set
    End Property

    Protected Property ErrorOccured() As Boolean
        Get
            Return MainStatusStripPanel.ForeColor = Color.Red
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                InfoMessage = ""
            End If
        End Set
    End Property
#End Region

#Region " Event Handlers"
    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Return

        AcceptButton = btnOK
        CancelButton = btnCancel

        'move chkIsDirty out of sight
        'chkIsDirty.Left = -1000

        ' Set up the delays for the ToolTip.
        _tooltip.AutoPopDelay = 5000
        _tooltip.InitialDelay = 1000
        _tooltip.ReshowDelay = 500

        ' Force the ToolTip text to be displayed whether or not the form is active.
        _tooltip.ShowAlways = True

        'call the DataBind method provided by the derived class
        DataBind()

        _BusinessObject.BeginEdit()
        Me.Panel1.Focus()
    End Sub

    Private Sub BaseForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        log.Debug("Form Closing")
        Select Case DialogResult
            Case Windows.Forms.DialogResult.OK
                Try
                    BusinessObject.ApplyEdit()
					'todo: make this working again: _BusinessObject = BusinessObject.Save()
                Catch ex As Exception
                    e.Cancel = True
                    log.Error("Error on save.", ex)
                    ErrorMessage = "Error saving"
                End Try
            Case Windows.Forms.DialogResult.Cancel
                BusinessObject.CancelEdit()
            Case Else
                Throw New Exception("Unexpected DialogResult in BaseForm_FormClosing ({0})")
        End Select
    End Sub

    'Private Sub IsDirtyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _BusinessObject.IsDirtyChanged
    '    'For Each SetScore As SetScoreTextBoxes In pnlSetControls.Controls
    '    '    'Util.BindField(SetScore, "Visible", Match.Score.ShowSet(SetScore.SetNumber - 1), "")
    '    '    SetScore.Visible = Match.Score.ShowSet(SetScore.SetNumber - 1)
    '    'Next

    '    InfoMessage = "Press OK to save changes"
    'End Sub

#End Region

End Class
