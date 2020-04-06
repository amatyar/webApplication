<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Image.aspx.cs" Inherits="Image" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblAppName" runat="server" Text="Applicant Name"></asp:Label>
    &nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="txtAName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblImage" runat="server" Text="Applicant Image"></asp:Label>
    &nbsp; &nbsp;&nbsp;
    <asp:FileUpload ID="imgUpload" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnLoadImg" runat="server" OnClick="btnLoadImg_Click" Text="Display Photo" />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
    &nbsp;&nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit Picture" 
        onclick="btnSubmit_Click" />
    <br />
    <hr />
    <asp:Image ID="Image1" runat="server" Style="width: 200px" />


</asp:Content>

