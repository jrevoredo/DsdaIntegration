using System.Runtime.Serialization;

namespace Dsda.DataAccess.DataContracts
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