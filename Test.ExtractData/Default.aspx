<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Test.ExtractData.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <table>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style1">
                <strong>Choose action to get results:</strong></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>&nbsp;</td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="butGetOneCustomer" runat="server" OnClick="butGetOneCustomer_Click" Text="Get One Customer" Width="134px" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="butGetManyCustomers" runat="server" OnClick="butGetManyCustomers_Click" Text="Get Many Customers" Width="134px" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="butGetOneRO" runat="server" OnClick="butGetOneRO_Click" Text="Get One RO" Width="134px" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="butGetManyROs" runat="server" OnClick="butGetManyROs_Click" Text="Get Many ROs" Width="134px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <br />
                <br />
                <asp:Label ID="lblTitleResults" runat="server" style="font-weight: 700; color: #0033CC"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblResults" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    </form>
</body>
</html>
