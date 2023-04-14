using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipsApi.Application.Voyages.Queries.GetAllVoyagesQuery;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using ShipsApi.Application.Voyages;
using ShipsApi.Models.Voyages;
using ShipsApi.Application.Ships.Queries.GetAllShipsQuery;
using ShipsApi.Application.Products.Queries.GetAllProductsQuery;
using System;
using ShipsApi.Application.Products;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Voyages.Commands.Create;
using FluentValidation;
using ShipsApi.Entities;
using ShipsApi.Application.Voyages.Queries.GetVoyageByIdQuery;
using ShipsApi.Application.Voyages.Commands.Update;
using ShipsApi.Application.Voyages.Commands.Delete;
using Microsoft.EntityFrameworkCore.Internal;

namespace ShipsApi.Controllers
{
    public class HomeController : BaseViewController
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var voyagesQuery = new GetAllVoyagesQuery();
            var voyages = await Mediator.Send(voyagesQuery, cancellationToken);

            var productListQuery = new GetAllProductsQuery();
            var productList = await Mediator.Send(productListQuery, cancellationToken);

            TempData["productList"] = JsonSerializer.Serialize(productList);

            var shipListQuery = new GetAllShipsQuery();
            var shipList = await Mediator.Send(shipListQuery, cancellationToken);

            TempData["shipList"] = JsonSerializer.Serialize(shipList);

            var model = new VoyageListViewModel
            {
                Voyages = voyages,
                ShipList = shipList,
                ProductList = productList,
            };

            return View(model);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var voyage = TempData.ContainsKey("voyage")
                ? JsonSerializer.Deserialize<VoyageVm>(TempData["voyage"] as string)
                : new VoyageVm();

            var productList = TempData.ContainsKey("productList")
                ? JsonSerializer.Deserialize<ProductListVm>(TempData["productList"] as string)
                : new ProductListVm();
            var shipList = TempData.ContainsKey("shipList")
                ? JsonSerializer.Deserialize<ShipListVm>(TempData["shipList"] as string)
                : new ShipListVm();

            if (!productList.Products.Any())
            {
                var productListQuery = new GetAllProductsQuery();
                productList = await Mediator.Send(productListQuery, cancellationToken);
            }

            if (!shipList.Ships.Any())
            {
                var shipListQuery = new GetAllShipsQuery();
                shipList = await Mediator.Send(shipListQuery, cancellationToken);
            }

            return View("VoyageEditor", VoyageViewModelFactory.Create(voyage, productList, shipList));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] VoyageVm voyage, CancellationToken cancellationToken)
        {
            try
            {
                var command = Mapper.Map<CreateVoyageCommand>(voyage);
                var voyageId = await Mediator.Send(command, cancellationToken);
            }
            catch (ValidationException valEx)
            {
                foreach (var item in valEx.Errors)
                {
                    ModelState.AddModelError($"Voyage.{item.PropertyName}", item.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var productListQuery = new GetAllProductsQuery();
            var productList = await Mediator.Send(productListQuery, cancellationToken);

            var shipListQuery = new GetAllShipsQuery();
            var shipList = await Mediator.Send(shipListQuery, cancellationToken);

            return View("VoyageEditor", VoyageViewModelFactory.Create(voyage, productList, shipList));
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var getVoyageQuery = new GetVoyageByIdQuery
            {
                Id = id,
            };

            var voyage = TempData.ContainsKey("voyage")
                ? JsonSerializer.Deserialize<VoyageVm>(TempData["voyage"] as string)
                : await Mediator.Send(getVoyageQuery, cancellationToken);

            var productList = TempData.ContainsKey("productList")
                ? JsonSerializer.Deserialize<ProductListVm>(TempData["productList"] as string)
                : new ProductListVm();
            var shipList = TempData.ContainsKey("shipList")
                ? JsonSerializer.Deserialize<ShipListVm>(TempData["shipList"] as string)
                : new ShipListVm();

            if (!productList.Products.Any())
            {
                var productListQuery = new GetAllProductsQuery();
                productList = await Mediator.Send(productListQuery, cancellationToken);
            }

            if (!shipList.Ships.Any())
            {
                var shipListQuery = new GetAllShipsQuery();
                shipList = await Mediator.Send(shipListQuery, cancellationToken);
            }

            return View("VoyageEditor", VoyageViewModelFactory.Edit(voyage, productList, shipList));
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] VoyageVm voyage, CancellationToken cancellationToken)
        {
            try
            {
                var command = Mapper.Map<UpdateVoyageCommand>(voyage);
                var voyageId = await Mediator.Send(command, cancellationToken);
            }
            catch (ValidationException valEx)
            {
                foreach (var item in valEx.Errors)
                {
                    ModelState.AddModelError($"Voyage.{item.PropertyName}", item.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var productListQuery = new GetAllProductsQuery();
            var productList = await Mediator.Send(productListQuery, cancellationToken);

            var shipListQuery = new GetAllShipsQuery();
            var shipList = await Mediator.Send(shipListQuery, cancellationToken);

            return View("VoyageEditor", VoyageViewModelFactory.Edit(voyage, productList, shipList));
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var query = new GetVoyageByIdQuery
            {
                Id = id
            };
            var voyage = await Mediator.Send(query, cancellationToken);

            var productList = TempData.ContainsKey("productList")
                ? JsonSerializer.Deserialize<ProductListVm>(TempData["productList"] as string)
                : new ProductListVm();
            var shipList = TempData.ContainsKey("shipList")
                ? JsonSerializer.Deserialize<ShipListVm>(TempData["shipList"] as string)
                : new ShipListVm();

            if (!productList.Products.Any())
            {
                var productListQuery = new GetAllProductsQuery();
                productList = await Mediator.Send(productListQuery, cancellationToken);
            }

            if (!shipList.Ships.Any())
            {
                var shipListQuery = new GetAllShipsQuery();
                shipList = await Mediator.Send(shipListQuery, cancellationToken);
            }

            return View("VoyageEditor", VoyageViewModelFactory.Delete(voyage, productList, shipList));
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] VoyageVm voyage, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<DeleteVoyageCommand>(voyage);
                await Mediator.Send(command, cancellationToken);

                return RedirectToAction("Index");
            }

            var productListQuery = new GetAllProductsQuery();
            var productList = await Mediator.Send(productListQuery, cancellationToken);

            var shipListQuery = new GetAllShipsQuery();
            var shipList = await Mediator.Send(shipListQuery, cancellationToken);

            return View("VoyageEditor", VoyageViewModelFactory.Delete(voyage, productList, shipList));
        }
    }
}
