Imports System.Security.Principal


Module Util

    Public log As ILog = LogManager.GetLogger("TennisMaster")

    Public MdiParent As Form = Nothing

    Public Sub Login()
		If Not TypeOf System.Threading.Thread.CurrentPrincipal Is TennisObjects.Security.UserPrincipal Then
			TennisObjects.Security.UserPrincipal.Login("gbb", "spanky")
		End If
    End Sub

    Private _DesignMode As Boolean = False

    Public Function DataLayerReady() As Boolean
		Return TypeOf System.Threading.Thread.CurrentPrincipal Is TennisObjects.Security.UserPrincipal
    End Function

    Public Function DesignMode(ByVal MyDesignMode As Boolean) As Boolean
        If Not DataLayerReady() Then _DesignMode = True
        If MyDesignMode Then _DesignMode = True
        Return _DesignMode
    End Function

    Public Sub BindField( _
     ByVal control As Control, _
     ByVal propertyName As String, _
     ByVal dataSource As Object, _
     ByVal dataMember As String)

        Dim bd As Binding

        For i As Integer = control.DataBindings.Count - 1 To 0 Step -1
			bd = control.DataBindings.Item(i)
            If bd.PropertyName = propertyName Then
                control.DataBindings.Remove(bd)
            End If
        Next
        control.DataBindings.Add(propertyName, dataSource, dataMember).DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
    End Sub

    'private FormFactoryTable as System.Collections.Generic.Dictionary(Of Type, 

	Public Function GetForm(ByVal obj As Csla.Core.BusinessBase) As BaseForm
		If TypeOf obj Is Player Then
			Return New ViewPlayer(DirectCast(obj, Player))
		ElseIf TypeOf obj Is Match Then
			Return New ViewMatch(DirectCast(obj, Match))
		ElseIf TypeOf obj Is TennisEvent Then
			Return New ViewEvent(DirectCast(obj, TennisEvent))
		ElseIf TypeOf obj Is Classification Then
			'Return New ViewClassification(DirectCast(obj, Classification))
		End If
		Return Nothing
	End Function

	Public Function EditObject(Of ObjType As Csla.Core.BusinessBase)(ByVal obj As ObjType) As ObjType
		Try
			Dim frm As BaseForm = GetForm(obj)
			Dim result As DialogResult = frm.ShowDialog()
			frm.Dispose()
			Return DirectCast(IIf(result = DialogResult.OK, frm.BusinessObject, Nothing), ObjType)
		Catch ex As Exception
			log.Error(String.Format("Error editing {0}", obj.GetType), ex)
			MessageBox.Show(String.Format("Error editing {0}", obj.GetType))
			Return Nothing
		End Try
	End Function


    '#Region "Support for editing players"
    '    Public Function EditPlayer(ByVal Player As Player) As Player
    '        Return EditObject(Player)
    '        'Try
    '        '    Dim frm As New ViewPlayer
    '        '    'frm.MdiParent = MdiParent
    '        '    frm.Player = Player
    '        '    Dim result As DialogResult = frm.ShowDialog()
    '        '    frm.Dispose()
    '        '    Return IIf(result = DialogResult.OK, frm.Player, Nothing)
    '        'Catch ex As Exception
    '        '    log.Error("Error editing player", ex)
    '        '    MessageBox.Show("Error editing player")
    '        '    Return Nothing
    '        'End Try
    '    End Function

    '    Public Function EditPlayer(ByVal PlayerID As Int32) As Player
    '        Return EditPlayer(Tennis.Objects.Player.Fetch(PlayerID))
    '    End Function

    '    Public Function EditNewPlayer(Optional ByVal initialName As String = "") As Player
    '        Dim Player As Player = Tennis.Objects.Player.Create()
    '        Player.FullName = initialName
    '        Return EditPlayer(Player)
    '    End Function
    '#End Region

    '#Region "Support for editing matches"
    '    Public Function EditMatch(ByVal Match As Match) As Match
    '        Try
    '            Dim frm As New ViewMatch
    '            'frm.MdiParent = MdiParent
    '            frm.Match = Match
    '            frm.ShowDialog()
    '            frm.Dispose()
    '            Return frm.Match
    '        Catch ex As Exception
    '            log.Error("Error editing match", ex)
    '            MessageBox.Show("Error editing match")
    '            Return Match
    '        End Try
    '    End Function

    '    Public Function EditMatch(ByVal MatchID As Int32) As Match
    '        Return EditMatch(Tennis.Objects.Match.GetMatch(MatchID))
    '    End Function

    '    Public Function EditNewMatch() As Match
    '        Return EditMatch(Tennis.Objects.Match.NewMatch())
    '    End Function
    '#End Region

    '#Region "Support for editing events"
    '    'Public Function EditEvent(ByVal TennisEvent As TennisEvent) As TennisEvent
    '    '    Return EditObject(TennisEvent)
    '    '    'Try
    '    '    '    Dim frm As New ViewEvent
    '    '    '    'frm.MdiParent = MdiParent
    '    '    '    frm.Event = TennisEvent
    '    '    '    Dim result As DialogResult = frm.ShowDialog()
    '    '    '    frm.Dispose()
    '    '    '    Return IIf(result = DialogResult.OK, frm.Event, Nothing)
    '    '    'Catch ex As Exception
    '    '    '    MessageBox.Show(ex.Message)
    '    '    '    Return Nothing
    '    '    'End Try
    '    'End Function

    '    'Public Function EditEvent(ByVal EventID As Int32) As TennisEvent
    '    '    Return EditEvent(Tennis.Objects.TennisEvent.Fetch(EventID))
    '    'End Function

    '    'Public Function EditNewEvent(Optional ByVal initialName As String = "") As TennisEvent
    '    '    Dim TennisEvent As TennisEvent = Tennis.Objects.TennisEvent.Create(initialName)
    '    '    TennisEvent.Name = initialName
    '    '    Return EditEvent(TennisEvent)
    '    'End Function
    '#End Region

