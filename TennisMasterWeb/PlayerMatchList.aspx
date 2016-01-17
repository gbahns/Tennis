<%@ Page Language="C#" AutoEventWireup="true" Inherits="Tennis.PlayerMatches" Codebehind="PlayerMatchList.aspx.cs" MasterPageFile="~/Tennis.Master" Title="Match List" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<!-- onsortcommand="Page_Sort" onitemdatabound="Item_DataBound" -->
	
	<asp:DropDownList runat="server" ID="TimeSpan" AutoPostBack="true" OnSelectedIndexChanged="TimeSpan_SelectedIndexChanged" >
		<asp:ListItem Text="Last 10" Selected="true" />
		<asp:ListItem Text="Last 20" />
		<asp:ListItem Text="Last 50" />
		<asp:ListItem Text="Last Month" />
		<asp:ListItem Text="Last 2 Months" />
		<asp:ListItem Text="Last Year" />
		<asp:ListItem Text="All" />
	</asp:DropDownList>
	
	<asp:Label runat="server" ID="TimeSpanLabel" />
	<br /><br />

	(<asp:literal id="txtRecord" runat="server" text="0-0" />) 
	
	<asp:GridView ID="GridView1" runat="server" CssClass="Data" AutoGenerateColumns="false"
		AlternatingRowStyle-CssClass="AltItem" CellPadding="0"
		CellSpacing="0" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting" OnDataBound="GridView1_DataBound" >
		<Columns>
			<asp:BoundField ItemStyle-Wrap="False" HeaderText="" DataField="MatchDateAsDate" DataFormatString="{0:ddd}" Visible="false"/>
			
			<asp:HyperLinkField ItemStyle-Wrap="False" 
				DataTextFormatString="{0:ddd}" DataNavigateUrlFormatString="Match.aspx?id={0}"
				DataNavigateUrlFields="ID" HeaderText="" DataTextField="MatchDateAsDate" />
			<asp:HyperLinkField ItemStyle-Wrap="False" 
				DataTextFormatString="{0:MM-dd-yyyy}" DataNavigateUrlFormatString="Match.aspx?id={0}"
				DataNavigateUrlFields="ID" SortExpression="MatchDate" HeaderText="Date" DataTextField="MatchDateAsDate" />
			<asp:HyperLinkField DataNavigateUrlFormatString="PlayerMatchList.aspx?eventid={0}" DataNavigateUrlFields="EventID"
				SortExpression="EventName" HeaderText="Event" DataTextField="EventName" />
			<asp:HyperLinkField DataNavigateUrlFormatString="PlayerMatchList.aspx?classificationid={0}"
				DataNavigateUrlFields="ClassID" SortExpression="Classification" HeaderText="Class"
				DataTextField="ClassName" />
			<asp:HyperLinkField DataNavigateUrlFormatString="PlayerMatchList.aspx?opponentid={0}" DataNavigateUrlFields="OpponentID"
				SortExpression="OpponentName" HeaderText="Opponent" DataTextField="OpponentName" />
			<asp:BoundField DataField="ResultScore"/>
		</Columns>
	</asp:GridView>


	<a href="Match.aspx">Add a match</a>

	<!--
	<asp:datagrid id="dataGrid" runat="server" cssclass="Data" alternatingitemstyle-cssclass="AltItem"
	headerstyle-cssclass="DataHeader" autogeneratecolumns="true" cellpadding="1" cellspacing="1"
	allowsorting="True" >
	</asp:datagrid>
			-->
</asp:Content>
