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

        public static class Fields
        {
            public const string MissionName = "mn";
            public const string SeriesId = "m_sid";
        }
    }
}
