<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="MissingMetadata.aspx.cs" Inherits="Dsda.WebUploadStatistics.Reports.MissingMetadata" %>

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
                <dx:ASPxLabel ID="lblTitle" runat="server" Text="Missing Metadata Report" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></dx:ASPxLabel>
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
                <dx:ASPxGridView ID="grdMissingMetadata" runat="server" AutoGenerateColumns="False" DataSourceID="linqMMD" EnableTheming="True" Theme="Default" ClientInstanceName="grdMissingMetadata" KeyFieldName="tenantName;storeName;documentType;dealNumber">
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Tenant Name" FieldName="tenantName" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Store Name" FieldName="storeName" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Document Type" FieldName="documentType" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Deal Number" FieldName="dealNumber" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPager PageSize="30">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
            </td>
            <td></td>
        </tr>
    </table>
    <dx:LinqServerModeDataSource ID="linqMMD" runat="server" ContextTypeName="Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext" TableName="VW_ASmissingMetadatas" />
    <dx:ASPxGridViewExporter ID="grdExpMissingMetadata" runat="server" GridViewID="grdMissingMetadata">
    </dx:ASPxGridViewExporter>
</asp:Content>
