<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    Hi welcome to eCommerce License Page.<br />
    Please select your status for application .<br />
    Are you a new applicant? if so please press<br />
    New application<br />
    other wise please
    <br />
    press renew application.<br />
    <br />
    <br />
    <br />
    <asp:Button ID="btnNew" runat="server" Text="New Application" 
        onclick="btnNew_Click" />
    <br />
    <br />
    <asp:Button ID="btnRenew" runat="server" Text="Renew Application" 
        onclick="btnRenew_Click" />
    <br />
    <br />
    <br />
    <br />
    Thank you&nbsp; very much.<br />
</asp:Content>

