using HotelApp.Application.Repositories;
using HotelApp.Application.ViewModels.Auth;
using HotelApp.Application.ViewModels.Customer;
using HotelApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IEmployeeReadRepository repository, [FromBody] VMLogin model)
        {
            var users = await repository.GetWhere(user => user.Email == model.Email && user.Password == model.Password).ToListAsync();

            
            if(users.Count == 0)
            {
                return StatusCode(401);
            }
            else
            {
                var user = users.First();
                return Ok(user);
            }

        }

    }
}
