using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rick_MortyAPI.Models.Domain;
using Rick_MortyAPI.Models.Enums;
using RickAndMortyAPI.Services;
using System.Net;

namespace RickAndMortyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyApiClient;

        public CharacterController(RickAndMortyService rickAndMortyApiClient)
        {
            _rickAndMortyApiClient = rickAndMortyApiClient ?? throw new ArgumentNullException(nameof(rickAndMortyApiClient));
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<Character>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllCharacters()
        {
            try
            {
                var characters = await _rickAndMortyApiClient.GetAllCharacters();
                return (characters != null && characters.Any()) ? Ok(characters) : NotFound("No registered characters were found");

            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service unavailable. Please try again later.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(Character), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            try
            {
                var character = await _rickAndMortyApiClient.GetCharacterById(id);
                return character != null ? Ok(character) : NotFound($"Sorry, we couldn't find any character with the provided ID {id}.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing your request:\n    {ex.Message}.");
            }
        }

        [HttpGet("getMultiple/")]
        [ProducesResponseType(typeof(Character), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMultipleCharacters([FromQuery] int[] id)
        {
            try
            {
                var character = await _rickAndMortyApiClient.GetMultipleCharacters(id);
                return (character != null && character.Any()) ? Ok(character) : NotFound($"Sorry, we couldn't find any character with the provided ID's: {string.Join(", ", id).TrimEnd(',')}.");
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
        [ProducesResponseType(typeof(Character), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> FilterCharacters(string name = "",
                                                          Status? status = null,
                                                          string species = "",
                                                          string type = "",
                                                          CharacterGender? gender = null,
                                                          CharacterLocation? dimension = null)
        {
            try
            {
                var filteredCharacters = await _rickAndMortyApiClient.FilterCharacters(name, status, species, type, gender, dimension);

                return (filteredCharacters != null && filteredCharacters.Any())
                        ? Ok(filteredCharacters)
                        : NotFound($"Sorry, we couldn't find any character with the provided filters: {string.Join(",", [name, type, status, species, gender, dimension]).TrimEnd(',')}.");
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
