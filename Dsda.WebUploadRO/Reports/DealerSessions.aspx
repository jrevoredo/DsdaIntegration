<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="DealerSessions.aspx.cs" Inherits="Dsda.WebUploadRO.Reports.DealerSessions" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
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
                <dx:ASPxGridView ID="grdDealerSessions" runat="server" ClientInstanceName="grdDealerSessions" AutoGenerateColumns="False" KeyFieldName="UploadSessionId">
                    <ClientSideEvents RowDblClick="function(s, e) {
s.GetRowValues(e.visibleIndex, 'UploadSessionId', function (values) {
var l_UploadSessionId = values;
ViewDetails(values);
});
}" />
                    <SettingsPager PageSize="25">
                    </SettingsPager>
                    <Settings ShowHeaderFilterButton="True" ShowFilterRow="True" />
                    <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsPopup>
                        <HeaderFilter ShowHeader="True" Height="320px" Width="120px">
                        </HeaderFilter>
                    </SettingsPopup>
                    <SettingsSearchPanel Visible="True" ShowApplyButton="True" ShowClearButton="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0" ShowClearFilterButton="True" Width="20px">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="Session ID" FieldName="UploadSessionId" VisibleIndex="1" Width="20px">
                            <Settings AllowHeaderFilter="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="DateCreated" VisibleIndex="2" Caption="Date" Width="100px">
                            <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy hh:mm">
                            </PropertiesDateEdit>
                            <Settings AllowHeaderFilter="True" />
                            <SettingsHeaderFilter Mode="DateRangePicker">
                            </SettingsHeaderFilter>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalFilesCount" VisibleIndex="4" Caption="Total Files" Width="80px">
                            <Settings AllowHeaderFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="UploadedFilesCount" VisibleIndex="5" Caption="Uploaded Files" Width="80px">
                            <Settings AllowHeaderFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="MovedFilesCount" VisibleIndex="6" Caption="Moved Files" Width="80px">
                            <Settings AllowHeaderFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="FailedFilesCount" VisibleIndex="7" Caption="Failed Files" Width="80px">
                            <Settings AllowHeaderFilter="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="DealerId" VisibleIndex="3" Caption="Dealer ID" Width="120px">
                            <SettingsHeaderFilter Mode="CheckedList">
                            </SettingsHeaderFilter>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Notes" VisibleIndex="8" Width="200px">
                            <Settings AllowHeaderFilter="False" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="grdExpDealerSessions" runat="server" GridViewID="grdDealerSessions"></dx:ASPxGridViewExporter>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
