using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.BannerDtos
{
    public class CreateBannerDto
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Görsel URL boş bırakılamaz.")]
        public string ImageUrl { get; set; }
    }
}
