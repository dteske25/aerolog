using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Series : BaseMongoObject
    {
        [BsonElement(Fields.SeriesName)]
        public string SeriesName { get; set; }
        [BsonElement(Fields.FileId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FileId { get; set; }
        [BsonIgnore]
        public File File { get; set; }

        public static class Fields
        {
            public const string SeriesName = "s_sn";
            public const string FileId = "s_fid";
        }
    }
}
