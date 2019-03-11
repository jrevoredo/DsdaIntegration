<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="DealerSessionDetails.aspx.cs" Inherits="Dsda.WebRO.Reports.DealerSessionDetails" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="EmptyHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EmptyBodyContent" runat="server">
    <table class="OptionsTable" style="background-color: #F1F1F1; width: 100%;">
        <tr>
            <td style="width: 1px; height: 0px;"></td>
            <td></td>
            <td></td>
            <td style="width: 1px;"></td>
        </tr>
        <tr>
            <td style="height: 15px;"></td>
            <td colspan="2" style="vertical-align: middle; " class="auto-style1">
                <dx:ASPxLabel ID="lblTitle" runat="server" Text="Dealer Session Details" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></dx:ASPxLabel>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="height: 15px"></td>
            <td>
                <dx:ASPxButton ID="btnExportXLS" runat="server" OnClick="btnExportXLS_Click" Text="Export To XLS">
                </dx:ASPxButton>
            </td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2" style="vertical-align: top; height: 800px;">
                <dx:ASPxGridView ID="grdDealerSessionDetails" runat="server" AutoGenerateColumns="False" OnCustomUnboundColumnData="grdDealerSessionDetails_CustomUnboundColumnData">
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="UploadSessionDetailId" VisibleIndex="3" SortIndex="2" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UploadSessionId" VisibleIndex="4" SortIndex="1" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Message" VisibleIndex="2" Width="1000px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MessageType" VisibleIndex="1" SortIndex="0" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Type" FieldName="DescrMessageType" UnboundType="String" VisibleIndex="0" Width="70px">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="25">
                    </SettingsPager>
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
            </td>
            <td></td>
        </tr>
    </table>
    <dx:ASPxGridViewExporter ID="grdExpDealerSessionDetails" runat="server" GridViewID="grdDealerSessionDetails"></dx:ASPxGridViewExporter>
</asp:Content>
