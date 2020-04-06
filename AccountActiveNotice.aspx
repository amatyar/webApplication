<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountActiveNotice.aspx.cs" Inherits="AccountActiveNotice" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 70px">Your account active.
    Please click below button and login !</p><br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
    
</asp:Content>

