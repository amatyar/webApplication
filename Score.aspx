<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Score.aspx.cs" Inherits="Score" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<asp:Label id="ScoreLabel" style="Z-INDEX: 101; LEFT: 17px; POSITION: absolute; TOP: 41px" runat="server" Width="369px" Height="40px">Your Score is</asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
		</form>
</body>
</html>
