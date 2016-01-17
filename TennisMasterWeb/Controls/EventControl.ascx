<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventControl.ascx.cs" Inherits="Tennis.Controls.EventControl" %>
<%@ Register tagprefix="bahns" assembly="Bahns.Web.UI.WebControls" namespace="Bahns.Web.UI.WebControls" %>

<table id="DialogBox" border="0" cellspacing="5" cellpadding="0" class="Dialog">
	<caption id="DialogCaption" runat="server" enableviewstate="false">
		<%#Caption%>
	</caption>
	<tr>
		<td colspan="2">
			Event Name<br>
			<asp:TextBox runat="server" ID="EventName" Width="200" />
		</td>
	</tr>
	<tr>
		<td colspan="2">
			Classification<br />
			<asp:DropDownList ID="Classification" runat="server" DataValueField="ID" DataTextField="Name" />
		</td>
	</tr>
	<tr>
		<td>
			Date<br>
			<bahns:DatePicker runat="server" ID="BeginDate" Width="200" />
		</td>
		<td>
			Date<br>
			<bahns:DatePicker runat="server" ID="EndDate" Width="200" />
		</td>
	</tr>
	<tr><td>
			<asp:CheckBox ID="League" runat="server" /> League<br>
			<asp:CheckBox ID="Tournament" runat="server" /> Tournament<br>
			<asp:CheckBox ID="TeamPlay" runat="server" /> Team Play<br>
	
	</td></tr>
</table>
<asp:ValidationSummary ID="vldSummary" runat="server" HeaderText="Validation Failed" DisplayMode="BulletList"></asp:ValidationSummary>
