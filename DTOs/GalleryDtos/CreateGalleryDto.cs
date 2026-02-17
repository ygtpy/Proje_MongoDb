using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.GalleryDtos
{
    public class CreateGalleryDto
    {
        [Required(ErrorMessage = "Görsel URL boş bırakılamaz.")]
        public string ImageUrl { get; set; }
    }
}
