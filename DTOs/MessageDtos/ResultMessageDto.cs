
namespace AkademiQMongoDb.DTOs.MessageDtos
{
    public class ResultMessageDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
