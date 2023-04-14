using Microsoft.AspNetCore.Mvc;
using ShipsApi.Application.Products;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Application.Ships.Commands.Create;
using ShipsApi.Application.Voyages;
using ShipsApi.Application.Voyages.Queries.GetAllVoyagesQuery;
using ShipsApi.Entities;
using ShipsApi.Models.Products;
using ShipsApi.Models.Ships;
using System.Threading;
using System.Threading.Tasks;

namespace ShipsApi.Controllers
{
    public class ProductViewController : BaseViewController
    {
        public IActionResult Create([FromQuery(Name = "Voyage")] VoyageVm voyage,
            string returnAction, string returnController = "Home")
        {
            var voyageId = voyage.Id.ToString();

            TempData["voyage"] = Serialize(voyage);
            TempData["returnAction"] = returnAction;
            TempData["returnController"] = returnController;
            TempData["voyageId"] = voyageId;

            return View(new CreateProductViewModel
            {
                Name = string.Empty,
                VoyageId = voyageId,
                ReturnAction = returnAction,
                ReturnController = returnController
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductVm product, CancellationToken cancellationToken)
        {
            var command = new CreateProductCommand
            {
                Name = product.Name,
            };
            var productId = await Mediator.Send(command, cancellationToken);

            var voyage = Deserialize(TempData["voyage"] as string);
            voyage.ProductId = productId;

            TempData["voyage"] = Serialize(voyage);

            return RedirectToAction(
                TempData["returnAction"] as string,
                TempData["returnController"] as string,
                new { id = TempData["voyageId"] as string }
            );
        }
    }
}
