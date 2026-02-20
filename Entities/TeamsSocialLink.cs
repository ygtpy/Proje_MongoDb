using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class TeamsSocialLink : BaseEntity
    {
        public string TeamId { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}
