<%@ page language="c#" inherits="Tennis.MatchEdit, App_Web_r3lxnij1" masterpagefile="tennis.master" %>
<%@ Register TagPrefix="uc1" TagName="SetScoreControl" Src="SetScoreControl.ascx" %>

<asp:content ID="Content1" contentplaceholderid="title" runat="server">
	Tennis Master Edit Match
</asp:content>

<asp:content ID="Content2" contentplaceholderid="maincontent" runat="server">
	<table id="DialogBox" border="0" cellspacing="5" cellpadding="0" class="Dialog">
		<caption id="DialogCaption">
			<%#Caption%>
		</caption>
		<tr>
			<td>
				Event<br/>
				<asp:dropdownlist id="Event" runat="server" datavaluefield="ID" datatextfield="Name" /><br/>
				<asp:requiredfieldvalidator id="vldEvent" runat="server" controltovalidate="Event"
					errormessage="Please select an event" enableclientscript="true" display="Dynamic"/>
			</td>
			<td>
				Date<br/>
				<asp:textbox id="Date" runat="server" maxlength="20" width="200" text='<%#match.MatchDate%>'/><br/>
				<asp:requiredfieldvalidator id="DateRequired" runat="server" controltovalidate="Date" 
					errormessage="Please enter a date" enableclientscript="true" display="Dynamic"/>
				<asp:comparevalidator id="DateValid" runat="server" controltovalidate="Date"
					errormessage="Please enter a valid date" enableclientscript="true" display="Dynamic" 
					type="Date" operator="GreaterThan" valuetocompare="2003/01/01"/>
			</td>
		</tr>
		<tr>
			<td>
				Winner<br/>
				<asp:dropdownlist id="Winner" runat="server" datavaluefield="ID" datatextfield="FullName" /><br/>
				<asp:requiredfieldvalidator id="WinnerRequired" runat="server" controltovalidate="Winner" 
					errormessage="Please select a winner" enableclientscript="true" display="Dynamic"/>
			</td>
			<td>
				Loser<br/>
				<asp:dropdownlist id="Loser" runat="server" datavaluefield="ID" datatextfield="FullName" /><br/>
				<asp:requiredfieldvalidator id="LoserRequired" runat="server" controltovalidate="Loser" 
					errormessage="Please select a loser" enableclientscript="true" display="Dynamic"/>
			</td>
		</tr>
		<tr height="20">
			<td></td>
		</tr>
		<tr>
			<td colspan="2" align="center">
				<uc1:setscorecontrol id="Set1" runat="server" WinnerGames='<%#match.Score.MatchSets[0].WGames%>' LoserGames='<%#match.Score.MatchSets[0].LGames%>'/><br/>
				<uc1:setscorecontrol id="Set2" runat="server" WinnerGames='<%#match.Score.MatchSets[1].WGames%>' LoserGames='<%#match.Score.MatchSets[1].LGames%>'/><br/>
				<uc1:setscorecontrol id="Set3" runat="server" WinnerGames='<%#match.Score.MatchSets[2].WGames%>' LoserGames='<%#match.Score.MatchSets[2].LGames%>'/><br/>
				<uc1:setscorecontrol id="Set4" runat="server" WinnerGames='<%#match.Score.MatchSets[3].WGames%>' LoserGames='<%#match.Score.MatchSets[3].LGames%>'/><br/>
				<uc1:setscorecontrol id="Set5" runat="server" WinnerGames='<%#match.Score.MatchSets[4].WGames%>' LoserGames='<%#match.Score.MatchSets[4].LGames%>'/><br/>
				<asp:customvalidator id="ScoreValidator" runat="server" controltovalidate="" 
					errormessage="Please enter a valid score" enableclientscript="true" display="Dynamic" 
					onservervalidate="ScoreValidator_ServerValidate"/>
				<br/>
				<asp:checkbox id="Defaulted" runat="server" />
				Loser Defaulted<br/>
			</td>
		</tr>
		<tr height="10">
		</tr>
		<tr align="right">
			<td colspan="2">
				<asp:button id="Submit" runat="server" text="     OK     " onclick="Submit_Click"/>
				<asp:button id="Cancel" runat="server" text="   Cancel   " onclick="Cancel_Click" causesvalidation="False"/>
			</td>
		</tr>
	</table>
	<% /*
	<asp:validationsummary id="vldSummary" runat="server" headertext="Validation Failed" displaymode="BulletList"></asp:validationsummary><br/>
	<br/>
	<asp:literal id="Status" runat="server" text="starting..."/>
	 * 
	 * 
	<asp:rangevalidator id="RangeValidator1" runat="server" errormessage="RangeValidator"></asp:rangevalidator>
	<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="RegularExpressionValidator"></asp:regularexpressionvalidator>
	<asp:customvalidator id="CustomValidator1" runat="server" errormessage="CustomValidator"></asp:customvalidator>
	*/ %>

</asp:content>

