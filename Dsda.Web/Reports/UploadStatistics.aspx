<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadStatistics.aspx.cs" Inherits="Dsda.Web.Reports.UploadStatistics" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/redmond/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-ui-1.10.3.custom.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery.jqGrid.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/i18n/grid.locale-en.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        var dateFrom = null;
        var dateTo = null;
        var dealer = "";

        jQuery().ready(function () {
            $("#dateFrom").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#dateTo").datepicker({ dateFormat: 'yy-mm-dd' });

            var gridUrl = '../Handlers/GridData.ashx?grid=Dealers';

            dateFrom = $("#dateFrom").datepicker("getDate");
            dateTo = $("#dateTo").datepicker("getDate");

            if (dateFrom != null || dateTo != null) {
                gridUrl += "&from=" + FormatUrlDate(dateFrom) + "&to=" + FormatUrlDate(dateTo);
            }

            dealer = $("#hidDealerId").val();

            if (dealer != "") {
                gridUrl += "&dealer=" + dealer;
            }

            //load Dealers grid
            jQuery("#mainGrid").jqGrid({
                url: gridUrl,
                datatype: "json",
                colNames: ['id', 'Total Processed', 'Failed'],
                colModel: [{ name: 'DealerId', index: 'DealerId', width: 30, hidden: false },
                    { name: 'TotalFilesCount', index: 'TotalFilesCount', width: 50 },
                    { name: 'FailedFilesCount', index: 'FailedFilesCount', width: 40 }],
                rowNum: 50,
                cmTemplate: { sortable: false },
                autowidth: true,
                rowList: [50, 100, 150],
                pager: jQuery('#mainGridPager'),
                viewrecords: true,
                caption: "",
                onSelectRow: function (id) {
                    LoadDetails(id);
                }
            }).navGrid('#mainGridPager', { edit: false, add: false, del: false, search: false });

            //autoresize grid Height
            $('#mainGrid').jqGrid('setGridHeight', $(window).innerHeight() - 200);

            $(window).resize(function () {
                $('#mainGrid').jqGrid('setGridHeight', $(window).innerHeight() - 200);
            });

            $("#btnSearch").button()
            .click(function (event) {
                event.preventDefault();
                var dFrom = $("#dateFrom").datepicker("getDate");
                var dTo = $("#dateTo").datepicker("getDate");

                if (dFrom == null ^ dTo == null) {
                    alert("Please, select date range.");
                    return;
                }

                if (dTo != null && dFrom != null && dTo < dFrom) {
                    alert("Invalid date range.");
                    return;
                }

                Search();
            });

            $("#btnClear").button()
            .click(function (event) {
                event.preventDefault();
                $("#dateFrom").datepicker("setDate", null);
                $("#dateTo").datepicker("setDate", null);
                $("#selectDealerIds").val("");
                Search();
            });

            $.getJSON("../Handlers/GridData.ashx?grid=DealerIds", function (result) {
                var options = $("#selectDealerIds");
                options.append($("<option />").val("").text("All"));
                $.each(result.rows, function (index, item) {
                    options.append($("<option />").val(item.id).text(item.id));
                });
                $("#selectDealerIds").val($("#hidDealerId").val());
            });
        });

        function Search() {
            var sUrl = '../Handlers/GridData.ashx?grid=Dealers';
            dateFrom = $("#dateFrom").datepicker("getDate");
            dateTo = $("#dateTo").datepicker("getDate");
            dealer = $("#selectDealerIds").val();
            $("#hidDealerId").val(dealer);

            if (dateFrom != null || dateTo != null) {
                sUrl += "&from=" + FormatUrlDate(dateFrom) + "&to=" + FormatUrlDate(dateTo);
            }

            if (dealer != "") {
                sUrl += "&dealer=" + dealer;
            }

            jQuery("#mainGrid").jqGrid('setGridParam', { url: sUrl, page: 1 }).trigger("reloadGrid");
        }

        function FormatUrlDate(d) {
            var curr_date = d.getDate();

            if (curr_date.toString().length == 1)
                curr_date = "0" + curr_date;

            var curr_month = d.getMonth() + 1;

            if (curr_month.toString().length == 1)
                curr_month = "0" + curr_month;

            var curr_year = d.getFullYear();
            return curr_year + "-" + curr_month + "-" + curr_date;
        }

        function LoadDetails(dealerId) {
            var sUrl = 'DealerSessions.aspx?dealer=' + dealerId;

            dateTo = $("#dateTo").datepicker("getDate");
            dealer = $("#selectDealerIds").val();

            if (dateFrom != null || dateTo != null) {
                sUrl += "&from=" + FormatUrlDate(dateFrom) + "&to=" + FormatUrlDate(dateTo);
            }

            location.href = sUrl;
        }
    </script>
    <table>
        <tr>
            <td>From:</td>
            <td><input type="text" id="dateFrom" /></td>
            <td>&nbsp;</td>
            <td>To:</td><td><input type="text" id="dateTo" /></td>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td>Dealer:</td>
            <td>
                <select id="selectDealerIds"></select>
                <input type="hidden" id="hidDealerId" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><input type="button" value="Apply" id="btnSearch" /></td>
            <td><input type="button" value="Clear" id="btnClear" /></td>
        </tr>
    </table>
    <table id="mainGrid"></table> 
    <div id="mainGridPager"></div>
</asp:Content>
