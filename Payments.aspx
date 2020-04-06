<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="Payments" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Pay fees here:<br />
    <br />
    Four Digit Pin:
    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
    <br />
    
    
    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
    &nbsp;&nbsp;<asp:TextBox ID="txtFirstName" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="txtLastName" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;
    <br />
    <br />
    your billing address is different than mailing , 
    <br />
    Then check box<asp:CheckBox id="Check1" Text="Check " runat="server"/>
            
        &nbsp;<br />
        <br />  <br />
    <asp:Panel ID="Panel1" runat="server" >
   
    <asp:Label ID="lblStreet" runat="server" Text="Strees Address"></asp:Label>
    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
    <asp:TextBox ID="txtState" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblZipCode" runat="server" Text="ZipCode"></asp:Label>
    <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox> </asp:Panel>
    <br />
    <asp:Label ID="lblCardType" runat="server" Text="Credit Card Type"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem Value="Master Card"></asp:ListItem>
    <asp:ListItem Value="Visa Card"></asp:ListItem>
    <asp:ListItem Value="American Express"></asp:ListItem>
    <asp:ListItem Value="Discover Card"></asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblExpDate" runat="server" Text="Expariation Date"></asp:Label>
    <asp:TextBox ID="txtExpDate" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblCode" runat="server" Text="Safty Code"></asp:Label>
    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    
    <br />
    
    <br />
    
   <asp:Button ID="btnSubmit" runat="server" OnClick="Payment" Text="submit" PostBackUrl="~/SummaryPage.aspx" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" />
     <asp:Button ID="Button1" Text="Refresh Panel" runat="server"/>
    
</asp:Content>

