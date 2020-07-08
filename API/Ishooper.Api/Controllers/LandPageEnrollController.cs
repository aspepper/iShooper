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
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Web;


namespace Ishooper.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LandPageEnrollController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public LandPageEnrollController(ILogger<UserController> logger, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _logger = logger;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(LandPageEnrollResponse), (int)HttpStatusCode.OK)] // 200
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)] //400
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)] // 500
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.UnprocessableEntity)] // 422
        public IActionResult AddEnroll([FromBody] LandPageEnrollRequest record)
        {
            try
            {
                var enrollSrv = new LandPage_EnrollService(_configuration);
                var result = new LandPageEnrollResponse
                {
                    Id = enrollSrv.Insert(new LandPage_Enroll()
                    {
                        Name = record.Name,
                        Email = record.Email,
                        Telephone = record.Telephone,
                        Occupation = record.Occupation
                    })
                };
                return Ok(result);
            }
            catch (BadRequestException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new BadRequestError(e.Message));
            }
            catch (UnprocessableException e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new UnprocessableEntityError(e.Message, record.Email));
            }
            catch (Exception e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, new InternalServerError(e.Message, record.Email));
            }
        }


        [HttpPost]
        [ActionName("Complex")]
        public HttpResponseMessage AddFormEnroll(LandPageEnrollRequestHttpForm record)
        {

            if (ModelState.IsValid && record != null)
            {
                var enrollSrv = new LandPage_EnrollService(_configuration);
                var result = new LandPageEnrollResponse
                {
                    Id = enrollSrv.Insert(new LandPage_Enroll()
                    {
                        Name = HttpUtility.HtmlEncode(record.LandPageName),
                        Email = HttpUtility.HtmlEncode(record.LandPageEmail),
                        Telephone = HttpUtility.HtmlEncode(record.LandPageTelephone),
                        Occupation = record.LandPageOccupation
                    })
                };

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(result.Id)
                };

                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { action = "status", id = response.IsSuccessStatusCode }));

                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
