using EnsureThat;
using Newtonsoft.Json;
using Rick_MortyAPI.Helper;
using Rick_MortyAPI.Mapper;
using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Models.DTO;
using RickAndMortyAPI.Services;

namespace Rick_MortyAPI.Services
{
    public abstract class BaseService
    {
        private HttpClient Client { get; }
        protected IRickAndMortyMapper RickAndMortyMapper { get; }
        protected BaseService(IRickAndMortyMapper rickAndMortyMapper, string baseAddress)
        {
            RickAndMortyMapper = rickAndMortyMapper;

            Ensure.Bool.IsTrue(Uri.IsWellFormedUriString(baseAddress, UriKind.RelativeOrAbsolute));

            Client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
      
        protected BaseService() {
            var mapper = MapperModule.Resolve();
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://rickandmortyapi.com/")
            };
            RickAndMortyMapper = mapper;
        }
        protected async Task<T> Get<T>(string path)
        {
            var response = await Client.GetAsync(path);
            return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()) : default(T);
        }
        protected async Task<IEnumerable<T>> GetPages<T>(string url)
        {
            var result = new List<T>();
            var nextPage = 1;

            do
            {
                var pageUrl = nextPage == 1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}";
                var dto = await Get<PageDto<T>>(pageUrl);

                if (dto == null)
                    break;

                result.AddRange(dto.Results);
                nextPage = dto.Info.Next?.GetNextPageNumber() ?? -1;
            }
            while (nextPage != -1);

            return result;
        }

    }
}
