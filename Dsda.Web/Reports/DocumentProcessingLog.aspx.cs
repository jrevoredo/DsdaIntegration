using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using Dsda.DataAccess;

namespace Dsda.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int sessionId = 0;

            if(!string.IsNullOrWhiteSpace(Request.Params["SessionId"]))
                int.TryParse(Request.Params["SessionId"], out sessionId);

            XLWorkbook workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Document Processing Log");

            AddTitle(ws, 1, "Date", 20);
            AddTitle(ws, 2, "Source Directory", 100);
            AddTitle(ws, 3, "Name", 20);
            AddTitle(ws, 4, "Dealer ID", 20);
            AddTitle(ws, 5, "Contract Date", 20);
            AddTitle(ws, 6, "CustNo", 20);
            
            AddTitle(ws, 7, "Stock", 20);
            AddTitle(ws, 8, "Vin", 20);
            AddTitle(ws, 9, "Deal_id", 20);
            AddTitle(ws, 10, "CabId", 20);
            AddTitle(ws, 11, "DocDate", 20);
            AddTitle(ws, 12, "DocType", 20);
            AddTitle(ws, 13, "DocFolder", 100);
            AddTitle(ws, 14, "Is Uploaded", 20);


            DA da = new DA();
            
            var list = da.GetDocumentProcessingLog(sessionId);
            int rowIndex = 2;
            foreach (var docInfo in list)
            {
                ws.Cell(rowIndex, 1).SetValue(docInfo.ProcessingDate.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                ws.Cell(rowIndex, 2).SetValue(docInfo.SourceDir);
                ws.Cell(rowIndex, 3).SetValue(docInfo.Name);
                ws.Cell(rowIndex, 4).SetValue(docInfo.DealerId);
                ws.Cell(rowIndex, 5).SetValue(docInfo.ContractDate);
                ws.Cell(rowIndex, 6).SetValue(docInfo.CustNo);
                ws.Cell(rowIndex, 7).SetValue(docInfo.Stock);
                ws.Cell(rowIndex, 8).SetValue(docInfo.Vin);
                ws.Cell(rowIndex, 9).SetValue(docInfo.DealId);
                ws.Cell(rowIndex, 10).SetValue(docInfo.CabId);
                ws.Cell(rowIndex, 11).SetValue(docInfo.DocDate);
                ws.Cell(rowIndex, 12).SetValue(docInfo.DocType);
                ws.Cell(rowIndex, 13).SetValue(docInfo.DocFolder);
                ws.Cell(rowIndex, 14).SetValue(docInfo.IsProcessed);

                if (!docInfo.IsProcessed)
                {
                    ws.Row(rowIndex).Style.Font.FontColor = XLColor.Red;
                    ws.Cell(rowIndex, 1).Comment.AddText(docInfo.ProcessedErrors);
                    ws.Cell(rowIndex, 1).Comment.Style.Size.Width = 200;
                    ws.Cell(rowIndex, 1).Comment.Style.Size.Height = 200;
                }
                rowIndex++;
            }

            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"DSDAUploadLog.xlsx\"");

            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }

            httpResponse.End();
        }

        private void AddTitle(IXLWorksheet ws, int index, string name, int width)
        {
            ws.Cell(1, index).Style.Fill.BackgroundColor = XLColor.LightGray;
            ws.Cell(1, index).Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Border.SetRightBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);
            ws.Cell(1, index).Style.Font.Bold = true;
            ws.Column(index).Width = width;
            ws.Cell(1, index).SetValue(name);
        }
    }
}