<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Light.master" CodeBehind="Login.aspx.cs" Inherits="Dsda.WebRO.Login" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="OptionsTable" style="background-color: #FFFFFF; width: 100%;">
        <tr>
            <td style="width: 8px;"></td>
            <td>
                <div class="accountHeader">
                    <h2>Log In</h2>
                    <p></p>
                </div>
                <dx:ASPxLabel ID="lblUserName" runat="server" AssociatedControlID="tbUserName" Text="User Name:" />
                <div class="form-field">
	                <dx:ASPxTextBox ID="tbUserName" runat="server" Width="200px">
	                    <ValidationSettings ValidationGroup="LoginUserValidationGroup">
	                        <RequiredField ErrorText="User Name is required." IsRequired="true" />
	                    </ValidationSettings>
	                </dx:ASPxTextBox>
                </div>
                <dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="tbPassword" Text="Password:" />
                <div class="form-field">
	                <dx:ASPxTextBox ID="tbPassword" runat="server" Password="true" Width="200px">
	                    <ValidationSettings ValidationGroup="LoginUserValidationGroup">
	                        <RequiredField ErrorText="Password is required." IsRequired="true" />
	                    </ValidationSettings>
	                </dx:ASPxTextBox>
                </div>
                <dx:ASPxButton ID="btnLogin" runat="server" Text="Log In" ValidationGroup="LoginUserValidationGroup" OnClick="btnLogin_Click">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
</asp:Content>