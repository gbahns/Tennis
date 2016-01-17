<%@ Page Language="c#" Codebehind="Match.aspx.cs" AutoEventWireup="True" Inherits="Tennis.MatchEdit" MasterPageFile="~/Tennis.Master" %>

<%@ Register TagPrefix="uc1" TagName="MatchControl" Src="~/Controls/MatchControl.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<uc1:MatchControl runat="server" />
</asp:Content>