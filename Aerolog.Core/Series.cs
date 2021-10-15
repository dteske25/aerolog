using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Series : BaseMongoObject
    {
        [BsonElement(Fields.SeriesName)]
        public string SeriesName { get; set; }
        [BsonElement(Fields.ImageUrl)]
        public string Image { get; set; }

        public static class Fields
        {
            public const string SeriesName = "s_sn";
            public const string ImageUrl = "s_i";
        }
    }
}
