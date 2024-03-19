using AutoMapper;

namespace Rick_MortyAPI.Models.Domain
{
    internal class RickAndMortyMapper : IRickAndMortyMapper
    {
        public IMapper Mapper { get; set; }
    }
}
