Imports CSLA.Security

Namespace Security

	''' <summary>
	''' 
	''' </summary>
	''' <remarks></remarks>
	Public Class UserIdentity
		Inherits BusinessIdentity

		Friend Shared Function LoadIdentity(ByVal UserName As String, ByVal Password As String) As UserIdentity
			Return CType(DataPortal.Fetch(New Criteria(UserName, Password)), UserIdentity)
		End Function

		<Serializable()> _
		Private Class Criteria
			Public Username As String
			Public Password As String

			Public Sub New(ByVal Username As String, ByVal Password As String)
				Me.Username = Username
				Me.Password = Password
			End Sub
		End Class

		Protected Sub New()
			' prevent direct creation
		End Sub

		Friend Function IsInRole(ByVal Role As String) As Boolean
			Return mRoles.Contains(Role)
		End Function

		''' <summary>
		''' Retrieves the identity data for a specific user.
		''' </summary>
		Protected Overrides Sub DataPortal_Fetch(ByVal Criteria As Object)
			Dim crit As Criteria = CType(Criteria, Criteria)

			mRoles.Clear()

			Dim dr As SafeDataReader = New SafeDataReader(DataAccess.ExecReader("csla_login", crit.Username, crit.Password))
            Try
                If dr.Read() Then
                    mUsername = crit.Username

                    If dr.NextResult Then
                        While dr.Read
                            mRoles.Add(dr.GetString(0))
                        End While
                    End If

                Else
                    mUsername = ""
                End If

            Finally
                dr.Close()
            End Try
        End Sub

	End Class

End Namespace
