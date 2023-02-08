using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Proiect_DAW.Services.LocatieService;

namespace Proiect_DAW.Controllers
{
    [Route("api/locatie")]
    [ApiController]
    public class LocatieController : ControllerBase
    {
        public readonly ILocatieService _locatieService;

        public LocatieController(ILocatieService locatieService)
        {
            _locatieService = locatieService;
        }

        [HttpPost("Adauga-locatie")]
        public async Task<IActionResult> CreateLocation(LocatieDto locatie)
        {
            var LocationToCreate = new Locatie
            {
                Tara = locatie.Tara,
                Oras = locatie.Oras,
                Strada = locatie.Strada
            };

            await _locatieService.Create(LocationToCreate);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            return Ok(await _locatieService.GetAll());
        }
    }
}
