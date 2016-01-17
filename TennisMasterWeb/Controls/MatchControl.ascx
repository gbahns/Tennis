<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MatchControl.ascx.cs" Inherits="Tennis.Controls.MatchControl" %>
<%@ Register Assembly="KeySortDropDownList" Namespace="KeySortDropDownList.Thycotic.Web.UI.WebControls" TagPrefix="cc1" %>

<%@ Register TagPrefix="uc1" TagName="SetScoreControl" Src="~/Controls/SetScoreControl.ascx" %>
<%@ Register tagprefix="bahns" assembly="Bahns.Web.UI.WebControls" namespace="Bahns.Web.UI.WebControls" %>
<%@ Register TagPrefix="brett" Assembly="BrettResources.ServerControls" Namespace="BrettResources.ServerControls" %>
<%@ Register TagPrefix="uc1" Namespace="Sfg.Web.UI.Controls" Assembly="AutoCompleteTextBox" %>

<%@ Register TagPrefix="cc1" Namespace="ProgStudios.WebControls" Assembly="ProgStudios.WebControls" %>

<table id="DialogBox" border="0" cellspacing="5" cellpadding="0" class="Dialog">
	<caption id="DialogCaption" runat="server">
		<%#Caption%>
	</caption>
	<tr>
		<td>
			Event<br>
			<asp:DropDownList ID="Event" runat="server" DataValueField="ID" DataTextField="Name" /><br>
			<asp:RequiredFieldValidator ID="vldEvent" runat="server" ControlToValidate="Event"
				ErrorMessage="Please select an event" EnableClientScript="true" Display="Dynamic" />
		</td>
		<td>
			Date<br>
			
			<bahns:DatePicker runat="server" ID="Date" Width="200" />
			<asp:TextBox runat="server" ID="Time" Width="40" />
<%--						<asp:RequiredFieldValidator ID="DateRequired" runat="server" ControlToValidate="Date"
				ErrorMessage="Please enter a date" EnableClientScript="true" Display="Dynamic" />
			<asp:CompareValidator ID="DateValid" runat="server" ControlToValidate="Date" ErrorMessage="Please enter a valid date"
				EnableClientScript="true" Display="Dynamic" Type="Date" Operator="GreaterThan"
				ValueToCompare="2003/01/01" />
--%>					</td>
	</tr>
	<tr>
		<td>
			Winner<br>
			<%--<brett:AutoCompleteDropDownList runat="server" ID="Winner2" DataValueField="ID" DataTextField="FullName" /><br />
    <cc1:combobox id="Winner2" runat="server">
    </cc1:combobox>			
    <br />
			--%>
			<uc1:AutoCompleteTextBox runat="server" id="Winner1" Width="400px" /><br />
			<asp:DropDownList ID="Winner" runat="server" DataValueField="ID" DataTextField="FullName" /><br>
			<asp:RequiredFieldValidator ID="WinnerRequired" runat="server" ControlToValidate="Winner"
				ErrorMessage="Please select a winner" EnableClientScript="true" Display="Dynamic" />
		</td>
		<td>
			Loser<br>
			<%--<cc1:KeySortDropDownList ID="Loser2" runat="server" DataValueField="ID" DataTextField="FullName" /><br />--%>
			<asp:DropDownList ID="Loser" runat="server" DataValueField="ID" DataTextField="FullName" /><br>
			<asp:RequiredFieldValidator ID="LoserRequired" runat="server" ControlToValidate="Loser"
				ErrorMessage="Please select a loser" EnableClientScript="true" Display="Dynamic" />
		</td>
	</tr>
	<tr height="5">
		<td>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center">
			<uc1:SetScoreControl ID="Set1" runat="server" />
			<uc1:SetScoreControl ID="Set2" runat="server" />
			<uc1:SetScoreControl ID="Set3" runat="server" />
			<uc1:SetScoreControl ID="Set4" runat="server" />
			<uc1:SetScoreControl ID="Set5" runat="server" />
			<asp:CustomValidator ID="ScoreValidator" runat="server" ControlToValidate="" ErrorMessage="Please enter a valid score"
				EnableClientScript="true" Display="Dynamic" OnServerValidate="ScoreValidator_ServerValidate" />
			<br>
			<asp:CheckBox ID="Defaulted" runat="server" />
			Loser Defaulted<br>
		</td>
	</tr>
