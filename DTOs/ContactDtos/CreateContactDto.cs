using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.ContactDtos
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Adres boş bırakılamaz.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        public string MapUrl { get; set; }
    }
}
