<%@ Page language="c#" Codebehind="Home.aspx.cs" AutoEventWireup="True" Inherits="Tennis.Home" MasterPageFile="~/Tennis.Master" Title="Home" EnableSessionState="true" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
		<tr>
			<td>
				<a href="Event.aspx">Add an event</a>
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
</asp:Content>