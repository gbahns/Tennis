<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="EventSummary.aspx.cs" Inherits="Tennis.EventSummary" Title="Event Summary" %>

<%@ Register TagPrefix="uc1" TagName="EventSummaryControl" Src="~/Controls/EventSummaryControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc1:EventSummaryControl ID="PlayerControl1" runat="server" />
</asp:Content>
