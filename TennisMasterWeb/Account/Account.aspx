<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Tennis.Account.Account" Title="Account Info" %>

<%@ Register TagPrefix="uc1" TagName="TennisUserControl" Src="~/Controls/TennisUserControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<uc1:TennisUserControl ID="TennisUserControl1" runat="server" />


	<asp:HyperLink runat="server" ID="ChangePasswordLink" NavigateUrl="~/Account/changePassword.aspx" Text="Change Password" />
	
</asp:Content>
