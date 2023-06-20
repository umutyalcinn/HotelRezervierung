using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Customer;
using HotelApp.Application.ViewModels.Floor;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromServices] IFloorReadRepository repository, int id)
        {
            Floor floor = await repository.GetByIDAsync(Convert.ToInt32(id));

            return Ok(floor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IFloorReadRepository repository)
        {
            var data = await repository.GetAll().ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IFloorWriteRepository repository, [FromBody] VMAddFloor model)
        {
            Floor floor = new()
            {
                FloorName = model.FloorName,
                FloorNumber = model.FloorNumber,
            };

            var res = await repository.AddAsync(floor);
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IFloorWriteRepository writeRepository, [FromServices] IFloorReadRepository readRepository, [FromBody] VMUpdateFloor model)
        {


            Floor floor = await readRepository.GetByIDAsync(model.Id);

            floor.FloorNumber = model.FloorNumber;
            floor.FloorName = model.FloorName;


            var res = writeRepository.Update(floor);
            await writeRepository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromServices] IFloorWriteRepository repository, int id)
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

