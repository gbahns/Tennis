<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="OpponentSummary.aspx.cs" Inherits="Tennis.OpponentSummary" Title="Player Summary" %>

<%@ Register TagPrefix="uc1" TagName="OpponentSummaryControl" Src="~/Controls/OpponentSummaryControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc1:OpponentSummaryControl ID="PlayerControl1" runat="server" />
</asp:Content>
