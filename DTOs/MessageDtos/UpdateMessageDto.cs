namespace AkademiQMongoDb.DTOs.MessageDtos
{
    public class UpdateMessageDto
    {
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public bool IsRead { get; set; }
    }
}
