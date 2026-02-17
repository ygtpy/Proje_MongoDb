using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.MessageDtos
{
    public class CreateMessageDto
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu boş bırakılamaz.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği boş bırakılamaz.")]
        public string MessageContent { get; set; }
        
        public bool IsRead { get; set; }
    }
}
