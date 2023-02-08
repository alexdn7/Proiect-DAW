using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Helpers.NewFolder.Attributes;
using Proiect_DAW.Models.DTOs.Users;
using Proiect_DAW.Models;
using Proiect_DAW.Models.Enums;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Proiect_DAW.Models.DTOs;
using System;

namespace Proiect_DAW.Controllers
{
    [Route("api/vanzator")]
    [ApiController]
    public class VanzatorController : ControllerBase
    {
        public readonly IVanzatorService _vanzatorService;

        public VanzatorController(IVanzatorService vanzatorService)
        {
            _vanzatorService = vanzatorService;
        }

        [HttpPost("Adauga-vanzator")]
        public async Task<IActionResult> CreateVanzator(VanzatorDto vanzator)
        {
            var VanzatorToCreate = new Vanzator
            {
                Nume = vanzator.Nume,
                Telefon = vanzator.Telefon
            };

            await _vanzatorService.Create(VanzatorToCreate);
            return Ok();
        }

        [HttpGet]
         public async Task<IActionResult> GetAll()
        {
            return Ok(await _vanzatorService.GetAll());
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult> UpdateArticol(Guid id, [FromBody] VanzatorDto vanzator)
        {
            var verif = await _vanzatorService.Update(id, vanzator);
            if (verif == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteArticol(Guid id)
        {
            await _vanzatorService.Delete(id);
            return Ok();
        }
    }
}
