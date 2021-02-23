using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Mission: BaseMongoObject, IHasUploadStatus
    {
        [BsonElement(Fields.MissionName)]
        public string MissionName { get; set; }   

        [BsonElement(Fields.SeriesId)]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string SeriesId { get; set; }

        [BsonElement(Fields.FileId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FileId { get; set; }

        [BsonElement(Fields.Speakers)]
        public Dictionary<string, string> Speakers { get; set; }

        [BsonIgnore]
        public File File { get; set; }

        [BsonElement(Fields.UploadStatus)]
        public UploadStatusTypes UploadStatus { get; set; }

        public static class Fields
        {
            public const string MissionName = "mn";
            public const string SeriesId = "m_sid";
            public const string FileId = "m_fid";
            public const string Speakers = "m_s";
            public const string UploadStatus = "m_us";

        }
    }
}
