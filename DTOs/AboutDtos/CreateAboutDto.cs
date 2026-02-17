using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.AboutDtos
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "Resim URL 1 boş bırakılamaz.")]
        public string ImageUrl1 { get; set; }
        
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string SideImage1 { get; set; }
        public string SideImage2 { get; set; }

        [Required(ErrorMessage = "Başlık 1 boş bırakılamaz.")]
        public string Title1 { get; set; }
        
        public string Title2 { get; set; }

        [Required(ErrorMessage = "Açıklama 1 boş bırakılamaz.")]
        public string Description1 { get; set; }
        
        public string Description2 { get; set; }
        
        public int StartYear { get; set; }
    }
}
