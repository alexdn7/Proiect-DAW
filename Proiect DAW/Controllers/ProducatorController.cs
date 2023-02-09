using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models;
using Proiect_DAW.Services.ProducatorService;
using Proiect_DAW.Services.VanzatorService;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Proiect_DAW.Controllers
{
    [Route("api/producator")]
    [ApiController]
    public class ProducatorController : ControllerBase
    {
        public readonly IProducatorService _producatorService;

        public ProducatorController(IProducatorService producatorService)
        {
            _producatorService = producatorService;
        }

        [HttpPost("Adauga-producator"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProducatorDto producator)
        {
            var ProducerToCreate = new Producator
            {
                Nume = producator.Nume,
                Descriere = producator.Descriere,
                LocatieId = producator.LocatieId
            };

            await _producatorService.Create(ProducerToCreate);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _producatorService.GetAll());
        }

        [HttpGet("Get-number")]
        public async Task<IActionResult> GetNumberOfProdusesMadeByProducerAsync(Guid producatorId)
        {
            var raspuns = await _producatorService.GetNumberOfProdusesMadeByProducerAsync(producatorId);
            return Ok(raspuns);
        }
    }
}
