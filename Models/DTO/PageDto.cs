using System.Collections.Generic;
namespace Rick_MortyAPI.Models.DTO
{
    public class PageDto<T> {

        public PageInfoDto? Info { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
