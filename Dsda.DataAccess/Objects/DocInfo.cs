using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dsda.DataAccess.Objects
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
        public string CabId	 { get; set; }
        public string DocDate { get; set; }
        public string DocType { get; set; }
        public string DocFolder { get; set; }
        public bool IsProcessed { get; set; }
        public string ProcessedErrors { get; set; }

        public DocInfo(string sourceDir, string name, string dealerId)
        {
            SourceDir = sourceDir;
            Name = name;
            DealerId = dealerId;
            ProcessedErrors = "";
            IsProcessed = false;
            ProcessingDate = DateTime.Now;
        }

    }
}
