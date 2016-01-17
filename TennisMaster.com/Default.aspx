<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<% log.Info("Page start"); %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		This is the default page.<br />
		If you see this text then I guess the development web server is working.<br />
		<br />
		Here we could provide some links to test the other pages.<br />
		<br />
		<a href="PlayerList.aspx">Player List</a><br />
		<a href="PlayerMatchList.aspx">Player Match List</a><br />
    </div>
    </form>
</body>
</html>
<% log.Info("Page end"); %>
