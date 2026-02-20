using AkademiQMongoDb.Entities.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class WhyUs : BaseEntity
    {
        public string Title {  get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Item1 { get; set; } = string.Empty;
        public string Item2 { get; set; } = string.Empty;
        public string Item3 { get; set; } = string.Empty;
    }
}
