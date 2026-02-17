using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.FeatureDtos
{
    public class CreateFeatureDto
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        
        public bool IsActive { get; set; }
    }
}
