<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Invalids.aspx.cs" Inherits="Invalids" Title="Invalids Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Your account is Invalid . Please register again
    <br />
    <asp:Button ID="btnRegister" runat="server" Text="Register An Account" OnClick="btnRegister_Click" />
</asp:Content>

