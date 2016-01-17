<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayerMatchList.aspx.cs"
	Inherits="PlayerMatches" %>

<% log.Info("Page start"); %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Player Match History</title>
	<!-- 
	<link href="tennis.css" type="text/css" rel="stylesheet" /> 
	-->
</head>
<body>
	<% log.Info("page body"); %>
	<form id="form1" runat="server">
		<div>
			<!-- onsortcommand="Page_Sort" onitemdatabound="Item_DataBound" -->
			Player Match History<br />
			This page shows a list of the 10 most recent matches.<br />
			<asp:GridView ID="GridView1" runat="server" CssClass="Data" AutoGenerateColumns="false"
				AlternatingRowStyle-CssClass="AltItem" HeaderStyle-CssClass="DataHeader" CellPadding="1"
				CellSpacing="1" AllowSorting="True">
				<Columns>
					<asp:HyperLinkField ItemStyle-Wrap="False" ItemStyle-Font-Names="Lucida Console, Courier New"
						DataTextFormatString="{0:ddd MM-dd-yyyy}" DataNavigateUrlFormatString="Match.aspx?MatchID={0}"
						DataNavigateUrlFields="ID" SortExpression="MatchDate" HeaderText="Date" DataTextField="MatchDateAsDate" />
					<asp:HyperLinkField DataNavigateUrlFormatString="MatchList.aspx?EventID={0}" DataNavigateUrlFields="EventID"
						SortExpression="EventName" HeaderText="Event" DataTextField="EventName" />
					<asp:HyperLinkField DataNavigateUrlFormatString="MatchList.aspx?ClassificationID={0}"
						DataNavigateUrlFields="ClassID" SortExpression="Classification" HeaderText="Classification"
						DataTextField="ClassName" />
					<asp:HyperLinkField DataNavigateUrlFormatString="MatchList.aspx?OpponentID={0}" DataNavigateUrlFields="OpponentID"
						SortExpression="OpponentName" HeaderText="Opponent" DataTextField="OpponentName" />
					<asp:BoundField DataField="ResultScore" />
				</Columns>
			</asp:GridView>
			<!--
		<asp:datagrid id="dataGrid" runat="server" cssclass="Data" alternatingitemstyle-cssclass="AltItem"
			headerstyle-cssclass="DataHeader" autogeneratecolumns="true" cellpadding="1" cellspacing="1"
			allowsorting="True" >
		</asp:datagrid>
					-->
		</div>
	</form>
	<% log.Info("page body complete"); %>
</body>
</html>
<% log.Info("Page end"); %>
