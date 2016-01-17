<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlayerMatchList.aspx.cs" Inherits="PlayerMatches" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Player Match History</title>
</head>
<body>
    <form id="form1" runat="server">
    <div><!-- onsortcommand="Page_Sort" onitemdatabound="Item_DataBound" -->
    Player Match History
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true">
		</asp:GridView>
					<!--
		<asp:datagrid id="dataGrid" runat="server" cssclass="Data" alternatingitemstyle-cssclass="AltItem"
			headerstyle-cssclass="DataHeader" autogeneratecolumns="true" cellpadding="1" cellspacing="1"
			allowsorting="True" >
		</asp:datagrid>
				<asp:hyperlinkcolumn itemstyle-wrap="False" itemstyle-font-names="Lucida Console, Courier New" datatextformatstring="{0:ddd MM-dd-yyyy hh:mmtt}"
					datanavigateurlformatstring="Match.aspx?MatchID={0}" datanavigateurlfield="ID" sortexpression="MatchDate"
					headertext="Date" datatextfield="MatchDate" />
				<asp:hyperlinkcolumn datanavigateurlformatstring="MatchList.aspx?EventID={0}" datanavigateurlfield="EventID"
					sortexpression="EventName" headertext="Event" datatextfield="EventName" />
				<asp:hyperlinkcolumn datanavigateurlformatstring="MatchList.aspx?ClassificationID={0}" datanavigateurlfield="ClassID"
					sortexpression="Classification" headertext="Classification" datatextfield="ClassName" />
				<asp:hyperlinkcolumn datanavigateurlformatstring="MatchList.aspx?OpponentID={0}" datanavigateurlfield="OpponentID"
					sortexpression="OpponentName" headertext="Opponent" datatextfield="OpponentName" />
					-->
    </div>
    </form>
</body>
</html>
