using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Employee;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromServices] IEmployeeReadRepository repository, int id)
        {
            Employee customer = await repository.GetByIDAsync(Convert.ToInt32(id));

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IEmployeeReadRepository repository)
        {
            var data = await repository.GetAll().ToListAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IEmployeeWriteRepository repository, [FromBody] VMAddEmployee model)
        {
            Employee employee = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
            };

            var res = await repository.AddAsync(employee);
            await repository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IEmployeeWriteRepository writeRepository, [FromServices] IEmployeeReadRepository readRepository, [FromBody] VMUpdateEmployee model)
        {


            Employee employee = await readRepository.GetByIDAsync(model.Id);

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.BirthDate = model.BirthDate;
            employee.Email = model.Email;
            employee.Phone = model.Phone;
            employee.Password = model.Password;

            var res = writeRepository.Update(employee);
            await writeRepository.SaveAsync();
            if (res)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromServices] IEmployeeWriteRepository repository, int id)
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
