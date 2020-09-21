using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Series : BaseMongoObject
    {
        [BsonElement(Fields.SeriesName)]
        public string SeriesName { get; set; }

        public static class Fields
        {
            public const string SeriesName = "sn";
        }
    }
}
