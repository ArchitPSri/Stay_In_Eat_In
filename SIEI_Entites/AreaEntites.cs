using System;
using System.Runtime.Serialization;

namespace SIEI_AreaEntites
{
    [DataContract]
    public class AreaList
    {
        [DataMember]
        public string Area { get; set; }
    }

    [DataContract]
    public class Area
    {
        [DataMember]
        public string areaOf { get; set; }
    }
}
