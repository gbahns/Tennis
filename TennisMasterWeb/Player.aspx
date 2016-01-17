<%@ Page Language="c#" Codebehind="Player.aspx.cs" AutoEventWireup="True" Inherits="Tennis.PlayerEdit" MasterPageFile="~/Tennis.Master" %>

<%@ Register TagPrefix="uc1" TagName="PlayerControl" Src="~/Controls/PlayerControl.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<uc1:PlayerControl ID="PlayerControl1" runat="server" />
</asp:Content>
