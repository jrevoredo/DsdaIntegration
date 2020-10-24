<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="DealerSessions.aspx.cs" Inherits="Dsda.WebRO.Reports.DealerSessions" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ViewDetails(p_UploadSessionId) {
            window.open('DealerSessionDetails.aspx?UploadSessionId=' + p_UploadSessionId, 'DSDetails', 'width=1100px,height=600px,left=0,top=30,screenX=0,screenY=30');
        }
    </script>
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
            <td colspan="2" style="vertical-align: middle; " class="auto-style1">
                <dx:ASPxLabel ID="lblTitle" runat="server" Text="Dealer Sessions" Font-Bold="True" Font-Size="Medium" ForeColor="#FF6600"></dx:ASPxLabel>
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
                <dx:ASPxGridView ID="grdDealerSessions" runat="server" AutoGenerateColumns="False" KeyFieldName="UploadSessionId" ClientInstanceName="grdDealerSessions">
                    <ClientSideEvents RowDblClick="function(s, e) {
    s.GetRowValues(e.visibleIndex, 'UploadSessionId', function (values) {
        var l_UploadSessionId = values;
        ViewDetails(values);
    });
}" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="UploadSessionId" Visible="False" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn Caption="Date" FieldName="DateCreated" SortIndex="0" SortOrder="Descending" VisibleIndex="3" Width="100px">
                            <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy hh:mm">
                            </PropertiesDateEdit>
                            <Settings AllowAutoFilter="True" />
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="DealerId" VisibleIndex="2" Width="120px">
                            <Settings AllowAutoFilter="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Total" FieldName="TotalFilesCount" VisibleIndex="4" Width="90px">
                            <Settings AllowAutoFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Uploaded" FieldName="UploadedFilesCount" VisibleIndex="5" Width="90px">
                            <Settings AllowAutoFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Moved" FieldName="MovedFilesCount" VisibleIndex="6" Width="90px">
                            <Settings AllowAutoFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Failed" FieldName="FailedFilesCount" VisibleIndex="7" Width="90px">
                            <Settings AllowAutoFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Notes" FieldName="Notes" VisibleIndex="8" Width="200px">
                            <Settings AllowAutoFilter="False" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowSelectSingleRowOnly="True" AllowSelectByRowClick="True" />
                    <SettingsPager PageSize="25">
                    </SettingsPager>
                    <Settings ShowFilterRow="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                </dx:ASPxGridView>
            </td>
            <td></td>
        </tr>
    </table>
    <dx:ASPxGridViewExporter ID="grdExpDealerSessions" runat="server" GridViewID="grdDealerSessions"></dx:ASPxGridViewExporter>
</asp:Content>
