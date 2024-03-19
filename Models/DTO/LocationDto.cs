namespace Rick_MortyAPI.Models.DTO
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Dimension { get; set; }
        public string[]? Residents { get; set; }
        public string? Url { get; set; }
        public string? Created { get; set; }
    }
}
