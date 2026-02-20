using AkademiQMongoDb.Entities.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiQMongoDb.Entities
{
    public class Team : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string FullName {  get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        [BsonIgnore]
        public List<TeamsSocialLink> TeamsSocialLinks { get; set; } = new List<TeamsSocialLink>();
    }
}
