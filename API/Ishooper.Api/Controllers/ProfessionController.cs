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
    public class ProfessionController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public ProfessionController(ILogger<UserController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // POST: api/Profession
        [HttpPost]
        [Route("GetAll")]
        [ProducesResponseType(typeof(ProfessionResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var profSrv = new ProfessionService(_configuration);
                var result = profSrv.GetComercialList();
                List<ProfessionResponse> response = new List<ProfessionResponse>();
                foreach (Infra.Models.Profession prof in result)
                    response.Add(new ProfessionResponse
                    {
                        Id = prof.Id,
                        Description = prof.Description,
                        Status = prof.Status,
                        Administrative = prof.Administrative
                    });
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
