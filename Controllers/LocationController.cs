using Microsoft.AspNetCore.Mvc;
using RickAndMortyAPI.Services;
using System.Net;

namespace Rick_MortyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyApiClient;

        public LocationController(RickAndMortyService rickAndMortyApiClient)
        {
            _rickAndMortyApiClient = rickAndMortyApiClient ?? throw new ArgumentNullException(nameof(rickAndMortyApiClient));
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<Location>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var locations = await _rickAndMortyApiClient.GetAllLocations();
                return locations != null ? Ok(locations) : NotFound("No registered locations were found");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving all locations: {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var location = await _rickAndMortyApiClient.GetLocation(id);
                return location != null 
                        ? Ok(location) 
                        : NotFound($"Sorry, we couldn't find any location with the provided Id: {id}.");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving location with ID {id}: {ex.Message}");
            }
        }

        [HttpGet("getMultiple/")]
        [ProducesResponseType(typeof(IEnumerable<Location>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMultipleLocations([FromQuery] int[] id)
        {
            try
            {
                var locations = await _rickAndMortyApiClient.GetMultipleLocations(id);
                return (locations != null && locations.Any())
                            ? Ok(locations) 
                            : NotFound($"Sorry, we couldn't find any location with the provided ID's: {string.Join(", ",id).TrimEnd(',')}.");
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving multiple locations: {ex.Message}");
            }
        }

        [HttpGet("filter/")]
        [ProducesResponseType(typeof(IEnumerable<Location>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> FilterLocations(string name = "",
           string type = "",
           string dimension = "")
        {
            try
            {
                var locations = await _rickAndMortyApiClient.FilterLocations(name, type, dimension);
                return (locations != null && locations.Any())
                        ? Ok(locations)
                        : NotFound($"Sorry, we couldn't find any location with the provided filters: {string.Join(",", [name, type, dimension]).TrimEnd(',')}.");

            }
            catch (Exception ex) when (ex is HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while filtering locations: {ex.Message}.");
            }
        }
    }
}
