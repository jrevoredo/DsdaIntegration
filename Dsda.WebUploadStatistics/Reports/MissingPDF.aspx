<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="MissingPDF.aspx.cs" Inherits="Dsda.WebUploadStatistics.Reports.MissingPDF" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
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
            <td class="auto-style1"></td>
            <td colspan="2" style="vertical-align: middle; " class="auto-style1">
                <dx:ASPxLabel ID="lblTitle" runat="server" Text="Missing PDFs Report" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></dx:ASPxLabel>
            </td>
            <td class="auto-style1"></td>
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
                <dx:ASPxGridView ID="grdMissingPDF" runat="server" AutoGenerateColumns="False" DataSourceID="linqMP" EnableTheming="True" Theme="Default" ClientInstanceName="grdMissingPDF" KeyFieldName="tenantName;storeName;dealNumber">
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="tenantName" VisibleIndex="1" Caption="Tenant Name">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="storeName" VisibleIndex="2" Caption="Store Name">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="dealNumber" VisibleIndex="3" Caption="Deal Number">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="documentType" VisibleIndex="4" Caption="Document Type">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="stockNumber" VisibleIndex="5" Caption="Stock Number">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="lastName" VisibleIndex="6" Caption="Last Name">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="firstName" VisibleIndex="7" Caption="First Name">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="year" VisibleIndex="8" Caption="Year">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="make" VisibleIndex="9" Caption="Make">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="model" VisibleIndex="10" Caption="Model">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="slsDate" VisibleIndex="11" Caption="Sales Date">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="vin" VisibleIndex="12" Caption="VIN">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="creationDate" VisibleIndex="13" Caption="Creation Date">
                        </dx:GridViewDataDateColumn>
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
    <dx:LinqServerModeDataSource ID="linqMP" runat="server" ContextTypeName="Dsda.WebUploadStatistics._Class.LinqDataClassesDataContext" TableName="VW_ASassetMetadatas" />
    <dx:ASPxGridViewExporter ID="grdExpMissingPDF" runat="server" GridViewID="grdMissingPDF">
    </dx:ASPxGridViewExporter>
</asp:Content>
