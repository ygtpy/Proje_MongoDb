using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.TeamDtos
{
    public class CreateTeamDto
    {
        [Required(ErrorMessage = "Ad Soyad boş bırakılamaz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Ünvan boş bırakılamaz.")]
        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}
