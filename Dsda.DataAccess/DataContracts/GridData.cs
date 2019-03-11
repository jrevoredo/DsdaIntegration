using System.Runtime.Serialization;

namespace Dsda.DataAccess.DataContracts
{
    [DataContract]
    public class GridData
    {
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public int records { get; set; }
        [DataMember]
        public GridDataRow[] rows { get; set; }
    }
}