Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("RuleEngine")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("")> 
<Assembly: AssemblyProduct("RuleEngine")> 
<Assembly: AssemblyCopyright("Copyright @  2004")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(False)> 
<Assembly: ComVisible(False)> 

'todo: declare minimum security by uncommenting the last 2 lines and configuring assembly security correctly
'security configuration will need adjusting for remoting, database, etc.
<Assembly: IsolatedStorageFilePermission(SecurityAction.RequestMinimum, UserQuota:=1048576)> 
'<Assembly: SecurityPermission(SecurityAction.RequestRefuse, UnmanagedCode:=True)> 
'<Assembly: FileIOPermission(SecurityAction.RequestOptional, Unrestricted:=True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("cfe4f273-bdb0-4e29-996a-501a51b0aaf4")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 
