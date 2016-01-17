<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Tennis.Account.ChangePassword" Title="Change Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ChangePassword ID="ChangePassword1" runat="server"  ContinueDestinationPageUrl="~/Home.aspx">
		<MailDefinition From="support@personaltracker.bahns.com" Subject="Password Change" BodyFileName="~/Account/ChangePassword.txt" />
	</asp:ChangePassword>
</asp:Content>
