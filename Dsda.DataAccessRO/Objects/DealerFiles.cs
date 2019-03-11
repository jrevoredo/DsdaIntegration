using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dsda.DataAccessRO.Objects
{
    public class DealerFiles : IEquatable<DealerFiles>
    {
        public string DealerId { get; set; }
        public string CabId { get; set; }
        public string Folder { get; set; }
        public string FullFileName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public bool ValidDealerFile { get; set; }
        public DocInfo objDocInfo { get; set; }

        public DealerFiles(string p_DealerId, string p_FileName)
        {
            this.DealerId = p_DealerId;
            this.FileName = p_FileName;
        }

        public DealerFiles(string p_DealerId, string p_CabId, string p_Folder,
                           string p_FullFileName, string p_FileName, string p_FileType,
                           long p_FileSize, bool p_ValidDealerFile)
        {
            this.DealerId = p_DealerId;
            this.CabId = p_CabId;
            this.Folder = p_Folder;
            this.FullFileName = p_FullFileName;
            this.FileName = p_FileName;
            this.FileType = p_FileType;
            this.FileSize = p_FileSize;
            this.ValidDealerFile = p_ValidDealerFile;
            this.objDocInfo = new DocInfo(0, DateTime.MinValue, string.Empty, string.Empty, 
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                false, string.Empty);
        }

        // Overrided methods for interface IEquatable

        public override string ToString() 
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            DealerFiles objAsDealerFiles = obj as DealerFiles;
            if (objAsDealerFiles == null) return false;
            else return Equals(objAsDealerFiles);
        }

        public override int GetHashCode()
        {
            return this.FileName.GetHashCode();
        }

        public bool Equals(DealerFiles other)
        {
            if (other == null) return false;
            return (this.DealerId.Equals(other.DealerId) && this.FileName.Equals(other.FileName));
        }

        public static bool operator ==(DealerFiles obj1, DealerFiles obj2)
        {
            if (object.ReferenceEquals(obj1, obj2)) return true;
            if (object.ReferenceEquals(obj1, null)) return false;
            if (object.ReferenceEquals(obj2, null)) return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(DealerFiles obj1, DealerFiles obj2)
        {
            if (object.ReferenceEquals(obj1, obj2)) return false;
            if (object.ReferenceEquals(obj1, null)) return true;
            if (object.ReferenceEquals(obj2, null)) return true;

            return !obj1.Equals(obj2);
        }

    }
}
