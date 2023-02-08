using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Helpers.NewFolder.Attributes;
using Proiect_DAW.Models.DTOs.Users;
using Proiect_DAW.Models;
using Proiect_DAW.Models.Enums;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Proiect_DAW.Models.DTOs;

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
    }

}
