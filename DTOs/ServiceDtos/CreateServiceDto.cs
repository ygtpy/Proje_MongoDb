using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.ServiceDtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Görsel URL boş bırakılamaz.")]
        public string ImageUrl { get; set; }
    }
}
