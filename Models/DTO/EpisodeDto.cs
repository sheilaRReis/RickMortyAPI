namespace Rick_MortyAPI.Models.DTO
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Air_date { get; set; }
        public string? Episode { get; set; }
        public string[]? Characters { get; set; }
        public string? Url { get; set; }
        public string? Created { get; set; }
    }
}
