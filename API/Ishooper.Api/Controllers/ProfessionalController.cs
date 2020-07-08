using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Ishooper.Api.Models;
using Ishooper.Infra;
using Ishooper.Infra.CustomExceptions;
using Ishooper.Infra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ishooper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public ProfessionalController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // POST: api/Profession
        [HttpPost]
        [Route("Search")]
        [ProducesResponseType(typeof(ProfessionalSearchResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Search([FromBody] ProfessionalSearchRequest professionalSearch)
        {
            try
            {
                int maxDistanceKm = int.Parse(_configuration.GetSection("MaxDistanceToSearch").Value);
                var profSrv = new ProfessionalService(_configuration);
                var result = profSrv.Search(professionalSearch.ProfessionId, professionalSearch.Longitude, professionalSearch.Latitude, maxDistanceKm);
                List<ProfessionalSearchResponse> response = new List<ProfessionalSearchResponse>();
                foreach (Infra.Models.Professional prof in result)
                {
                    response.Add(new ProfessionalSearchResponse
                    {
                        Name = prof.Name,
                        ProfessionalId = prof.ProfessionalId,
                        Profession = prof.Profession,
                        Calls = prof.Calls,
                        Photo = prof.Photo,
                        Points = prof.Points,
                        Price = prof.Price
                    });
                }
                return Ok(response);

            }
            catch (UserCustomException e)
            {
                // 422 Unprocessable Entity (WebDAV)
                return StatusCode(422, new UserCustomException(e.Message));
            }
            catch (BadRequestException e)
            {
                return StatusCode(400, new BadRequestError(e.Message));
            }
            catch (UnprocessableException e)
            {
                var logErrorService = new LogErrorService(_configuration);
                logErrorService.Insert(e);
                return StatusCode(422, new UnprocessableEntityError(e.Message, ""));
            }
            catch (Exception e)
            {
                new LogErrorService(_configuration).Insert(e);
                return StatusCode(500, new InternalServerError(e.Message, ""));
            }
        }
    }
}