</table>
<asp:ValidationSummary ID="vldSummary" runat="server" HeaderText="Validation Failed" 
	DisplayMode="BulletList"></asp:ValidationSummary>
<%--<br>
<br>--%>
	<% /*
	<asp:rangevalidator id="RangeValidator1" runat="server" errormessage="RangeValidator"></asp:rangevalidator>
	<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="RegularExpressionValidator"></asp:regularexpressionvalidator>
	<asp:customvalidator id="CustomValidator1" runat="server" errormessage="CustomValidator"></asp:customvalidator>
	*/ %>


<script>
var rootid = null;
GamesChanged(document.all['<%#Set1.ClientID%>_W']);

function SetPlayed(set)
{
	var myrootid = rootid + '_Set' + set + '_';
	
	var W = document.all[myrootid+'W'];
	var	L = document.all[myrootid+'L'];

	var w = parseInt(W.value);
	var l = parseInt(L.value);

	return w>0 || l>0;
}

function LastSetPlayed()
{
	var set = 0;
	for (var i=1; i<=5; i++)
	{
		if (SetPlayed(i))
			set = i;
	}
	return set;
}


//var autoSuggest = new AutoComplete('ctl00_ContentPlaceHolder1_ctl00_Winner1', 
//new Array('','? Eastern Hills','? Queen City','? Bald ? (Eastern Hills)','Aaron Hutcherson','Adam ? Colonial','Adam Abele','Adam Williams (Michigan)','Alex Norway','Andrew Laskey (Western)',
//'Anil Nalagathlan','Art Gendelman (Harpers)','Arturo Nava (Harpers)','Bill Eno','Bill Grannen','Bob Bergstein (QC)','Bob Scheule (Five Seasons)','Bob Simmons (Harper\'s)','Bob ? Four Seasons','Brian Davis','Brian Hogan',
////'Brian Wessinger','Brian/Mirko Wessinger/Ravlic','Bruce Connors','Bud Shroeder','Byron Stallworth','Chad White','Charlie Eberhard (Harpers)','Charlie Pruett','Chris Brock','Chris Downie (QC)','Chris Mark (Western)',
////'Chris Rumke (Colonial)','Chris Thach','Chuck Hwang','Chuck Patty','D. Ucci (Eastern Hills)','Dan Altenau','Dan Queen City','Dan Wagner','Dan Willig (Eastern 4.0)','Dave Geis','Dave Peterson','Dave Rumke (Colonial)',
////'Dave Tanner','Dave 22 (Harpers Point)','David McKeithan','Dee Shah','Dennis Menke (Eastern)','Dolf Muccillo','Donovan Ping (Colonial)','Drew Barzman (Camargo/QC)','Ed Knapp (Colonial)','Eric Inglert',
////'Frantz Beznik (Harper''s)','Fred Eck','Ganesh Subramanian','Gerardo Scheufler','Greg Bahns','Gregg Wilhelm','Hart Moore (Eastern)','Ian McLean (Beechmont)','Ivan ? (Harper''s)','James Wes Costin','Jason Stuckey',
////'Jay Avenido','Jay White (Camargo)','Jeff Ewert (Eastern)','Jeff Gerth (QC)','Jeff Henderson (Harpers Point)','Jeff James','Jerome Monter','Jim Schutty','Jim ? Camargo','Joe Bannon (CY)','John Berkovich','John Hanify',
////'John LeCroy','John Moffit (Eastern)','John Wright (Beechmont)','Jon Burchfield','Justin Cohen','Keith ? (Harpers)','Keith Goerlich (CY)','Keith Metully (QC)','Kelly Euler (Western)','Ken Bartley','Ken Burns',
////'Ken Dews (Eastern Hills)','Ken Weisbacher','Kevin ? (?)','Kevin Powers (Eastern)','Kolanji Martin','Lance Koester','Lance MacLean','Lee Thach','Len Murray (Eastern Hills)','Lenny ? Queen City','Lou Vonderbrink (Western)',
////'Mark (Destin)','Mark Becker','Mark Kuhlman (Eastern)','Mark Schierenbeck (QC)','Matt Berman','Matt Orlett','Matt Thinnes','Matthew Hughes','Matthew Stubbs','Michael Elleman','Michael Lovelace (QC)','Michael Meier',
////'Michael Schmidt (QC)','Michael K. Rose','Mike Hooven (QC)','Mike Kindred (QC)','Mike Pottner','Mike Reed','Mirko Ravlic','Nick Frances','Pat Hess','Paul Caprio','Paul Spence','Pete Burgess','Phil Huff (QC)',
////'Phil Westerbeck (Harpers)','Phouc Tran','Rey Puentes','Rich (Beechmont)','Rick (Camargo)','Rick Vories (Eastern)','Rick Wooliver (Eastern)','Rob Saunders (QC)','Robert Horne','Rod (Queen City)','Rodger Mauch',
////'Ron ? (Colonial)','Ryan Hamning','Ryuji Kaneko','Sam Laber (Eastern)','Samir Kulkarni (QC)','Scott (Queen City)','Scott Hein (Colonial)','Scott Moran (Harper''s)','Scott Snider','Shawn Worth','Steve Crusham (Western)',
////'Steve Edwards','Steve Engelbredt (Eastern)','Steve Gilbert','Steve Moore (QC)','Steve Palmer','Steve Riddle','Thaddaeus Reichert','Tim Davis','Toby Bryan (Colonial)','Toby Matthias (QC)','Todd ? (Riverside)','Todd Karle',
//'Tom ? (Five Seasons)','Tom Daria (Five Seasons)','Tom Stokes (Harpers)','Tony Cortese (Harpers)','Vic (Queen City)','Will Shuman','Yokuma Mitsuhashi'));


