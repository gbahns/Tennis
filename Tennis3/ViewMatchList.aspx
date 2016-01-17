<%@ page language="C#" autoeventwireup="true" inherits="ViewMatchList, App_Web_r3lxnij1" masterpagefile="tennis.master" %>

<asp:content ID="Content1" contentplaceholderid="title" runat="server">
	Player Match History
</asp:content>

<asp:content ID="Content2" contentplaceholderid="maincontent" runat="server">
    Player Match History<br />
				(<asp:literal id="txtRecord" runat="server" text="0-0" />) 
		<asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="true"   >
			<asp:ListItem>Last 10</asp:ListItem>
			<asp:ListItem>Last Week</asp:ListItem>
			<asp:ListItem>Last Month</asp:ListItem>
			<asp:ListItem>Last 3 Months</asp:ListItem>
			<asp:ListItem>This Year</asp:ListItem>
		</asp:DropDownList>
		<asp:GridView ID="GridView1" runat="server" cssclass="Data"  AutoGenerateColumns="false" AlternatingRowStyle-CssClass="AltItem"
			cellpadding="1" cellspacing="1" allowsorting="True" OnSorting="Page_Sort" OnRowDataBound="Item_Bound" >
			<Columns>
				<asp:HyperLinkField itemstyle-wrap="False" itemstyle-font-names="Lucida Console, Courier New" DataTextFormatString="{0:ddd MM-dd-yyyy}"
					datanavigateurlformatstring="Match.aspx?MatchID={0}" DataNavigateUrlFields="ID" sortexpression="MatchDate"
					headertext="Date" DataTextField="MatchDateAsDate" />
				<asp:HyperLinkField datanavigateurlformatstring="MatchList.aspx?EventID={0}" datanavigateurlfields="EventID"
					sortexpression="EventName" headertext="Event" datatextfield="EventName" />
				<asp:HyperLinkField datanavigateurlformatstring="MatchList.aspx?ClassificationID={0}" datanavigateurlfields="ClassID"
					sortexpression="Classification" headertext="Class" datatextfield="ClassName" />
				<asp:HyperLinkField datanavigateurlformatstring="MatchList.aspx?OpponentID={0}" datanavigateurlfields="OpponentID"
					sortexpression="OpponentName" headertext="Opponent" datatextfield="OpponentName" />
				<asp:BoundField HeaderText="Score" DataField="ResultScore" itemstyle-font-names="Lucida Console, Courier New" />
			</Columns>
		</asp:GridView>
					<!--
				<asp:BoundField HeaderText="Score" DataField="Result" />
				<asp:BoundField HeaderText="Score" DataField="Score" />
		<asp:datagrid id="dataGrid" runat="server" cssclass="Data" alternatingitemstyle-cssclass="AltItem"
			headerstyle-cssclass="DataHeader" autogeneratecolumns="true" cellpadding="1" cellspacing="1"
			allowsorting="True" >
		</asp:datagrid>
					-->
</asp:content>

