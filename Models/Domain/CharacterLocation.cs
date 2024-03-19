namespace Rick_MortyAPI.Models.Domain
{
    public class CharacterLocation
    {
        public CharacterLocation(string? name = "", Uri? url = null)
        {
            Name = name;
            Url = url;
        }

        public string? Name { get; }

        public Uri? Url { get; }
    }
}
