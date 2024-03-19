using Rick_MortyAPI.Models.Enums;

namespace Rick_MortyAPI.Models.Domain
{
    public class Character(int id = 0, string name = "", Status status = 0,
        string species = "", string type = "", CharacterGender gender = 0,
        CharacterLocation? location = null, CharacterOrigin? origin = null, Uri? image = null,
        IEnumerable<Uri>? episode = null, Uri? url = null, DateTime? created = null)
    {
        public int Id { get; } = id;
        public string Name { get; } = name;
        public Status Status { get; } = status;
        public string Species { get; } = species;
        public string Type { get; } = type;
        public CharacterGender Gender { get; } = gender;
        public CharacterLocation? Location { get; } = location;
        public CharacterOrigin? Origin { get; } = origin;
        public Uri? Image { get; } = image;
        public IEnumerable<Uri>? Episode { get; } = episode;
        public Uri? Url { get; } = url;
        public DateTime? Created { get; } = created;

    }
}
