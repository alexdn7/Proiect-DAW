using Microsoft.AspNetCore.Mvc;
using Proiect_DAW.Services.ProdusService;

namespace Proiect_DAW.Controllers
{
    [Route("api/produs")]
    [ApiController]
    public class ProdusController : ControllerBase
    {
        private IProdusService _produsService;

        public ProdusController(IProdusService produsService)
        {
            _produsService = produsService;
        }

    }
}
