using Microsoft.AspNetCore.Mvc;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Ships.Commands.Create;
using ShipsApi.Application.Voyages;
using ShipsApi.Models.Ships;
using System.Threading;
using System.Threading.Tasks;

namespace ShipsApi.Controllers
{
    public class ShipViewController : BaseViewController
    {
        public IActionResult Create([FromQuery(Name = "Voyage")] VoyageVm voyage,
            string returnAction, string returnController = "Home")
        {
            var voyageId = voyage.Id.ToString();

            TempData["voyage"] = Serialize(voyage);
            TempData["returnAction"] = returnAction;
            TempData["returnController"] = returnController;
            TempData["voyageId"] = voyageId;

            return View(new CreateShipViewModel
            {
                Name = string.Empty,
                VoyageId = voyageId,
                ReturnAction = returnAction,
                ReturnController = returnController
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ShipVm ship, CancellationToken cancellationToken)
        {
            var command = new CreateShipCommand
            {
                Name = ship.Name,
            };
            var shipId = await Mediator.Send(command, cancellationToken);

            var voyage = Deserialize(TempData["voyage"] as string);
            voyage.ShipId = shipId;

            TempData["voyage"] = Serialize(voyage);

            return RedirectToAction(
                TempData["returnAction"] as string,
                TempData["returnController"] as string,
                new { id = TempData["voyageId"] as string }
            );
        }
    }
}
