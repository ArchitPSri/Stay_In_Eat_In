using System;
using System.Runtime.Serialization;

namespace SIEI_Entites
{
    [DataContract]
    public class HostelDetails
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Pin { get; set; }

        [DataMember]
        public string Mobile1 { get; set; }

        [DataMember]
        public string Mobile2 { get; set; }

        [DataMember]
        public string RoomFor { get; set; }

        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public int Furnished { get; set; }

        [DataMember]
        public string StartingPrice { get; set; }

        [DataMember]
        public int FoodAvail { get; set; }
    }
}
