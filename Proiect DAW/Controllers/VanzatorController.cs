using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Helpers.NewFolder.Attributes;
using Proiect_DAW.Models.DTOs.Users;
using Proiect_DAW.Models;
using Proiect_DAW.Models.Enums;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Proiect_DAW.Models.DTOs;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

        [HttpPost("Adauga-vanzator"), Authorize(Roles = "Admin")]
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

        [HttpGet("Toti-vanzatorii"), Authorize("User, Admin")]
         public async Task<IActionResult> GetAll()
        {
            return Ok(await _vanzatorService.GetAll());
        }

        [HttpPut("edit/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateVanzator(Guid id, [FromBody] VanzatorDto vanzator)
        {
            var verif = await _vanzatorService.Update(id, vanzator);
            if (verif == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeteleVendor(Guid id)
        {
            await _vanzatorService.Delete(id);
            return Ok();
        }
    }
}
