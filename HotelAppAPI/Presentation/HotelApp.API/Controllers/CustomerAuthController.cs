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
    public class CustomerAuthController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] ICustomerReadRepository repository, [FromBody] VMLogin model)
        {
            var users = await repository.GetWhere(user => user.Email == model.Email && user.Password == model.Password).ToListAsync();

            
            if(users.Count == 0)
            {
                return StatusCode(500);
            }
            else
            {
                var user = users.First();
                return Ok(user);
            }

        }

    }
}
