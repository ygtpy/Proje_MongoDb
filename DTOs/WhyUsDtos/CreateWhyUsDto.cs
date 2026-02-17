using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.WhyUsDtos
{
    public class CreateWhyUsDto
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; }

        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
    }
}
