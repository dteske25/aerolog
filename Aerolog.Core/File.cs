using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class File: BaseMongoObject
    {
        [BsonElement(Fields.ContentType)]
        public string ContentType { get; set; }

        [BsonElement(Fields.ContentDisposition)]
        public string ContentDisposition { get; set; }

        [BsonElement(Fields.FileName)]
        public string FileName { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement(Fields.FileId)]
        public string FileId { get; set; }

        [BsonIgnore]
        public byte[] FileContent { get; set; }

        public static class Fields
        {
            public const string ContentType = "ct";
            public const string ContentDisposition = "cd";
            public const string FileName = "fn";
            public const string FileId = "f_fid";
        }

    }
}
