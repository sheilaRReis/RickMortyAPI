public class Episode(int id = 0, string name = "", DateTime? airDate = null,
    string episodeCode = "", IEnumerable<Uri>? characters = null,
    Uri? url = null, DateTime? created = null)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public DateTime? AirDate { get; } = airDate;
    public string EpisodeCode { get; } = episodeCode;
    public IEnumerable<Uri>? Characters { get; } = characters;
    public Uri? Url { get; } = url;
    public DateTime? Created { get; } = created;
}
