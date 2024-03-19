namespace Rick_MortyAPI.Models.Domain
{
    public class CharacterOrigin(string name = "", Uri? url = null)
    {
        public string Name { get; set; } = name;

        public Uri? Url { get; set; } = url;
    }
}
