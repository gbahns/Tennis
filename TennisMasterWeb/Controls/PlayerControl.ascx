<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayerControl.ascx.cs" Inherits="Tennis.Controls.PlayerControl" %>

<table id="DialogBox" border="0" cellspacing="5" cellpadding="0" class="Dialog">
	<caption id="DialogCaption" runat="server" enableviewstate="false">
		<%#Caption%>
	</caption>
	<tr>
		<td>
			First Name<br>
			<asp:TextBox runat="server" ID="FirstName" Width="200" />
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
			Last Name<br />
			<asp:TextBox runat="server" ID="LastName" Width="200" />
		</td>
	</tr>
</table>
<asp:ValidationSummary ID="vldSummary" runat="server" HeaderText="Validation Failed" DisplayMode="BulletList"></asp:ValidationSummary>
<%--
	<asp:rangevalidator id="RangeValidator1" runat="server" errormessage="RangeValidator"></asp:rangevalidator>
	<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="RegularExpressionValidator"></asp:regularexpressionvalidator>
	<asp:customvalidator id="CustomValidator1" runat="server" errormessage="CustomValidator"></asp:customvalidator>
	--%>
