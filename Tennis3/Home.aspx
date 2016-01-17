<%@ page language="c#" inherits="Tennis.Home, App_Web_ipe_bnvk" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Tennis Master Home</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="tennis.css" type="text/css" rel="stylesheet">
		<link href="tennis-print.css" type="text/css" rel="stylesheet" media="print">
	</head>
	<body>
		<div id="content">
			<h2><%=Session["PlayerName"]%></h2>
			<table>
				<tr>
					<td>
						<a href="Player.aspx">Add an opponent</a>
					</td>
				</tr>
				<tr>
					<td>
						<a href="Match.aspx">Add a match</a>
					</td>
				</tr>
			</table>
			<!-- 
			<asp:table >
				<asp:tablerow>
					<asp:tablecell>
						<a href="PlayerAdd.aspx">Add an opponent</a>
					</asp:tablecell>
				</asp:tablerow>
				<asp:tablerow>
					<asp:tablecell>
						<a href="MatchAdd.aspx">Add a match</a>
					</asp:tablecell>
				</asp:tablerow>
			</asp:table> 
			-->
			<form id="Form1" method="post" runat="server">
				<% /*
				<asp:datagrid id="DataGrid1" runat="server" enableviewstate="false" showfooter="True" 
				datamember="Users" allowsorting="False" datakeyfield="id" DataSource="<%# dsUsers >">
				<asp:datagrid id="dataGrid" runat="server" cssclass="Data" headerstyle-cssclass="DataHeader" AutoGenerateColumns="False" cellpadding="3" cellspacing="1" allowsorting="True" onsortcommand="Page_Sort">
					<columns>
						<asp:hyperlinkcolumn headertext="ID" datanavigateurlfield="id" datanavigateurlformatstring="Player.aspx?id={0}" datatextfield="id" sortexpression="id asc"/>
						<asp:boundcolumn datafield="uid" headertext="User ID" sortexpression="uid asc"></asp:boundcolumn>
						<asp:boundcolumn datafield="playerid" headertext="Player ID" sortexpression="playerid asc"></asp:boundcolumn>
						<asp:boundcolumn datafield="roleid" headertext="Role ID" sortexpression="roleid asc"></asp:boundcolumn>
					</columns>
				</asp:datagrid>
				*/ %>
			</form>
		</div>
	</body>
</html>
