<Serializable()> _
Public Class Classification
    Inherits BusinessBase

    Private Shared log As ILog = LogManager.GetLogger(GetType(Classification).ToString())

#Region "Private Data"
    Private _ID As Int32
    Private _Name As String
    Private _USTAEquivalent As String
#End Region

#Region "Business Properties and Methods"
    Public ReadOnly Property ID() As Int32
        Get
            Return _ID
        End Get
    End Property

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            MarkDirty()
            BrokenRules.Assert("NameReq", "Name is required", _Name.Length = 0)
        End Set
    End Property

    Public Property USTAEquivalent() As String
        Get
            Return _USTAEquivalent
        End Get
        Set(ByVal value As String)
            _USTAEquivalent = value
            MarkDirty()
        End Set
    End Property
#End Region

#Region "System.Object Overrides"
    Public Overrides Function ToString() As String
        Return Name
    End Function

    Public Overloads Function Equals(ByVal A As Classification) As Boolean
        Return _ID = A._ID
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _ID.GetHashCode()
    End Function
#End Region

#Region "Shared Methods"
    Public Shared Function NewClassification() As Classification
        Return New Classification()
    End Function

    Public Shared Function NewClassification(ByVal Name As String, ByVal USTAEquivalent As String) As Classification
        Return New Classification(Name, USTAEquivalent)
    End Function

    Public Shared Function GetClassification(ByVal dr As SafeDataReader) As Classification
        Dim Classification As New Classification
        Classification.Fetch(dr)
        Return Classification
    End Function
#End Region

#Region "Constructors"
    Private Sub New(ByVal Name As String, ByVal USTAEquivalent As String)
        MarkAsChild()
        _Name = Name
        _USTAEquivalent = USTAEquivalent
    End Sub

    Private Sub New()
        'Prevent direction creation
        MarkAsChild()
    End Sub
#End Region

#Region "Data Access"
    Private Sub Fetch(ByVal dr As SafeDataReader)
        _ID = dr.GetInt32()
        _Name = dr.GetString()
        _USTAEquivalent = dr.GetString()
        MarkOld()
    End Sub

    Friend Sub Update()
        If Me.IsDeleted Then
            If Not Me.IsNew Then
                DataAccess.ExecUpdate("csla_delete_classification", ID)
            End If
            MarkNew()
        Else
            DataAccess.ExecUpdate("csla_save_classification", IDParam(_ID, IsNew), _Name, _USTAEquivalent)
            MarkOld()
        End If
    End Sub
#End Region

End Class
