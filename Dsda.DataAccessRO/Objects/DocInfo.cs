using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dsda.DataAccessRO.Objects
{
    public class DocInfo
    {
        public int DocInfoId { get; set; }
        public DateTime ProcessingDate { get; set; }
        public string SourceDir { get; set; }
        public string DealerId { get; set; }
        public string TagNames { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public string ContractDate { get; set; }
        public string CustNo { get; set; }
        public string Name1 { get; set; }
        public string Name { get; set; }
        public string Stock { get; set; }
        public string Vin { get; set; }
        public string VehID { get; set; }
        public string DealId { get; set; }
        public string CabId { get; set; }
        public string DocDate { get; set; }
        public string DocType { get; set; }
        public string DocFolder { get; set; }
        public bool IsProcessed { get; set; }
        public string ProcessedErrors { get; set; }

        public DocInfo(string sourceDir, string name, string dealerId)
        {
            this.SourceDir = sourceDir;
            this.Name = name;
            this.DealerId = dealerId;
            this.ProcessedErrors = "";
            this.IsProcessed = false;
            this.ProcessingDate = DateTime.Now;
        }

        public DocInfo(int docInfoId, DateTime processingDate, string sourceDir, string dealerId, 
            string tagNames, string openDate, string closeDate, string contractDate, string custNo,
            string name1, string name, string stock, string vin, string vehID, string dealId,
            string cabId, string docDate, string docType, string docFolder,
            bool isProcessed, string processedErrors)
        {
            this.DocInfoId = docInfoId;
            this.ProcessingDate = processingDate;
            this.SourceDir = sourceDir;
            this.DealerId = dealerId;
            this.TagNames = tagNames;
            this.OpenDate = openDate;
            this.CloseDate = closeDate;
            this.ContractDate = contractDate;
            this.CustNo = custNo;
            this.Name1 = name1;
            this.Name = name;
            this.Stock = stock;
            this.Vin = vin;
            this.VehID = vehID;
            this.DealId = dealId;
            this.CabId = cabId;
            this.DocDate = docDate;
            this.DocType = docType;
            this.DocFolder = docFolder;
            this.IsProcessed = isProcessed;
            this.ProcessedErrors = processedErrors;
        }
    
    }
}
