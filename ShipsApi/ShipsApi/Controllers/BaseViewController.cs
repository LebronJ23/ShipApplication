using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShipsApi.Application.Voyages;
using System.Text.Json;

namespace ShipsApi.Controllers
{
    public class BaseViewController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

        protected string Serialize(VoyageVm v) => JsonSerializer.Serialize(v);
        protected VoyageVm Deserialize(string json) => JsonSerializer.Deserialize<VoyageVm>(json);
    }
}
