using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Event : BaseMongoObject, IHasUploadStatus
    {
        [BsonElement(Fields.Text)]
        public string Text { get; set; }

        [BsonElement(Fields.Timestamp)]
        public DateTime Timestamp { get; set; }

        [BsonElement(Fields.MissionId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MissionId { get; set; }

        [BsonElement(Fields.SeriesId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SeriesId { get; set; }

        [BsonElement(Fields.FileId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FileId { get; set; }

        [BsonIgnore]
        public File File { get; set; }

        [BsonElement(Fields.UploadStatus)]
        public UploadStatusTypes UploadStatus { get; set; }

        public static class Fields
        {
            public const string Text = "e_t";
            public const string Timestamp = "e_d";
            public const string MissionId = "e_mid";
            public const string SeriesId = "e_sid";
            public const string FileId = "e_fid";
            public const string UploadStatus = "e_us";
        }
    }
}
