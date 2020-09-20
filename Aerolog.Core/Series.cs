using MongoDB.Bson.Serialization.Attributes;

namespace Aerolog.Core
{
    public class Series : BaseMongoObject
    {
        [BsonElement(Fields.SeriesId)]
        public string SeriesName { get; set; }

        public static class Fields
        {
            public const string SeriesId = "sid";
        }
    }
}
