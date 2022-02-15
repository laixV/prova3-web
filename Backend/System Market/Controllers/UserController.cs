using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Super_Market.Domain.Models;
using Super_Market.Domain.Services;
using Super_Market.Extensions;
using Super_Market.Resources;
using Super_Market.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Super_Market.Controllers
{
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.ListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userService.FindByIdAsync(id);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> LoginCredentials([FromBody] AuthUserResource resource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorMessages());

                var result = await _userService.FirstOrDefaultAsync(resource.Email, resource.Password);

                if (result == null)
                    return Unauthorized();

                var token = CryptoFunction.GenerateToken(_configuration);
                return Ok(new
                {
                    error = false,
                    result = new
                    {
                        token,
                        user = new { result.Id, result.Email }
                    }
                });

            }
            catch (Exception e)
            {
                var message = $"An error occurred in auth service {e.Message}";
                return BadRequest(new { error = true, result = new { message } });
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveUserResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, AuthUserResource>(result.User);

            return Ok(userResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

    }

   
}
