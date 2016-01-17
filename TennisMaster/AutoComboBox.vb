Public Class AutoComboBox
    Inherits ComboBox

#Region "Private Data"
    Private _ItemName As String = ""

    Private WithEvents AddItemMenuItem As ToolStripMenuItem
    Private WithEvents EditItemMenuItem As ToolStripMenuItem
    Private WithEvents DeleteItemMenuItem As ToolStripMenuItem

    ''' <summary>
    ''' _collection is optional and is used to handle list changed events when the
    ''' collection is derived from BusinessCollectionBase.
    ''' </summary>
    ''' <remarks>
    ''' When not derived from BusinessCollectionBase, it is assumed that the list won't
    ''' be changing, so there's no need to handle ListChanged events.
    ''' </remarks>
	Private WithEvents _collection As Csla.Core.IReadOnlyCollection
#End Region

#Region "Constructors"
    Public Sub New()
        AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource
        InitializeContextMenu()
    End Sub
#End Region

#Region "Properties"
    Public Property ItemName() As String
        Get
            Return _ItemName
        End Get
        Set(ByVal value As String)
            _ItemName = value
            AddItemMenuItem.Text = "Add " & _ItemName
            EditItemMenuItem.Text = "Edit " & _ItemName
            DeleteItemMenuItem.Text = "Delete " & _ItemName
        End Set
    End Property

    Public ReadOnly Property ValidItemSelected() As Boolean
        Get
            Return SelectedIndex <> -1 AndAlso CInt(SelectedValue) > 0
        End Get
    End Property

    ''' <summary>
    ''' Hide the ContextMenuStrip property from the UI; we don't want the user
    ''' inadvertantly messing up our built-in Add/Edit/Delete menu.  The user
    ''' must use our menu-building interface to add items.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Private Shadows Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return MyBase.ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            MyBase.ContextMenuStrip = value
        End Set
    End Property

#End Region

#Region "Auto Completion"
    'for this to work, the DisplayMember must be set prior to the DataSource being set
    Private Function GetAutoCompleteStrings() As AutoCompleteStringCollection
        Dim strings As New AutoCompleteStringCollection
        For Each item As Object In DirectCast(Me.DataSource, CollectionBase)
            strings.Add(GetItemText(item))
        Next
        Return strings
    End Function

#End Region

