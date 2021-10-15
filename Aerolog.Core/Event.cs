using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Event : BaseMongoObject
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

        [BsonElement(Fields.Image)]
        public string Image { get; set; }


        public static class Fields
        {
            public const string Text = "e_t";
            public const string Timestamp = "e_d";
            public const string MissionId = "e_mid";
            public const string SeriesId = "e_sid";
            public const string Image = "e_i";
            public const string FileId = "e_fid";
        }
    }
}
