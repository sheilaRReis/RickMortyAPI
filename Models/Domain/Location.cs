using Rick_MortyAPI.Models.Domain;

public class Location(int id = 0, string name = "", string type = "", string dimension = "", IEnumerable<Uri>? residents = null,
    Uri? url = null, DateTime? created = null)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public string Type { get; } = type;
    public string Dimension { get; } = dimension;
    public IEnumerable<Uri>? Residents { get; } = residents;
    public Uri? Url { get; } = url;
    public DateTime? Created { get; } = created;
}
