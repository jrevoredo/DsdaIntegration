using System.Runtime.Serialization;

namespace Dsda.DataAccessRO.DataContracts
{
    [DataContract]
    public class GridDataRow
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public object[] cell { get; set; }
    }
}
