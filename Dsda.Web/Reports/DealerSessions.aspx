<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DealerSessions.aspx.cs" Inherits="Dsda.Web.Reports.DealerSessions" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/redmond/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveClientUrl("~/Scripts/jquery-ui-1.10.3.custom.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/jquery.jqGrid.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveClientUrl("~/Scripts/i18n/grid.locale-en.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var dateFrom = null;
        var dateTo = null;
        var dealer = "<% =Request.QueryString["dealer"] %>";

        jQuery().ready(function () {
            $("#dateFrom").val("<% =Request.QueryString["from"] %>");
            $("#dateTo").val("<% =Request.QueryString["to"] %>");

            $("#dateFrom").datepicker({ dateFormat: 'yy-mm-dd' });
            $("#dateTo").datepicker({ dateFormat: 'yy-mm-dd' });

            var gridUrl = '../Handlers/GridData.ashx?grid=UploadSessions&dealer=' + dealer;

            dateFrom = $("#dateFrom").datepicker("getDate");
            dateTo = $("#dateTo").datepicker("getDate");

            if (dateFrom != null || dateTo != null) {
                gridUrl += "&from=" + FormatUrlDate(dateFrom) + "&to=" + FormatUrlDate(dateTo);
            }

            //load Upload Sessions grid
            jQuery("#mainGrid").jqGrid({
                url: gridUrl,
                datatype: "json",
                colNames: ['id', 'Date', 'Total Processed', 'Uploaded', 'Moved', 'Failed', 'Notes', 'Upload Log', '', '', '', ''],
                colModel: [{ name: 'UploadSessionId', index: 'UploadSessionId', width: 30, hidden: true },
                    {
                        name: 'DateCreated',
                        index: 'DateCreated',
                        width: 90,
                        formatter: function (value, options, rData) {
                            if (value.indexOf("Total") != -1)
                                return value;
                            return FormatJsonDate(value);
                        }
                    },
                    { name: 'TotalFilesCount', index: 'TotalFilesCount', width: 50 },
                    { name: 'UploadedFilesCount', index: 'UploadedFilesCount', width: 40 },
                    { name: 'MovedFilesCount', index: 'MovedFilesCount', width: 40 },
                    { name: 'FailedFilesCount', index: 'FailedFilesCount', width: 40 },
                    { name: 'Notes', index: 'Notes', width: 40, editable: true },
                    {
                        name: 'Log',
                        index: 'Log',
                        width: 30,
                        formatter: function (value, options, rData) {
                            return "<a target=_blank href=DocumentProcessingLog.aspx?SessionId=" + options.rowId + ">Log</a>";
                        }
                    },
                    { name: 'TotalTotalFilesCount', index: 'TotalTotalFilesCount', hidden: true },
                    { name: 'TotalUploadedFilesCount', hidden: true },
                    { name: 'TotalMovedFilesCount', hidden: true },
                    { name: 'TotalFailedFilesCount', hidden: true }],
                rowNum: 50,
                cmTemplate: { sortable: false },
                autowidth: true,
                rowList: [50, 100, 150],
                pager: jQuery('#mainGridPager'),
                viewrecords: true,
                caption: "",
                footerrow: true,
                cellEdit: true,
                cellsubmit: "remote",
                cellurl: "../Handlers/GridData.ashx",
                ondblClickRow/*onSelectRow*/: function (id) {
                    LoadDetails(id);
                    var rowData = $('#mainGrid').jqGrid('getRowData', id);
                    var date = rowData.DateCreated;
                    var title = "Upload Session Details: " + date;
                    $("#dialogDetails").dialog({
                        width: "900", height: "600", title: title, buttons: {
                            Close: function () {
                                $(this).dialog("close");
                            }
                        }
                    });
                },
                loadComplete: function (data) {
                    jQuery("#mainGrid").jqGrid('footerData', 'set',
                        {
                            DateCreated: 'Total:',
                            TotalFilesCount: jQuery("#mainGrid").jqGrid('getCol', 'TotalTotalFilesCount', false, 'sum'),
                            UploadedFilesCount: jQuery("#mainGrid").jqGrid('getCol', 'TotalUploadedFilesCount', false, 'sum'),
                            MovedFilesCount: jQuery("#mainGrid").jqGrid('getCol', 'TotalMovedFilesCount', false, 'sum'),
                            FailedFilesCount: jQuery("#mainGrid").jqGrid('getCol', 'TotalFailedFilesCount', false, 'sum')
                        });
                    $('#mainGrid').jqGrid('delRowData', 'TotalRow');
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

                if (dFrom == null || dTo == null) {
                    alert("Please, select date range.");
                    return;
                }

                if (dTo < dFrom) {
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
                Search();
            });

            $("#btnBack").button()
            .click(function (event) {
                event.preventDefault();
                window.history.back();
            });
        });

        function Search() {
            var sUrl = '../Handlers/GridData.ashx?grid=UploadSessions&dealer=' + dealer;
            dateFrom = $("#dateFrom").datepicker("getDate");
            dateTo = $("#dateTo").datepicker("getDate");

            if (dateFrom != null || dateTo != null) {
                sUrl += "&from=" + FormatUrlDate(dateFrom) + "&to=" + FormatUrlDate(dateTo);
            }

            jQuery("#mainGrid").jqGrid('setGridParam', { url: sUrl, page: 1 }).trigger("reloadGrid");
        }

        function FormatJsonDate(jsonDate) {
            //var d = eval(jsonDate.replace(/\/Date\((\d+|\d+[+]\d+)\)\//gi, "new Date($1)"));
            var d = jsonDate.replace("/Date(", "").replace(")/", "");
            d = eval("new Date(" + d + ")");
            var curr_date = d.getDate();

            if (curr_date.toString().length == 1)
                curr_date = "0" + curr_date;

            var curr_month = d.getMonth() + 1;

            if (curr_month.toString().length == 1)
                curr_month = "0" + curr_month;

            var curr_year = d.getFullYear();

            var curr_hour = d.getHours();
            if (curr_hour.toString().length == 1)
                curr_hour = "0" + curr_hour;

            var curr_min = d.getMinutes();
            if (curr_min.toString().length == 1)
                curr_min = "0" + curr_min;

            var curr_sec = d.getSeconds();
            if (curr_sec.toString().length == 1)
                curr_sec = "0" + curr_sec;

            return curr_year + "-" + curr_month + "-" + curr_date + " " + curr_hour + ":" + curr_min + ":" + curr_sec;
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

        function LoadDetails(uploadSessionId) {
            var sUrl = '../Handlers/GridData.ashx?grid=UploadSessionDetails&uploadSessionId=' + uploadSessionId;

            $("#gridDetails").jqGrid("GridUnload");

            jQuery("#gridDetails").jqGrid({
                datatype: "json",
                url: sUrl,
                colNames: ['id', 'Type', 'Message'],
                colModel: [{ name: 'UploadSessionId', index: 'UploadSessionId', hidden: true },
                    {
                        name: 'Level', index: 'Level', width: 10,
                        formatter: function (value, options, rData) {
                            switch (value) {
                                case 0:
                                    return "INFO";
                                case 1:
                                    return "ERROR";
                                default:
                                    return "INFO";
                            }
                        }
                    },
                    { name: 'Message', index: 'Message' }],
                rowNum: 20,
                cmTemplate: { sortable: false },
                rowList: [20, 50, 100],
                pager: jQuery('#pagerDetails'),
                viewrecords: true,
                caption: "",
                loadComplete: function () {
                    $("#gridDetails").jqGrid('setGridWidth', $("#dialogDetails").width(), true);
                    $("#gridDetails").jqGrid('setGridHeight', $("#dialogDetails").height() - 60, true);
                }
            }).navGrid('#pagerDetails', { edit: false, add: false, del: false, search: false });
        }
    </script>
    <table width="100%">
        <tr>
            <td>From:</td><td><input type="text" id="dateFrom" /></td>
            <td>&nbsp;</td>
            <td>To:</td><td><input type="text" id="dateTo" /></td>
            <td>&nbsp;</td>
            <td><input type="button" value="Apply" id="btnSearch" /></td>
            <td><input type="button" value="Clear" id="btnClear" /></td>
            <td style="width: 100%; text-align: right"><input type="button" value="Back" id="btnBack" /></td>
        </tr>
    </table>
    <table id="mainGrid"></table> 
    <div id="mainGridPager"></div>
    <div id="dialogDetails" style="display: none;">
        <table id="gridDetails"></table> 
        <div id="pagerDetails"></div>
    </div>
</asp:Content>
