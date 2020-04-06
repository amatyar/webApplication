<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Application.aspx.cs" Inherits="Valid_Welcome" Title="Rigster Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   <table>
   <tr><td align="center" style="width: 671px"><h3>  welcome To eCommerce License</h3></td></tr>
        <tr>
            <td style="width: 671px">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/consultant.gif" 
                    Height="126px" Width="138px" />
            </td>
        </tr>
        <tr>
            <td style="width: 671px">
                <asp:Label ID="lblStreet" runat="server" Text="Street"></asp:Label>
                <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 671px">
            <asp:Label ID="lblZipCode" runat="server" Text="Zip Code"></asp:Label>
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="width: 671px">
                <asp:Label ID="lblBirthDate" runat="server" Text="Date of Birth"></asp:Label>
                <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
                <asp:Label ID="lblPin" runat="server" Text="Digit Pin #"></asp:Label>
                <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                <asp:Label ID="lblUserID" runat="server" Text="UserID"></asp:Label>
                <asp:TextBox ID="txtUserID" runat="server" Width="104px"></asp:TextBox><br />
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 669px">
                <asp:Label ID="lblEmployer" runat="server" Text="Name Of Employer"></asp:Label>
                <asp:TextBox ID="txtEmployer" runat="server" Width="376px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="width: 669px">
                <asp:Label ID="lblEStreet" runat="server" Text="Street"></asp:Label>
                <asp:TextBox ID="txtEstreet" runat="server"></asp:TextBox>
                <asp:Label ID="lblECity" runat="server" Text="City"></asp:Label>
                <asp:TextBox ID="txtECity" runat="server"></asp:TextBox>
                <asp:Label ID="lblEState" runat="server" Text="State"></asp:Label>
                <asp:TextBox ID="txtEState" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 669px">
                <asp:Label ID="lblEZipCode" runat="server" Text="Zip Code"></asp:Label>
                <asp:TextBox ID="txtEZipCode" runat="server"></asp:TextBox>
                <asp:Label ID="lblECountry" runat="server" Text="Country"></asp:Label>
                <asp:TextBox ID="txtECountry" runat="server"></asp:TextBox>
                <asp:Label ID="lblEPhone" runat="server" Text="Phone"></asp:Label>
                <asp:TextBox ID="txtEPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="center" style="width: 669px">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />&nbsp;
                <br />
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMessage2" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMessage3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