function GamesChanged(sender)
{
	//ctl00_ContentPlaceHolder1_ctl00_Set1_setwrap
	//ctl00_ContentPlaceHolder1_ctl00_Set1_W

	if (sender)
	{
		var set = sender.set;
		
		if (!rootid)
		{
			var id = sender.id;
			rootid = id.substr(0,id.indexOf('_Set'+set+'_'));
		}
		
//		var myrootid = rootid + '_Set' + set + '_';
//		
//		var W = document.all[myrootid+'W'];
//		var	L = document.all[myrootid+'L'];
//		var WT = document.all[myrootid+'WT'];
//		var	LT = document.all[myrootid+'LT'];
//		var tiebreak = document.all[myrootid+'tiebreak'];
//		
//		var w = parseInt(W.value);
//		var l = parseInt(L.value);
//		var wt = parseInt(WT.value);
//		var lt = parseInt(LT.value);
//			
//		tiebreak.style.display = Math.abs(w-l) == 1 ? "" : "none";
	}
	
	var lastSetPlayed = LastSetPlayed();
	for (var i=1; i<=5; i++)
	{
		var display = i<lastSetPlayed+2;
		if (display)
		{
			document.all[rootid+'_Set'+i+'_tiebreak'].style.display = display ? "" : "none";
			var w = parseInt(document.all[rootid+'_Set'+i+'_W'].value);
			var l = parseInt(document.all[rootid+'_Set'+i+'_L'].value);
			document.all[rootid+'_Set'+i+'_tiebreak'].style.display = Math.abs(w-l) == 1 ? "" : "none";
		}
		document.all[rootid+'_Set'+i+'_setwrap'].style.display = display ? "" : "none";
	}
}
</script>
