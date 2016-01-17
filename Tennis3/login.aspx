<%@ page language="c#" inherits="Tennis.login1, App_Web_r3lxnij1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>login</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="tennis.css">
	</head>
	<body>
	</body>
	<body class="Login">
		<form id="Form1" method="post" runat="server">
			<table cellspacing=1 cellpadding=1 border=0 id="Table1">
				<tr>
					<th class=Title colspan="2">Tennis Master</th>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td id="tdLoginFailed" class="Failed" runat="server">
					<span id="spnMessage" runat="server"/>
					</td>
				</tr>
				<tr>
					<td rowspan="3"><img alt="" src="images\TennisBall.gif"></td>
					<td class=Label>User ID<br><asp:textbox id="uid" runat="server"/></td>
				</tr>
				<tr>
					<td class=Label>Password<br><asp:textbox id="pwd" runat="server" textmode="Password"/></td>
				</tr>
				<tr>
					<td align="right"><asp:button id="btnSignOn" runat="server" text="Login" onclick="btnSignOn_Click" /></td>
				</tr>
			</table>
		</form>
	</body>
	<script>
		//alert('cool');
		//alert(Form1.uid.id);
		Form1.uid.focus();	
	</script>
</html>
