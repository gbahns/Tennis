Module Util
    Public Function IDParam(ByVal ID As Integer, ByVal IsNew As Boolean) As Object
        If IsNew Then
            Return DBNull.Value
        Else
            Return ID
        End If
    End Function
End Module
