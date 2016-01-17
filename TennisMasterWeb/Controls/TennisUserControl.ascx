<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TennisUserControl.ascx.cs" Inherits="Tennis.Controls.TennisUserControl" %>

<table id="DialogBox" border="0" cellspacing="5" cellpadding="0" class="Dialog">
	<caption id="DialogCaption" runat="server" enableviewstate="false">
		Dang <%#Caption%>
	</caption>
	<tr>
		<td>
			Username<br>
			<asp:TextBox runat="server" ID="UsernameTextBox" Width="200" />
			<%--						
			<asp:RequiredFieldValidator ID="DateRequired" runat="server" ControlToValidate="Date"
				ErrorMessage="Please enter a date" EnableClientScript="true" Display="Dynamic" />
			<asp:CompareValidator ID="DateValid" runat="server" ControlToValidate="Date" ErrorMessage="Please enter a valid date"
				EnableClientScript="true" Display="Dynamic" Type="Date" Operator="GreaterThan"
				ValueToCompare="2003/01/01" />
			--%>					
		</td>
	</tr>
	<tr>
		<td>
			Email Address<br />
			<asp:TextBox runat="server" ID="EmailAddressTextBox" Width="200" />
		</td>
	</tr>
</table>
