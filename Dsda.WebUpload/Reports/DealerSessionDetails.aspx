<%@ Page Title="" Language="C#" MasterPageFile="~/Empty.master" AutoEventWireup="true" CodeBehind="DealerSessionDetails.aspx.cs" Inherits="Dsda.WebUpload.Reports.DealerSessionDetails" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
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
                <dx:ASPxGridView ID="grdDealerSessionDetails" runat="server" ClientInstanceName="grdDealerSessionDetails" AutoGenerateColumns="False" OnCustomUnboundColumnData="grdDealerSessionDetails_CustomUnboundColumnData">
                    <SettingsPager PageSize="25">
                    </SettingsPager>
                    <Settings ShowHeaderFilterButton="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="UploadSessionDetailId" ShowInCustomizationForm="True" VisibleIndex="0" Caption="Session Detail ID" SortIndex="2" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UploadSessionId" ShowInCustomizationForm="True" VisibleIndex="1" Caption="Session ID" SortIndex="1" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Message" ShowInCustomizationForm="True" VisibleIndex="4" Caption="Message" Width="1000px">
                            <Settings AllowHeaderFilter="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MessageType" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Message Type" SortIndex="0" SortOrder="Descending" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MessageTypeDescr" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Type" Width="70px" UnboundType="String">
                            <Settings AllowHeaderFilter="True" />
                            <SettingsHeaderFilter Mode="CheckedList">
                            </SettingsHeaderFilter>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="grdExpDealerSessionDetails" runat="server" GridViewID="grdDealerSessionDetails"></dx:ASPxGridViewExporter>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
