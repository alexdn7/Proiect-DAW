using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;
using Proiect_DAW.Services.ProdusService;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Proiect_DAW.Controllers
{
    [Route("api/produs")]
    [ApiController]
    public class ProdusController : ControllerBase
    {
        public readonly IProdusService _produsService;

        public ProdusController(IProdusService produsService)
        {
            _produsService = produsService;
        }

        [HttpPost("Adauga-produs"), Authorize(Roles = "Admin") ]
        public async Task<IActionResult> Create(ProdusDto produs)
        {
            var ProdusToCreate = new Produs
            {
                ImgURL = produs.ImgURL,
                Denumire = produs.Denumire,
                Descriere = produs.Descriere,
                Pret = produs.Pret,
                Stoc = produs.Stoc,
                ProductorId = produs.ProducatorID,
            };

            await _produsService.Create(ProdusToCreate);
            return Ok();
        }

        [HttpGet("Toate-produsele"), Authorize(Roles = "User, Admin") ]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produsService.GetAll());
        }
    }
}