#Region "Support for editing classifications"
    Public Function EditClassification(ByVal Classification As Classification) As Classification
        Try
            'Dim frm As New ViewClassification
            ''frm.MdiParent = MdiParent
            'frm.Classification = Classification
            'frm.ShowDialog()
            'frm.Dispose()
            'Return frm.Classification
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return Classification
        End Try
    End Function

    Public Function EditClassification(ByVal ClassificationID As Int32) As Classification
        'Return EditClassification(Tennis.Objects.Classification.GetClassification(ClassificationID))
        Return Nothing
    End Function

    Public Function EditNewClassification() As Classification
		Return EditClassification(TennisObjects.Classification.NewClassification())
    End Function
#End Region

#Region "DataGridView and DataListView Helper Methods"
    'Public Sub AddColumn(ByVal dv As DataListView.DataListView, ByVal HeaderText As String, ByVal PropertyName As String, Optional ByVal AlignRight As Boolean = False, Optional ByVal Format As String = Nothing)
    '    Dim i As Integer = 0
    '    dv.Columns.Add(HeaderText, PropertyName)
    '    'If AlignRight Then
    '    '	dg.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '    'End If
    '    'If Not Format Is Nothing Then
    '    '	dg.Columns(i).DefaultCellStyle.Format = Format
    '    'End If
    'End Sub

    'Public Sub PrepareDataView(ByVal dv As DataListView.DataListView, ByVal DataSource As Object)
    '    dv.AutoDiscover = False
    '    dv.DataSource = DataSource
    '    dv.Focus()
    '    dv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    'End Sub

    Public Sub AddColumn(ByVal dg As DataGridView, ByVal HeaderText As String, ByVal PropertyName As String, Optional ByVal AlignRight As Boolean = False, Optional ByVal Format As String = Nothing)
        Dim i As Integer = dg.Columns.Add(PropertyName, HeaderText)
        dg.Columns(i).DataPropertyName = PropertyName
        If AlignRight Then
            dg.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If Not Format Is Nothing Then
            dg.Columns(i).DefaultCellStyle.Format = Format
        End If
    End Sub

    Public Sub PrepareDataView(ByVal dg As DataGridView, ByVal DataSource As Object)
        dg.AutoGenerateColumns = False
        dg.DataSource = DataSource
        dg.Focus()
        dg.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        dg.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells)
    End Sub
#End Region

End Module

