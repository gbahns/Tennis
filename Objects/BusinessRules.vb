Imports System.Collections.Specialized
Imports Library.Rules
Imports Microsoft.VisualBasic

Public Module BusinessRules
    Private log As ILog = LogManager.GetLogger(GetType(BusinessRules).ToString())

    Public Sub Inititalize()
        RulesFactory.Loader = AddressOf LoadBusinessRules
    End Sub

    Friend Function LoadBusinessRules(ByVal className As String) As IBusinessRules
        log.Debug("loading rules for " & className)
        'can we make this use the BusinessRules connection string instead of Tennis?
		Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_get_business_rules"))
        Dim rules As New Library.Rules.Dynamic.BusinessRules()
        Try
            While dr.Read()
                Dim propertyName As String = dr.GetString
                If propertyName.Length > 0 Then
                    rules.Required(propertyName) = dr.GetBoolean
                    rules.MinValue(propertyName) = dr.GetString
                    rules.MaxValue(propertyName) = dr.GetString
                    rules.Mask(propertyName) = dr.GetString
                    rules.RegularExpression(propertyName) = dr.GetString
                    'todo: don't add complex rule if it's blank
                    'rules.ComplexRules(propertyName).Add(dr.GetString)
                    dr.GetString()
                    rules.DefaultText(propertyName) = dr.GetString
                    rules.LabelText(propertyName) = dr.GetString
                    rules.Tooltip(propertyName) = dr.GetString
                Else
                    'todo: class-level rules
                    '_BusinessRules.ComplexRules(Me.GetType.ToString).Add(dr.GetString("ComplexRules"))
                End If
            End While
            Return rules
        Finally
            dr.Close()
        End Try
    End Function

    Public Function StringRequired(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        e.Description = e.PropertyName & " is required"
        Return CStr(CallByName(target, e.PropertyName, CallType.Get)).Length > 0
    End Function

    Public Function ComboRequired(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        e.Description = e.PropertyName & " is required"
        Return CInt(CallByName(target, e.PropertyName, CallType.Get)) > 0
    End Function

    'Public Function DateRequired(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
    '    e.Description = e.PropertyName & " is required"
    '    Return Not DirectCast(CallByName(target, e.PropertyName, CallType.Get), SmartDate).IsEmpty
    'End Function

    Public Function DateRequired(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        e.Description = e.PropertyName & " is required"
        Return CStr(CallByName(target, e.PropertyName, CallType.Get)).Length > 0
    End Function

    Public Function DateIsInPast(ByVal target As Object, ByVal e As BrokenRules.RuleArgs) As Boolean
        e.Description = e.PropertyName & " must be in the past"
        Return CDate(CallByName(target, e.PropertyName, CallType.Get)) < Date.Now
    End Function

End Module
