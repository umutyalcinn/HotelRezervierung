using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Customer;
using HotelApp.Domain.Entities;
using HotelApp.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CustomerController : Controller
    {
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromServices] ICustomerReadRepository repository, int id)
        {
            Customer customer = await repository.GetByIDAsync(Convert.ToInt32(id));

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] ICustomerReadRepository repository)
        {
            var data = await repository.GetAll().ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] ICustomerWriteRepository repository, [FromBody] VMAddCustomer model)
        {
            Customer customer = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
            };

            var res = await repository.AddAsync(customer);
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] ICustomerWriteRepository writeRepository, [FromServices] ICustomerReadRepository readRepository, [FromBody] VMUpdateCustomer model)
        {


            Customer customer = await readRepository.GetByIDAsync(model.Id);

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.BirthDate = model.BirthDate;
            customer.Email = model.Email;
            customer.Phone = model.Phone;
            customer.Password = model.Password;

            var res = writeRepository.Update(customer);
            await writeRepository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromServices] ICustomerWriteRepository repository, int id)
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
