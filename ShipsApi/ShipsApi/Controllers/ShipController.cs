using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Ships.Queries.GetAllShipsQuery;
using ShipsApi.Application.Ships.Queries.GetShipByIdQuery;
using ShipsApi.Application.Ships.Commands.Create;
using ShipsApi.Application.Ships.Commands.Update;
using ShipsApi.Application.Ships.Commands.Delete;
using ShipsApi.Application.Ships;
using ShipsApi.Models;

namespace ShipsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : BaseController
    {
        private readonly IMapper _mapper;

        public ShipController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ShipListVm>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllShipsQuery();
            var model = await Mediator.Send(query, cancellationToken);

            return Ok(model);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ShipVm>> Get(int id, CancellationToken cancellationToken)
        {
            var query = new GetShipByIdQuery
            {
                Id = id
            };
            var model = await Mediator.Send(query, cancellationToken);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateShipDto createShipDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateShipCommand>(createShipDto);
            var orderId = await Mediator.Send(command, cancellationToken);

            return Ok(orderId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateShipDto updateShipDto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateShipCommand>(updateShipDto);
            await Mediator.Send(command, cancellationToken);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteShipCommand
            {
                Id = id
            };
            await Mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
