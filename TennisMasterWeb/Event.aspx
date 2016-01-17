<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="Tennis.EventPage" %>
<%@ Register TagPrefix="uc1" TagName="EventControl" Src="~/Controls/EventControl.ascx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<uc1:EventControl ID="Control1" runat="server" />
</asp:Content>
