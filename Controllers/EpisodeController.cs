using Microsoft.AspNetCore.Mvc;
using Rick_MortyAPI.Models.DTO;
using Rick_MortyAPI.Models.Enums;
using RickAndMortyAPI.Services;
using System.Net;
using System.Reflection;

namespace Rick_MortyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpisodeController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyApiClient;

        public EpisodeController(RickAndMortyService rickAndMortyApiClient)
        {
            _rickAndMortyApiClient = rickAndMortyApiClient ?? throw new ArgumentNullException(nameof(rickAndMortyApiClient));
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<EpisodeDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllEpisodes()
        {
            try
            {
                var episodes = await _rickAndMortyApiClient.GetAllEpisodes();
                return episodes != null ? Ok(episodes) : NotFound($"No registered episodes were found");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(EpisodeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEpisodeById(int id)
        {
            try
            {
                var episode = await _rickAndMortyApiClient.GetEpisode(id);
                return episode != null ? Ok(episode) : NotFound($"Sorry, we couldn't find any episode with the provided Id: {id}.");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpGet("getMultiple/")]
        [ProducesResponseType(typeof(IEnumerable<EpisodeDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMultipleEpisodes([FromQuery] int[] id)
        {
            try
            {
                var episodes = await _rickAndMortyApiClient.GetMultipleEpisodes(id);
                return (episodes != null && episodes.Any())
                        ? Ok(episodes) 
                        : NotFound($"Sorry, we couldn't find any episode with the provided ID's: {string.Join(", ", id).TrimEnd(',')}.");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {ex.Message}");
            }
        }

        [HttpGet("filter/")]
        [ProducesResponseType(typeof(IEnumerable<EpisodeDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> FilterEpisodes(string name = "",
           string episodeCode = "")
        {
            try
            {
                var episodes = await _rickAndMortyApiClient.FilterEpisodes(name, episodeCode);
                return (episodes != null && episodes.Any())
                        ? Ok(episodes)
                        : NotFound($"Sorry, we couldn't find any episode with the provided filters: {string.Join(", ", [name, episodeCode]).Trim().TrimEnd(',')}.");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request: {ex.Message}");
            }
        }
    }
}
