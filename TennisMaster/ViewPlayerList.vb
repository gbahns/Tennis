Public Class ViewPlayerList

	Private Sub ViewPlayerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		TennisObjects.Security.UserPrincipal.Login("gbb", "spanky")
        Dim list As PlayerList = PlayerList.GetList()
		'With dvPlayerList
		'	.Columns.Add("ID", "ID", 0)
		'	.Columns.Add("FirstName", "FirstName", 0)
		'	.Columns.Add("LastName", "LastName", 0)
		'	.DataSource = list
		'	.Focus()
		'End With
		With dgPlayerList
			.AutoGenerateColumns = False
			'.BindingContext 
			'.DataBindings.Add(new Binding(
			'.Columns.Add(New DataGridViewColumn(New forms.datagridviewcell))
			'.DataBindings.Add("ID", list, "ID")

			.Columns.Add("ID", "ID")
			.Columns.Add("FirstName", "FirstName")
			.Columns.Add("LastName", "LastName")
			.Columns("ID").DataPropertyName = "ID"
			.Columns("FirstName").DataPropertyName = "FirstName"
			.Columns("LastName").DataPropertyName = "LastName"
			.DataSource = list
            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            .AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
			.Focus()
		End With
	End Sub

	Private Sub dgPlayerList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgPlayerList.Click

	End Sub

	Private Sub dgPlayerList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgPlayerList.ColumnHeaderMouseClick
		dgPlayerList.Sort(dgPlayerList.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
	End Sub
End Class