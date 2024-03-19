using EnsureThat;
using Newtonsoft.Json;
using Rick_MortyAPI.Helper;
using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Models.DTO;
using Rick_MortyAPI.Models.Enums;
using Rick_MortyAPI.Services;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RickAndMortyAPI.Services
{
    public class RickAndMortyService : BaseService, IRickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private const string _urlCharacter = "api/character/";
        protected IRickAndMortyMapper _rickAndMortyMapper { get; }

        public RickAndMortyService(HttpClient httpClient, IRickAndMortyMapper rickAndMortyMapper, string baseAddress = "https://rickandmortyapi.com/")
        {
            _httpClient =  new HttpClient{BaseAddress = new Uri(baseAddress)};
            _baseUrl = baseAddress;
            _rickAndMortyMapper = rickAndMortyMapper;
        }
        public RickAndMortyService(IRickAndMortyMapper rickAndMortyMapper, string baseAddress = "https://rickandmortyapi.com/") : base(rickAndMortyMapper, baseAddress)
        {
        }

        #region Characters
        public async Task<IEnumerable<CharacterDto>> GetAllCharacters()
        {
           var characterList = await GetPages<CharacterDto>(_urlCharacter);

            return RickAndMortyMapper.Mapper.Map<IEnumerable<CharacterDto>>(characterList);
        }

        public async Task<CharacterDto> GetCharacterById(int id)
        {
            string path = $"{_baseUrl+_urlCharacter}/{id}";
            return await Get<CharacterDto>(path);
        }
        public async Task<IEnumerable<Character>> GetMultipleCharacters(int[] ids)
        {
            var characterList = await Get<IEnumerable<CharacterDto>>($"{_urlCharacter}/{string.Join(",", ids)}");

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Character>>(characterList);
        }
        public async Task<IEnumerable<Character>> FilterCharacters(string name = "",
           Status? status = null,
           string species = "",
           string type = "",
           CharacterGender? gender = null,
           CharacterLocation? dimension = null)
        {
            var parameters = new List<(string, string)>
            {
                (nameof(name), name),
                (nameof(type), type),
                (nameof(species), species),
                (nameof(status), status?.ToString()),
                (nameof(gender), gender?.ToString()),
                (nameof(dimension), dimension?.ToString())
            };

            var url = _urlCharacter.BuildFilterUrl(parameters.ToArray());

            var characterList = await GetPages<CharacterDto>(url);

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Character>>(characterList);
        }
        #endregion Characters

        #region Location
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            var location = await GetPages<LocationDto>("api/location/");

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Location>>(location);
        }

        public async Task<IEnumerable<Location>> GetMultipleLocations(int[] ids)
        {
            var locationList = await Get<IEnumerable<LocationDto>>($"api/location/{string.Join(",", ids)}");

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Location>>(locationList);
        }

        public async Task<Location> GetLocation(int id)
        {
            if (id < 1) return null;
            var location = await Get<LocationDto>($"api/location/{id}");

            return RickAndMortyMapper.Mapper.Map<Location>(location);
        }

        public async Task<IEnumerable<Location>> FilterLocations(string name = "",
            string type = "",
            string dimension = "")
        {
            var parameters = new List<(string, string)>
            {
                (nameof(name), name),
                (nameof(type), type),
                (nameof(dimension), dimension)
            };

            var url = "/api/location/".BuildFilterUrl(parameters.ToArray());

            var locationList = await GetPages<LocationDto>(url);

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Location>>(locationList);
        }
        #endregion

        #region Episode
        public async Task<IEnumerable<Episode>> GetAllEpisodes()
        {
            var dto = await GetPages<EpisodeDto>("api/episode/");

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Episode>>(dto);
        }

        public async Task<Episode> GetEpisode(int id)
        {
            if (id < 1) return null;

            var dto = await Get<EpisodeDto>($"api/episode/{id}");

            return RickAndMortyMapper.Mapper.Map<Episode>(dto);
        }

        public async Task<IEnumerable<Episode>> GetMultipleEpisodes(int[] ids)
        {
            if (ids.Length == 0)
                return Enumerable.Empty<Episode>();

            var dto = await Get<IEnumerable<EpisodeDto>>($"api/episode/{string.Join(",", ids)}");
            return RickAndMortyMapper.Mapper.Map<IEnumerable<Episode>>(dto);
        }

        public async Task<IEnumerable<Episode>> FilterEpisodes(string name = "",
            string episode = "")
        {
            //Ensure.Bool.IsTrue(!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(episode));
            
            var parameters = new List<(string, string)>
            {
                (nameof(name), name),
                (nameof(episode), episode),
            };
            
            var url = "/api/episode/".BuildFilterUrl(parameters.ToArray());

            var dto = await GetPages<EpisodeDto>(url);

            return RickAndMortyMapper.Mapper.Map<IEnumerable<Episode>>(dto);
        }
    }
    #endregion
}

