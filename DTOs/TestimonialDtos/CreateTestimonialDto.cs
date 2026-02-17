using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        public string FullName { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "Yorum boş bırakılamaz.")]
        public string Comment { get; set; }

        public string ImageUrl { get; set; }
    }
}
