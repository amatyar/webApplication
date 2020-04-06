<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Certificate.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table>
            <tr>
                <td style="width: 142px">
                    <asp:Label ID="Label1" runat="server" Text="Training Name"></asp:Label></td>
                <td style="width: 141px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 142px">
                    <asp:Label ID="Label2" runat="server" Text="Certificate Number"></asp:Label></td>
                <td style="width: 141px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 142px">
                    <asp:Label ID="Label3" runat="server" Text="Insurance Company"></asp:Label></td>
                <td style="width: 141px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 142px">
                    <asp:Label ID="Label4" runat="server" Text="Policy Number"></asp:Label></td>
                <td style="width: 141px">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 142px">
                    <asp:Label ID="Label5" runat="server" Text="Education Level"></asp:Label></td>
                <td style="width: 141px">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /><br />
    
    </div>
    </form>
</body>
</html>
