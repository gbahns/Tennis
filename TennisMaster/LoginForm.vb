Public Class LoginForm

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnnetsec/html/SecNetHT06.asp).  
    ' The custom principal can then be attached to the current threads principal as follows: 
    '     Thread.CurrentThread.CurrentPrincipal = CustomPrincipal, 
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information such as the username, display name, etc. 
    ' encapsulated in the CustomPrincipal object.

	Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
		Me.Close()
	End Sub

	Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
		Me.Close()
	End Sub
End Class
