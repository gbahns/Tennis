<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="Tennis.EventListPage" Title="Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:GridView ID="GridView1" runat="server" CssClass="Data" AutoGenerateColumns="false"
		AlternatingRowStyle-CssClass="AltItem" HeaderStyle-CssClass="DataHeader" CellPadding="0"
		CellSpacing="0" AllowSorting="True"  >
		<Columns>
			<asp:HyperLinkField ItemStyle-Wrap="False" 
				DataNavigateUrlFormatString="Event.aspx?id={0}"
				DataNavigateUrlFields="ID" HeaderText="Event Name" DataTextField="Name" />
			<%--<asp:BoundField ItemStyle-Wrap="False" HeaderText="Event Name" DataField="Name" />--%>
			<asp:BoundField ItemStyle-Wrap="False" HeaderText="Begin Date" DataField="BeginDateText" />
			<asp:BoundField ItemStyle-Wrap="False" HeaderText="End Date" DataField="EndDateText" />
			
<%--			<asp:HyperLinkField ItemStyle-Wrap="False" 
				DataTextFormatString="{0:ddd}" DataNavigateUrlFormatString="Match.aspx?id={0}"
				DataNavigateUrlFields="ID"  HeaderText="" DataTextField="MatchDateAsDate" />
			<asp:HyperLinkField ItemStyle-Wrap="False" 
				DataTextFormatString="{0:MM-dd-yyyy}" DataNavigateUrlFormatString="Match.aspx?id={0}"
				DataNavigateUrlFields="ID" SortExpression="MatchDate" HeaderText="Date" DataTextField="MatchDateAsDate" />
			<asp:HyperLinkField DataNavigateUrlFormatString="MatchList.aspx?EventID={0}" DataNavigateUrlFields="EventID"
				SortExpression="EventName" HeaderText="Event" DataTextField="EventName" />
			<asp:HyperLinkField DataNavigateUrlFormatString="MatchList.aspx?ClassificationID={0}"
				DataNavigateUrlFields="ClassID" SortExpression="Classification" HeaderText="Classification"
				DataTextField="ClassName" />
			<asp:HyperLinkField DataNavigateUrlFormatString="Player.aspx?id={0}" DataNavigateUrlFields="OpponentID"
				SortExpression="OpponentName" HeaderText="Opponent" DataTextField="OpponentName" />
			<asp:BoundField DataField="ResultScore"/>
--%>			
		</Columns>
	</asp:GridView>
	
</asp:Content>
