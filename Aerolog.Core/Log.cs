using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Log: BaseMongoObject
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

        public static class Fields
        {
            public const string Text = "t";
            public const string Timestamp = "d";
            public const string SpeakerName = "sn";
            public const string MissionId = "l_mid";
        }
    }
}
