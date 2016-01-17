<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="ConfirmNewAccount.aspx.cs" Inherits="Tennis.Account.ConfirmNewAccount" Title="Account Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	Your new account has been confirmed.<br />
	<br />
	<asp:HyperLink runat="server" NavigateUrl="~/Account/Login.aspx" />
</asp:Content>
