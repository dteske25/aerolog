using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Mission: BaseMongoObject
    {
        [BsonElement(Fields.MissionName)]
        public string MissionName { get; set; }   

        [BsonElement(Fields.SeriesId)]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string SeriesId { get; set; }

        [BsonElement(Fields.ImageUrl)]
        public string Image { get; set; }

        [BsonElement(Fields.Speakers)]
        public List<Speaker> Speakers { get; set; }

        public static class Fields
        {
            public const string MissionName = "mn";
            public const string SeriesId = "m_sid";
            public const string ImageUrl = "m_i";
            public const string Speakers = "m_s";
        }
    }

    public class Speaker
    {
        public string Name { get; set; }
        public string Label { get; set; }
    }
}
