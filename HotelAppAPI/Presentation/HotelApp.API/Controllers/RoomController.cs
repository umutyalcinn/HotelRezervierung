using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Customer;
using HotelApp.Application.ViewModels.Employee;
using HotelApp.Application.ViewModels.Room;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromServices] IRoomReadRepository repository, int id)
        {
            Room room = await repository.GetByIDAsync(Convert.ToInt32(id));

            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IRoomReadRepository repository)
        {
            var data = await repository.GetAll().ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IRoomWriteRepository repository, [FromServices] IFloorReadRepository floorRepository, [FromBody] VMAddRoom model)
        {
            Floor floor = await floorRepository.GetByIDAsync(model.FloorId);

            Room room = new()
            {
                RoomName = model.RoomName,
                RoomNumber = model.RoomNumber,
                Capacity = model.Capacity,
                Price = model.Price,
                Floor = floor
            };

            var res = await repository.AddAsync(room);
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IRoomWriteRepository writeRepository, [FromServices] IRoomReadRepository readRepository, [FromServices] IFloorReadRepository floorRepository, [FromBody] VMUpdateRoom model)
        {
            Room room = await readRepository.GetByIDAsync(model.Id);
            Floor floor = await floorRepository.GetByIDAsync(model.FloorId);

            room.RoomNumber = model.RoomNumber;
            room.RoomName = model.RoomName;
            room.Floor = floor;
            room.Price = model.Price;
            room.Capacity = model.Capacity;


            var res = writeRepository.Update(room);
            await writeRepository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromServices] IRoomWriteRepository repository, int id)
        {
            bool res = await repository.RemoveAsync(Convert.ToInt32(id));
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
