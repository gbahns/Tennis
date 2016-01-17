Imports System.Data.Common
Imports Csla
Imports Library.Data
Imports Library.Data.Utility
Imports system.Threading.Thread

Public Module DataAccess

#Region " Local Declarations "

    Private connString As String = GetConnectionString("Tennis")

#End Region

#Region " Public Methods "

    Public Function GetParameter() As IDataParameter
        Return DAV.Data.DataAccess.GetParameter()
    End Function

    Public Function GetParameter(ByVal name As String, ByVal value As Object) As IDataParameter
        Return DAV.Data.DataAccess.GetParameter(name, value)
    End Function

    Public Function GetParameter(ByVal name As String, ByVal value As Object, ByVal direction As ParameterDirection) As IDataParameter
        Dim param As IDataParameter = DAV.Data.DataAccess.GetParameter(name, value)
        param.Direction = direction
        Return param
    End Function

    Public Function GetParameter(ByVal name As String, ByVal dbType As DbType, ByVal size As Integer, ByVal direction As ParameterDirection) As IDataParameter
        Return DAV.Data.DataAccess.GetParameter(name, dbType, size, direction)
    End Function

    Public Function GetParameter(ByVal name As String, ByVal dbType As DbType, ByVal size As Integer, ByVal sourceColumn As String, ByVal sourceVersion As DataRowVersion) As IDataParameter
        Return DAV.Data.DataAccess.GetParameter(name, dbType, size, sourceColumn, sourceVersion)
    End Function


    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains the value from a database function
    ''' </summary>
    ''' <param name="funcName">The name of the function that will be executed</param>
    ''' <param name="parameters">The function's parameters</param>
    ''' <returns type="Object">The return value of the function</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecFunction(ByVal funcName As String, ByVal ParamArray parameters() As IDataParameter) As Object
        Return DAV.Data.DataAccess.ExecFunction(connString, funcName, parameters)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains the value from a database function
    ''' </summary>
    ''' <param name="funcName">The name of the function that will be executed</param>
    ''' <param name="parameterValues">The function's parameters</param>
    ''' <returns type="Object">The return value of the function</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecFunction(ByVal funcName As String, ByVal ParamArray parameterValues() As Object) As Object
        Dim parameters As IDataParameter() = DAV.Data.DataAccess.GetParameters(connString, funcName)
        PopulateParameterValues(parameters, parameterValues)
        Dim result As Object = DAV.Data.DataAccess.ExecFunction(connString, funcName, parameters)
        Return result
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.  This method does not have any parameters, but 
    ''' will most likely not be used when using Oracle since the resultset is returned as a parameter (ref cursor).
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <returns type="SmartDataReader">The datareader containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecReader(ByVal procName As String) As SafeDataReader
        Dim parameters As IDataParameter() = DAV.Data.DataAccess.GetParameters(connString, procName)
        Dim reader As IDataReader = DAV.Data.DataAccess.ExecReader(connString, procName, parameters)
        Return New SafeDataReader(reader)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameters">The stored procedure's parameters</param>
    ''' <returns type="SmartDataReader">The datareader containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecReader(ByVal procName As String, ByVal ParamArray parameters() As IDataParameter) As SafeDataReader
        Dim reader As IDataReader = DAV.Data.DataAccess.ExecReader(connString, procName, parameters)
        Return New SafeDataReader(reader)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameterValues">The stored procedure's parameter values, must be listed
    ''' in the same order as they are in the stored procedure.</param>
    ''' <returns type="SmartDataReader">The datareader containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecReader(ByVal procName As String, ByVal ParamArray parameterValues() As Object) As SafeDataReader
        Dim parameters As IDataParameter() = DAV.Data.DataAccess.GetParameters(connString, procName)
        PopulateParameterValues(parameters, parameterValues)
        Dim reader As IDataReader = DAV.Data.DataAccess.ExecReader(connString, procName, parameters)
        Return New SafeDataReader(reader)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <returns type="SmartDataReader">The dataset containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecDataSet(ByVal procName As String) As DataSet
        Return DAV.Data.DataAccess.ExecDataSet(connString, procName)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameters">The stored procedure's parameters</param>
    ''' <returns type="SmartDataReader">The dataset containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecDataSet(ByVal procName As String, ByVal ParamArray parameters() As IDataParameter) As DataSet
        Return DAV.Data.DataAccess.ExecDataSet(connString, procName, parameters)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Obtains data returned from a "fetch" stored procedure.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameterValues">The stored procedure's parameter values, must be listed
    ''' in the same order as they are in the stored procedure.</param>
    ''' <returns type="SmartDataReader">The dataset containing the resultset(s)</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecDataSet(ByVal procName As String, ByVal ParamArray parameterValues() As Object) As DataSet
        Dim parameters As IDataParameter() = DAV.Data.DataAccess.GetParameters(connString, procName)
        PopulateParameterValues(parameters, parameterValues)
        Return DAV.Data.DataAccess.ExecDataSet(connString, procName, parameters)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/14/2005</created>
    ''' <summary>
    ''' Executes Create, Update, and Delete stored procedures.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameters">The stored procedure's parameters</param>
    ''' <returns type="ArrayList">The output parameter values</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecUpdate(ByVal procName As String, ByVal ParamArray parameters() As IDataParameter) As Hashtable
        Dim rows As Integer
        If Transaction Is Nothing Then
            rows = DAV.Data.DataAccess.ExecUpdate(connString, procName, parameters)
        Else
            rows = DAV.Data.DataAccess.ExecUpdate(Transaction, procName, parameters)
        End If
        Return GetOutputParameterValues(parameters)
    End Function

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/14/2005</created>
    ''' <summary>
    ''' Executes Create, Update, and Delete stored procedures.
    ''' </summary>
    ''' <param name="procName">The name of the stored procedure that will be executed</param>
    ''' <param name="parameterValues">The stored procedure's parameter values, must be listed
    ''' in the same order as they are in the stored procedure.</param>
    ''' <returns type="ArrayList">The output parameter values</returns>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Public Function ExecUpdate(ByVal procName As String, ByVal ParamArray parameterValues() As Object) As ArrayList ' Hashtable
        'Dim outputParameters As New Hashtable()
        Dim parameters As IDataParameter() = DAV.Data.DataAccess.GetParameters(connString, procName)
        PopulateParameterValues(parameters, parameterValues)
        Dim rows As Integer = 0
        If Transaction Is Nothing Then
            rows = DAV.Data.DataAccess.ExecUpdate(connString, procName, parameters)
        Else
            rows = DAV.Data.DataAccess.ExecUpdate(Transaction, procName, parameters)
        End If
        Return GetOutputParameterValuesAL(parameters)
    End Function

    Private mTransactions As New System.Collections.Generic.Dictionary(Of Int32, IDbTransaction)

    Private Property Transaction() As IDbTransaction
        Get
            If Not mTransactions.ContainsKey(CurrentThread.ManagedThreadId) Then Return Nothing
            Return mTransactions(CurrentThread.ManagedThreadId)
        End Get
        Set(ByVal value As IDbTransaction)
            If value Is Nothing Then
                mTransactions.Remove(CurrentThread.ManagedThreadId)
            Else
                mTransactions(CurrentThread.ManagedThreadId) = value
            End If
        End Set
    End Property

    Public Sub BeginTransaction()
        If Not Transaction Is Nothing Then
            Throw New InvalidOperationException("BeginTransaction was called with an active transaction already on the current thread.")
        End If
        Transaction = DAV.Data.DataAccess.BeginTransaction(connString)
    End Sub

    Public Sub CommitTransaction()
        If Transaction Is Nothing Then
            Throw New InvalidOperationException("CommitTransaction was called with no active transaction on the current thread.")
        End If
        Transaction.Commit()
        Transaction = Nothing
    End Sub

    Public Sub RollbackTransaction()
        If Transaction Is Nothing Then
            Throw New InvalidOperationException("RollbackTransaction was called with no active transaction on the current thread.")
        End If
        Transaction.Rollback()
        Transaction = Nothing
    End Sub

#End Region

#Region " Private Methods "

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Populates the values for the parameters.  This is pretty generic, some applications require
    ''' more specific values dependent on the database type.  If so, work on it.
    ''' </summary>
    ''' <param name="parameters">The parameter collection that will be assigned values</param>
    ''' <param name="values">The stored procedure's input parameter values</param>
    ''' <remarks>
    ''' </remarks>
    '''===================================================================================================
    Private Sub PopulateParameterValues(ByRef parameters As IDataParameter(), ByVal values() As Object)
        Dim valueIndex As Integer = 0

        For i As Integer = 0 To parameters.GetUpperBound(0)
            If parameters(i).Direction = ParameterDirection.Input OrElse parameters(i).Direction = ParameterDirection.InputOutput Then
                If values(valueIndex) Is Nothing Then
                    parameters(i).Value = DBNull.Value
                Else
                    If False Then
                        'If TypeOf (values(valueIndex)) Is Boolean Then
                        'If Convert.ToBoolean(values(valueIndex)) = True Then
                        '    parameters(i).Value = "Y"
                        'Else
                        '    parameters(i).Value = "N"
                        'End If
                        'ElseIf TypeOf (values(valueIndex)) Is String Then
                        '    If values(valueIndex).ToString() = String.Empty Then
                        '        'parameters(i).Size = 20
                        '        parameters(i).Value = DBNull.Value
                        '    Else
                        '        'parameters(i).Size = values(valueIndex).ToString.Length
                        '        parameters(i).Value = values(valueIndex)
                        '    End If
                    ElseIf TypeOf (values(valueIndex)) Is SmartDate Then
                        parameters(i).Value = DirectCast(values(valueIndex), SmartDate).DBValue
                    Else
                        parameters(i).Value = values(valueIndex)
                    End If
                End If

                valueIndex += 1
            End If
        Next
    End Sub

    '''===================================================================================================
    ''' <author>Jon H. (jonh@smartcomtech.com)</author>
    ''' <created>01/11/2005</created>
    ''' <summary>
    ''' Populates the values for the parameters
    ''' </summary>
    ''' <param name="parameters">The parameter collection that will be assigned values</param>
    ''' <returns>ArrayList</returns>
    ''' <remarks></remarks>
    '''===================================================================================================
    Private Function GetOutputParameterValuesAL(ByVal parameters() As IDataParameter) As ArrayList
        Dim outputParameters As New ArrayList

        For i As Integer = 0 To parameters.GetUpperBound(0)
            If (parameters(i).Direction = ParameterDirection.Output OrElse parameters(i).Direction = ParameterDirection.InputOutput) And _
                parameters(i).DbType <> DbType.Object Then
                If TypeOf parameters(i).Value Is DBNull Then
                    outputParameters.Add(Nothing)
                Else
                    outputParameters.Add(parameters(i).Value)
                End If
            End If
        Next

        Return outputParameters
    End Function

    Private Function GetOutputParameterValues(ByVal parameters() As IDataParameter) As Hashtable
        Dim outputParameters As New Hashtable

        For i As Integer = 0 To parameters.GetUpperBound(0)
            If (parameters(i).Direction = ParameterDirection.Output OrElse parameters(i).Direction = ParameterDirection.InputOutput) Then
                If TypeOf parameters(i).Value Is DBNull Then
                    outputParameters.Add(parameters(i).ParameterName, String.Empty)
                Else
                    outputParameters.Add(parameters(i).ParameterName, parameters(i).Value.ToString())
                End If
            End If
        Next

        Return outputParameters
    End Function

#End Region

End Module
