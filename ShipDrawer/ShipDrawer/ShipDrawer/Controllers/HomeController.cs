using Microsoft.AspNetCore.Mvc;
using ShipDrawer.Interfaces;

namespace ShipDrawer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShipRepository _shipRepository;

        public HomeController(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        public IActionResult Index()
        {
            _shipRepository.GetAllVoyages();
            return View();
        }

        [HttpGet]
        public IActionResult GetVoyages()
        {
            return Ok(_shipRepository.GetAllVoyages());
        }
    }
}
