using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Models.DTO;

namespace Rick_MortyAPI.Services
{
    public interface IRickAndMortyService
    {
        public Task<IEnumerable<CharacterDto>> GetAllCharacters();
        public Task<CharacterDto> GetCharacterById(int id);
        public Task<IEnumerable<Character>> GetMultipleCharacters(int[] ids);


    }
}
