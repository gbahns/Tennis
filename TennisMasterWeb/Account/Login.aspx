<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tennis.Login" MasterPageFile="~/Tennis.Master" Title="Login" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:Login ID="Login1" runat="server" 
		PasswordRecoveryText="Forgot Password?" PasswordRecoveryUrl="~/Account/RecoverPassword.aspx" 
		CreateUserText="New User?" CreateUserUrl="~/Account/NewUser.aspx" >
	</asp:Login>
</asp:Content>
