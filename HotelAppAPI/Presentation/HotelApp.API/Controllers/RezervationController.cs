using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Customer;
using HotelApp.Application.ViewModels.Employee;
using HotelApp.Application.ViewModels.Rezervation;
using HotelApp.Application.ViewModels.Room;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervationController : ControllerBase
    {
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromServices] IRezervationReadRepository repository, int id)
        {
            Rezervation rezervation = await repository.GetByIDAsync(Convert.ToInt32(id));

            return Ok(rezervation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IRezervationReadRepository repository)
        {
            var data = await repository.GetAll().ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IRezervationWriteRepository repository,
            [FromServices] IRoomReadRepository roomRepository,
            [FromServices] ICustomerReadRepository customerRepository, 
            [FromBody] VMAddRezervation model)
        {
            Room room = await roomRepository.GetByIDAsync(model.RoomId);
            Customer customer = await customerRepository.GetByIDAsync(model.CustomerId);

            Rezervation rezervation = new()
            {
                Customer = customer,
                Room = room,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            var res = await repository.AddAsync(rezervation);
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IRezervationWriteRepository writeRepository, [FromServices] IRezervationReadRepository readRepository, [FromServices] IRoomReadRepository roomRepository,
            [FromServices] ICustomerReadRepository customerRepository, [FromBody] VMUpdateRezervation model)
        {
            Rezervation rezervation = await readRepository.GetByIDAsync(model.Id);

            Room room = await roomRepository.GetByIDAsync(model.RoomId);
            Customer customer = await customerRepository.GetByIDAsync(model.CustomerId);

            rezervation.Customer = customer;
            rezervation.Room = room;
            rezervation.Customer = customer;
            rezervation.StartDate = model.StartDate;
            rezervation.EndDate = model.EndDate;


            var res = writeRepository.Update(rezervation);
            await writeRepository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromServices] IRezervationWriteRepository repository, int id)
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
