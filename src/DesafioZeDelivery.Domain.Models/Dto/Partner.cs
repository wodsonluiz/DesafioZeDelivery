using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Runtime.Serialization;

namespace DesafioZeDelivery.Domain.Models.Dto
{
    [DataContract]
    public class Partner
    {
        public Partner()
        {
            _id = Guid.NewGuid().ToString();
        }

        [BsonId]
        [DataMember]
        public string _id { get; private set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string tradingName { get; set; }
        [DataMember]
        public string ownerName { get; set; }
        [DataMember]
        public string document { get; set; }
        [DataMember]
        public GeometryMultiPolygon coverageArea { get; set; }
        [DataMember]
        public GeometryPoint address { get; set; }
    }
}