#Region "Event Handlers"
    Private Sub AutoComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        For Each item As ToolStripItem In ContextMenuStrip.Items
            Dim menuitem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If Not menuitem Is Nothing AndAlso menuitem.ShortcutKeys = e.KeyData Then
                menuitem.PerformClick()
                e.Handled = True
                Return
            End If
        Next
    End Sub

    Private Sub AutoComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If Not Me.ContextMenuStrip Is Nothing Then
            EditItemMenuItem.Enabled = ValidItemSelected
            DeleteItemMenuItem.Enabled = ValidItemSelected
        End If
    End Sub

    ''' <summary>
    ''' Handle the validating event to ensure that auto-complete text gets
    ''' mapped to the correct item in the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AutoComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        'log.Info(String.Format("{5}_Validating: SelectedIndex={0}, SelectedItem={1}, SelectedText={2}, SelectedValue={3}, Text={4}", cmb.SelectedIndex, cmb.SelectedItem, cmb.SelectedText, cmb.SelectedValue, cmb.Text, cmb.Name))
        If cmb.SelectedIndex = -1 Then
            cmb.SelectedIndex = cmb.FindString(cmb.Text)
            If cmb.SelectedIndex = -1 Then
                OnAddItem()
                'cmb.SelectedIndex = cmb.FindString("")
            End If
        End If
    End Sub
#End Region

#Region "Menu Building Helpers"
    Private Function NewMenuItem(ByVal name As String, ByVal text As String, ByVal shortcutKeys As Keys) As ToolStripMenuItem
        Dim item As New ToolStripMenuItem()
        item.Name = name
        item.Text = text
        item.ShortcutKeys = shortcutKeys
        'AddHandler item.Click, handler
        Return item
    End Function

    Public Function AddMenuItem(ByVal name As String, ByVal text As String, Optional ByVal shortcutKeys As Keys = Windows.Forms.Keys.None) As ToolStripMenuItem
        Dim item As ToolStripMenuItem = NewMenuItem(name, text, shortcutKeys)
        ContextMenuStrip.Items.Add(item)
        Return item
    End Function

    Public Function AddMenuCheck(ByVal name As String, ByVal text As String, Optional ByVal shortcutKeys As Keys = Windows.Forms.Keys.None) As ToolStripMenuItem
        Dim item As ToolStripMenuItem = NewMenuItem(name, text, shortcutKeys)
        item.CheckOnClick = True
        ContextMenuStrip.Items.Add(item)
        Return item
    End Function

    Public Sub AddMenuSeparator()
        ContextMenuStrip.Items.Add(New ToolStripSeparator())
    End Sub

    Public Sub AddRange(ByVal menuToAppend As ContextMenuStrip)
        ContextMenuStrip.Items.AddRange(menuToAppend.Items)
    End Sub
#End Region

#Region "Build Default Menu"
    Public Event AddItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs)
    Public Event EditItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs)
    Public Event DeleteItem(ByVal sender As AutoComboBox, ByVal e As System.EventArgs)

    Protected Sub OnAddItem()
        RaiseEvent AddItem(Me, New EventArgs)
    End Sub

    Protected Sub OnEditItem()
        RaiseEvent EditItem(Me, New EventArgs)
    End Sub

    Protected Sub OnDeleteItem()
        RaiseEvent DeleteItem(Me, New EventArgs)
    End Sub

    Private Sub AddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemMenuItem.Click
        'AddHandler _collection.ListChanged, AddressOf AutoComboBox_ListChanged
        OnAddItem()
        Focus() 'ensure the combobox regains focus after the event is handled
    End Sub

    Private Sub EditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItemMenuItem.Click
        If ValidItemSelected Then OnEditItem()
        Focus() 'ensure the combobox regains focus after the event is handled
    End Sub

    Private Sub DeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteItemMenuItem.Click
        If ValidItemSelected Then OnDeleteItem()
        Focus() 'ensure the combobox regains focus after the event is handled
    End Sub

    Private Sub InitializeContextMenu()
        ContextMenuStrip = New ContextMenuStrip()
        AddItemMenuItem = AddMenuItem("AddItem", "Add", Keys.Insert)
        EditItemMenuItem = AddMenuItem("EditItem", "Edit", Keys.F2)
        DeleteItemMenuItem = AddMenuItem("DeleteItem", "Delete", Keys.Alt Or Keys.Delete)
    End Sub
#End Region

    'Private Sub AutoComboBox_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BindingContextChanged
    '    _collection = TryCast(DataSource, Csla.BusinessCollectionBase)
    'End Sub

    Private Sub AutoComboBox_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.DataSourceChanged
        AutoCompleteCustomSource = GetAutoCompleteStrings()
		_collection = TryCast(DataSource, Csla.Core.IReadOnlyCollection)
        'AddHandler _collection.ListChanged, AddressOf AutoComboBox_ListChanged
    End Sub

	Private Sub Collection_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) 'todo: make this work again Handles _collection.ListChanged
		Try
			AutoCompleteCustomSource = GetAutoCompleteStrings()
			If Me.SelectedIndex = e.OldIndex Then
				Select Case e.ListChangedType
					Case System.ComponentModel.ListChangedType.ItemAdded
						SelectedIndex = e.NewIndex
					Case System.ComponentModel.ListChangedType.ItemDeleted
						SelectedIndex = 0
					Case System.ComponentModel.ListChangedType.ItemChanged

				End Select
			End If
		Catch ex As Exception
			log.Info(String.Format("error updating the Event dropdown combo (change type:{0}; oldindex:{1} newindex:{2}", e.ListChangedType, e.OldIndex, e.NewIndex))
		End Try
	End Sub

End Class
