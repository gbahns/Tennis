<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpponentSummaryControl.ascx.cs" Inherits="Tennis.Controls.OpponentSummaryControl" %>

<asp:CheckBox runat="server" ID="CheckBox1" Text="All Types" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox2" Text="All Types" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox3" Text="All Types" Checked="true" />
<asp:CheckBox runat="server" ID="CheckBox4" Text="All Types" Checked="true" />

<asp:GridView ID="GridView2" runat="server" CssClass="Data" AutoGenerateColumns="false"
	AlternatingRowStyle-CssClass="AltItem" FooterStyle-CssClass="Footer" CellPadding="0" CellSpacing="0" AllowSorting="True"
	OnSorting="GridView2_Sorting" RowStyle-HorizontalAlign="right" ShowFooter="true">
	<Columns>
		<%--GamesLost MatchesWon SetsWon MatchesPct GamesWon MatchesLost TennisEvent MatchesPlayed SetsLost SetsPct GamesPct --%>
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="#" DataField="MatchesPlayed" ItemStyle-ForeColor="#777777" />
		<asp:HyperLinkField ItemStyle-Wrap="False" DataNavigateUrlFormatString="~/PlayerMatchList.aspx?opponentid={0}" 
			DataNavigateUrlFields="ID"  HeaderText="Event" DataTextField="Name" ItemStyle-HorizontalAlign="left" />
		<%--<asp:BoundField ItemStyle-Wrap="False" HeaderText="Player" DataField="Name" ItemStyle-HorizontalAlign="left" />--%>
		<%--<asp:BoundField ItemStyle-Wrap="False" HeaderText="StartDate" DataField="Name" DataFormatString="{0:MM-dd-yyyy}" HtmlEncode="false" />--%>
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
		<asp:BoundField ItemStyle-Wrap="False" HeaderText="Pct" DataField="GamesPct" DataFormatString="{0:F3}" HtmlEncode="false" FooterText="Fuck" />
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
