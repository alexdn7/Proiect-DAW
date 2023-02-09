using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Proiect_DAW.Services.LocatieService;
using System;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("Adauga-locatie"), Authorize(Roles = "Admin")]
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

        [HttpGet("all"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetAllLocations()
        {
            return Ok(await _locatieService.GetAll());
        }

        [HttpPut("edit/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateLocation(Guid id, [FromBody] LocatieDto locatie)
        {
            var verif = await _locatieService.Update(id, locatie);
            if (verif == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteLocation(Guid id)
        {
            await _locatieService.Delete(id);
            return Ok();
        }
    }
}
