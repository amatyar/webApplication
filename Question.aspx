<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Question.aspx.cs" Inherits="Question" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
  		<form id="Form1" method="post" runat="server">
			
			<asp:table id="Table1" style="Z-INDEX: 101; LEFT: 66px; POSITION: absolute; TOP: 66px" runat="server" Width="550px" Height="310px" CellSpacing="1" CellPadding="1"></asp:table>
              &nbsp; &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CliffordConnectionString %>" SelectCommand="SELECT * FROM [Choices]"></asp:SqlDataSource>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Submit" Text="Submit" />
                </form>
</body>
</html>
