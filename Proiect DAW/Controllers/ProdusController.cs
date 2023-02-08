using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;
using Proiect_DAW.Services.ProdusService;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;

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

        [HttpPost("Adauga-produs")]
        public async Task<IActionResult> Create(ProdusDto produs)
        {
            var ProdusToCreate = new Produs
            {
                ImgURL = produs.ImgURL,
                Denumire = produs.Denumire,
                Descriere = produs.Descriere,
                Pret = produs.Pret,
                Stoc = produs.Stoc
            };

            await _produsService.Create(ProdusToCreate);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produsService.GetAll());
        }
    }
}
