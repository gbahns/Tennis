<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EventSummaryControl.ascx.cs" Inherits="Tennis.Controls.EventSummaryControl" %>
	
<%--<asp:CheckBox runat="server" ID="CheckBox1" Text="All Types" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox2" Text="Leagues" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox3" Text="Tournaments" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox4" Text="Other" Checked="true" />
--%>

Event Filter<br />
<asp:DropDownList runat="server" ID="EventTypeDrowDownList" AutoPostBack="true" DataSource="<%# Enum.GetNames(typeof(TennisObjects.EventTypeEnum)) %>" OnSelectedIndexChanged="EventTypeDrowDownList_SelectedIndexChanged" />
<br />
<br />

<asp:GridView ID="GridView2" runat="server" CssClass="Data" AutoGenerateColumns="false"
	AlternatingRowStyle-CssClass="AltItem" FooterStyle-CssClass="Footer" CellPadding="0" CellSpacing="0" AllowSorting="True"
	OnSorting="GridView2_Sorting" RowStyle-HorizontalAlign="right" ShowFooter="true">
	<Columns>
		<%--GamesLost MatchesWon SetsWon MatchesPct GamesWon MatchesLost TennisEvent MatchesPlayed SetsLost SetsPct GamesPct --%>
		
		<asp:HyperLinkField ItemStyle-Wrap="False" DataNavigateUrlFormatString="~/PlayerMatchList.aspx?eventid={0}" 
			DataNavigateUrlFields="ID"  HeaderText="Event" DataTextField="Name" ItemStyle-HorizontalAlign="left" />
			
		<%--<asp:HyperLinkField ItemStyle-Wrap="False" DataNavigateUrlFormatString="~/Event.aspx?id={0}" 
			DataNavigateUrlFields="ID"  HeaderText="Event" DataTextField="Name" ItemStyle-HorizontalAlign="left" />--%>
			
		<%--<asp:BoundField ItemStyle-Wrap="False" HeaderText="Event" DataField="Name" ItemStyle-HorizontalAlign="left" />--%>
		<%--<asp:BoundField ItemStyle-Wrap="False" HeaderText="StartDate" DataField="StartDateValue" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="false" />--%>
		<%--<asp:BoundField ItemStyle-Wrap="false" DataField="StartDate" DataFormatString="" SortExpression="StartDate" HeaderText="Start" />
		<asp:BoundField ItemStyle-Wrap="false" DataField="FirstMatchDate" DataFormatString="" SortExpression="FirstMatchDate" HeaderText="First" />--%>
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="Class" DataField="Classification" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="#" DataField="MatchesPlayed" ItemStyle-Font-Size="78%" ItemStyle-ForeColor="gray" FooterStyle-Font-Size="78%" FooterStyle-ForeColor="gray" />
		<asp:BoundField ItemStyle-Width="0px" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="W" DataField="MatchesWon" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="L" DataField="MatchesLost" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="Pct" DataField="MatchesPct" DataFormatString="{0:F3}" HtmlEncode="false" />
		<asp:BoundField ItemStyle-Width="0px" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="S-W" DataField="SetsWon" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="S-L" DataField="SetsLost" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="Pct" DataField="SetsPct" DataFormatString="{0:F3}" HtmlEncode="false" />
		<asp:BoundField ItemStyle-Width="0px" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="G-W" DataField="GamesWon" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="G-L" DataField="GamesLost" />
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="Pct" DataField="GamesPct" DataFormatString="{0:F3}" HtmlEncode="false" />
		<%--
			Ways to view match summary
			by event (done)
			by player
			by class
			by tournament
			by league
			by year
			by month
			by day of week
			by time of day
			--%>
	</Columns>
</asp:GridView>
