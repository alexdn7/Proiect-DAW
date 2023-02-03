using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Services.VanzatorService;

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
    }
}
