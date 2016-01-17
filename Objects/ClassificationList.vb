<Serializable()> _
Public Class ClassificationList
    Inherits BusinessCollectionBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(ClassificationList).ToString())

#Region "Private Data"

#End Region

#Region "Business Properties and Methods"
    Default Public ReadOnly Property item(ByVal index As Integer) As Classification
        Get
            Return CType(List.Item(index), Classification)
        End Get
    End Property

    Public Sub Add(ByVal Name As String, ByVal USTAEquivalent As String)
        List.Add(Classification.NewClassification(Name, USTAEquivalent))
    End Sub

    Public Sub Remove(ByVal Child As Classification)
        List.Remove(Child)
    End Sub
#End Region

#Region "Contains"
    Public Overloads Function Contains(ByVal item As Classification) As Boolean
        Dim child As Classification
        For Each child In List
            If child.Equals(item) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Overloads Function ContainsDeleted(ByVal item As Classification) As Boolean
        Dim child As Classification
        For Each child In deletedList
            If child.Equals(item) Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

#Region "System.Object Overrides"
    'normally these overrides don't make sense for collection objects

    'Public Overrides Function ToString() As String
    '	'todo: return a useful string representation of the object
    '	Return MyBase.ToString()
    'End Function

    'Public Overloads Function Equals(ByVal A As String) As Boolean
    '	'todo: implement comparison logic
    '	Return False
    'End Function

    'Public Overrides Function GetHashCode() As Integer
    '	'todo: return a hash value for the object
    '	'for example, a common approach is to return ID.GetHashCode()
    '	Return MyBase.GetHashCode()
    'End Function
#End Region

#Region "Shared Methods"
    Public Shared Function NewList() As ClassificationList
        Return New ClassificationList()
    End Function

    Public Shared Function GetList() As ClassificationList
        Return CType(DataPortal.Fetch(New Criteria()), ClassificationList)
    End Function

    Public Shared Sub DeleteList()
        DataPortal.Delete(New Criteria())
    End Sub
#End Region

#Region "Constructors"
    Private Sub New()
        'Prevent direction creation
        AllowEdit = True
        AllowFind = True
        AllowNew = True
        AllowRemove = True
        AllowSort = True
    End Sub
#End Region

#Region "Criteria"
    <Serializable()> _
    Private Class Criteria
        Public Sub New()
        End Sub
    End Class
#End Region

#Region "OnAddNew"

    Protected Overrides Function OnAddNew() As Object
        Dim newObject As Classification = Classification.NewClassification()
        List.Add(newObject)
        Return newObject
    End Function


#End Region

#Region "Data Access"
    Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
        Dim crit As Criteria = CType(Criteria, Criteria)
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_classificationlist"))
        Try
            While dr.Read()
                List.Add(Classification.GetClassification(dr))
            End While
        Finally
            dr.Close()
        End Try
    End Sub

    Protected Overrides Sub DataPortal_Update()
        'loop through each deleted child object and call its update method
        For Each Classification As Classification In deletedList
            Classification.Update()
        Next

        'then clear the list of deleted objects because they are truly gone now
        deletedList.Clear()

        'loop through each non-deleted child object and call its update method
        For Each Classification As Classification In List
            Classification.Update()
        Next
    End Sub

    'DataPortal_Delete supports direct object deletion.  If we don't want to
    'support direct delition, delete this method. 
    Protected Overrides Sub DataPortal_Delete(ByVal Criteria As Object)
        Dim crit As Criteria = CType(Criteria, Criteria)
        'delete all Classification data that matches the criteria
    End Sub
#End Region

End Class
