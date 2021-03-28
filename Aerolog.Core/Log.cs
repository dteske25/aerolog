using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Log : BaseMongoObject
    {
        [BsonElement(Fields.Text)]
        public string Text { get; set; }

        [BsonElement(Fields.Timestamp)]
        public DateTime Timestamp { get; set; }

        [BsonElement(Fields.SpeakerName)]
        public string SpeakerName { get; set; }

        [BsonElement(Fields.MissionId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MissionId { get; set; }

        [BsonElement(Fields.SeriesId)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SeriesId { get; set; }


        public static class Fields
        {
            public const string Text = "l_t";
            public const string Timestamp = "l_d";
            public const string SpeakerName = "l_sn";
            public const string MissionId = "l_mid";
            public const string SeriesId = "l_sid";
        }
    }
}
