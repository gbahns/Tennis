Public Class ClassificationListForm

	Private list As ClassificationList

	Private Sub ClassificationListForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		list.ApplyEdit()
		list.Save()
	End Sub

	Private Sub ViewClassificationList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Login()
        list = ClassificationList.GetList()
		If ClassificationListView.ColumnCount = 0 Then
			'BindField(chkIsDirty, "Checked", list, "IsDirty")
			AddColumn(ClassificationListView, "ID", "ID")
			AddColumn(ClassificationListView, "Name", "Name")
			AddColumn(ClassificationListView, "USTA", "USTAEquivalent")
			'ClassificationListView.Columns(2).
		End If
		PrepareDataView(ClassificationListView, list)
		list.BeginEdit()
	End Sub
End Class