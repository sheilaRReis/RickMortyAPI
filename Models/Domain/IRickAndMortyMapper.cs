using AutoMapper;

namespace Rick_MortyAPI.Models.Domain
{
    public interface IRickAndMortyMapper
    {
        IMapper Mapper { get; set; }
    }
}
