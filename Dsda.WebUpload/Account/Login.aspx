<%@ Page Title="" Language="C#" MasterPageFile="~/Light.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dsda.WebUpload.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="accountHeader">
    <h2>Log In</h2>
    <p>
        Please enter your username and password.
    </p>
</div>
<dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px" Caption="User Name">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="User Name is required." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<dx:ASPxTextBox ID="tbPassword" runat="server" Password="true" Width="200px" Caption="Password">
    <CaptionSettings Position="Top" />
    <ValidationSettings ValidationGroup="LoginUserValidationGroup" ErrorTextPosition="Bottom" Display="Dynamic" ErrorDisplayMode="Text">
        <RequiredField ErrorText="Password is required." IsRequired="true" />
    </ValidationSettings>
</dx:ASPxTextBox>
<br />
<dx:ASPxButton ID="btnLogin" runat="server" Text="Log In" ValidationGroup="LoginUserValidationGroup"
    OnClick="btnLogin_Click">
</dx:ASPxButton>
</asp:Content>
