<%@ Control Language="c#" AutoEventWireup="True" Codebehind="SetScoreControl.ascx.cs" Inherits="Tennis.Controls.SetScoreControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div runat="server" id="setwrap" style="width:200px;" align="left">
	Set <asp:literal id="Set" runat="server"/>
	<asp:textbox id="W" runat="server" maxlength="2" width="20" onkeyup="GamesChanged(this);" onchange="GamesChanged(this);" set='<%#SetNumber%>'/> -
	<asp:textbox id="L" runat="server" maxlength="2" width="20" onkeyup="GamesChanged(this);" onchange="GamesChanged(this);" set='<%#SetNumber%>'/>
	<span id="tiebreak" style="display:none" runat="server">
		(<asp:textbox id="WT" runat="server" maxlength="2" width="20" /> -
		<asp:textbox id="LT" runat="server" maxlength="2" width="20" />)
	</span>
</div>
