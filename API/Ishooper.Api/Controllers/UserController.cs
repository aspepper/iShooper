using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Ishooper.Api.Models;
using Ishooper.Infra;
using Ishooper.Infra.CustomExceptions;
using Ishooper.Infra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Ishooper.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _logger = logger;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public async Task<IActionResult> AddUser([FromBody] UserRequest user)
        {
            try
            {
                var userSrv = new UserService(_configuration);
                var result = new UserResponse
                {
                    Id = userSrv.Insert(FillUserModel(user))
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

        [HttpPost]
        [Route("Modify")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public async Task<IActionResult> ModifyUser([FromBody] UserRequest user)
        {
            try
            {
                if (user == null) { throw new ArgumentNullException(null); }

                var userSrv = new UserService(_configuration);
                var result = new UserResponse
                {
                    Id = userSrv.Update(user.Id, FillUserModel(user))
                };
                return Ok(result);
            }
            catch (ArgumentNullException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(e.Message));
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
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new UnprocessableEntityError(e.Message));
            }
            catch (Exception e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(e.Message));
            }
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public async Task<IActionResult> Login([FromBody] LoginRequest user)
        {
            try
            {
                var profSrv = new ProfessionService(_configuration);
                var userSrv = new UserService(_configuration);
                var listUserData = userSrv.SelectAny("************", user.Login, "***********");
                var userData = new UserData();
                if (listUserData.Count > 0)
                {
                    userData.Id = listUserData[0].Id;
                    userData.Name = listUserData[0].Name;
                    userData.UserLogon = listUserData[0].UserLogon;
                    userData.Password = listUserData[0].Password;
                    userData.Email = listUserData[0].Email;
                    userData.Telephone = listUserData[0].Telephone;
                    userData.Gender = listUserData[0].Gender;
                    userData.Occupation = listUserData[0].Occupation.Id;
                    userData.Profile = listUserData[0].Profile;
                    userData.URLPhoto = listUserData[0].UrlPhoto;
                    userData.IsDeleted = listUserData[0].IsDeleted;
                    userData.CreatedDate = listUserData[0].CreatedDate;
                    userData.ModifiedDate = listUserData[0].ModifiedDate;
                    userData.DeletedDate = listUserData[0].DeletedDate;

                    var result = new LoginResponse
                    {

                        Status = userSrv.Login(user.Login, user.Password) ? "Success" : "Denied",
                        User = userData
                    };

                    return Ok(result);
                }

                throw new Exception("Usuário não encontrado.");

            }
            catch (BadRequestException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BadRequestError(e.Message));
            }
            catch (UnprocessableException e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new UnprocessableEntityError(e.Message, user.Login));
            }
            catch (Exception e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(e.Message, user.Login));
            }
        }

        //public class FIleUploadAPI
        //{
        //    public IFormFile Files { get; set; }
        //}

        [HttpPost]
        [Route("UploadPhoto")]
        public async Task<string> UploadPhoto()
        {

            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                try
                {
                    if (string.IsNullOrEmpty(_environment.WebRootPath))
                    {
                        _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    }

                    string photoFolder = _configuration.GetSection("PhotoFolder").Value;

                    var file = files[0];

                    string filename = "photo_" + Guid.NewGuid().ToString() + "." + Path.GetExtension(file.FileName);
                    if (!Directory.Exists(Path.Combine(_environment.WebRootPath, photoFolder)))
                    {
                        Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, photoFolder));
                    }
                    using FileStream filestream = System.IO.File.Create(Path.Combine(_environment.WebRootPath, photoFolder, filename));
                    file.CopyTo(filestream);
                    filestream.Flush();

                    return string.Concat("/", photoFolder, "/", filename);
                }
                catch (Exception ex)
                {
                    var logErrorService = new LogErrorService(_configuration);
                    logErrorService.Insert(ex);
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }

        private User FillUserModel(UserRequest user)
        {
            var profSrv = new ProfessionService(_configuration);
            return new User
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
            };
        }

    }
}
