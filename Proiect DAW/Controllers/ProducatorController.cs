using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Services.ProducatorService;

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
    }
}
