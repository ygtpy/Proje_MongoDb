namespace AkademiQMongoDb.DTOs.TeamsSocialLinkDtos
{
    public class UpdateTeamsSocialLinkDto
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
