using System;
using System.Net;
using System.Threading.Tasks;
using Ishooper.Api.Models;
using Ishooper.Infra;
using Ishooper.Infra.CustomExceptions;
using Ishooper.Infra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ishooper.com.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private UserService _user;

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _user = new UserService(_configuration);
        }

        [HttpGet]
        [Route("Login")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public ActionResult<bool> Login([FromQuery] string user, [FromQuery] string password)
        {
            _logger.Log(LogLevel.Information, "Login", new string[] { user, password });
            return _user.Login(user, password);
        }

        [HttpPost]
        [Route("Enrollment")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public IActionResult Enrollment([FromBody] UserRequest user)
        {
            try
            {
                var userSrv = new UserService(_configuration);
                var profSrv = new ProfessionService(_configuration);
                var result = new UserResponse
                {
                    Id = userSrv.Insert(new User
                    {
                        Name = user.Name,
                        Email = user.Email,
                        UserLogon = user.Logon,
                        Password = user.Password,
                        Gender = user.Gender,
                        Telephone = user.Telephone,
                        Profile = user.Profile,
                        Occupation = profSrv.Select(user.Occupation),
                        UrlPhoto = user.UrlPhoto
                    })
                };
                return Ok(result);
            }
            catch (UserCustomException e)
            {
                // 422 Unprocessable Entity (WebDAV)
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new UserCustomException(e.Message));
            }
            catch (BadRequestException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BadRequestError(e.Message));
            }
            catch (UnprocessableException e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new UnprocessableEntityError(e.Message, user.Logon));
            }
            catch (Exception e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(e.Message, user.Logon));
            }


        }


    }
}