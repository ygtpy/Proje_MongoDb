using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.TeamsSocialLinkDtos
{
    public class CreateTeamsSocialLinkDto
    {
        [Required(ErrorMessage = "Personel ID boş bırakılamaz.")]
        public string TeamId { get; set; }

        [Required(ErrorMessage = "Platform adı boş bırakılamaz.")]
        public string Platform { get; set; }

        [Required(ErrorMessage = "URL boş bırakılamaz.")]
        public string Url { get; set; }

        public string Icon { get; set; }
    }
}
