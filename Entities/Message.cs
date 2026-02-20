using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class Message : BaseEntity
    {
        public string NameSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Subject { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
