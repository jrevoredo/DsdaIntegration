<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="IngestionError.aspx.cs" Inherits="Dsda.WebUploadStatistics.Reports.IngestionError" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="OptionsTable" style="background-color: #F1F1F1; width: 100%;">
        <tr>
            <td style="width: 1px; height: 0px;"></td>
            <td></td>
            <td></td>
            <td style="width: 1px;"></td>
        </tr>
        <tr>
            <td style="height: 15px;"></td>
            <td colspan="2" style="vertical-align: middle; ">
                <dx:ASPxLabel ID="lblTitle" runat="server" Text="Ingestion Error Report" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></dx:ASPxLabel>
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
                <dx:ASPxGridView ID="grdIngestionError" runat="server" AutoGenerateColumns="False" DataSourceID="linqIE" EnableTheming="True" Theme="Default" ClientInstanceName="grdIngestionError" KeyFieldName="tenantName;storeName;dealNumber;error_message" OnRowDeleting="grdIngestionError_RowDeleting">
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowDeleteButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Tenant Name" FieldName="tenantName" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Store Name" FieldName="storeName" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Deal Number" FieldName="dealNumber" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Error Message" FieldName="error_message" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="30">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" />
                    <SettingsCommandButton>
                        <DeleteButton Text="Delete Deal">
                        </DeleteButton>
                    </SettingsCommandButton>
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
            </td>
            <td></td>
        </tr>
    </table>
    <dx:LinqServerModeDataSource ID="linqIE" runat="server" ContextTypeName="Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext" TableName="VW_ASingestionErrors" EnableDelete="True" />
    <dx:ASPxGridViewExporter ID="grdExpIngestionError" runat="server" GridViewID="grdIngestionError">
    </dx:ASPxGridViewExporter>
</asp:Content>
