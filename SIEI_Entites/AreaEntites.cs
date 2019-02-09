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
}
