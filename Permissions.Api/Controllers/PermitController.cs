using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Permissions.Domain.Application.Permit.Commands.AddPermit;
using Permissions.Domain.Application.Permit.Commands.UpdatePermit;
using Permissions.Domain.Application.Permit.Queries.GetAllPermit;
using Permissions.Domain.Application.Permit.Queries.GetPermitById;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Api.Controllers
{
    /// <summary>
    /// permit endpoint. 
    /// </summary>
    [Route("api/permit")]
    [ApiController]
    public class PermitController : ControllerBase
    {

        private readonly IMediator mediator;

        public PermitController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }



        /// <summary>
        /// Get Permit By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getbyid/{idPermit}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(int idPermit)
        {
            var query = new GetPermitByIdQuery(idPermit);

            var result = await mediator.Send(query);

            if (result is null)
                return NotFound(new { message = "No se encontraron datos." });

            return Ok(result);
        }

        // <summary>
        /// Get all permit
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getallpermit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllPermit()
        {

            var query = new GetAllPermitQuery();

            var result = await mediator.Send(query);

            if (!result.Any())
                return NotFound(new { message = "No se encontraron datos." });

            return Ok(result);

        }


        /// <summary>
        /// Register Permit.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("registerpermit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterPermit([FromBody] AddPermitCommand command)
        {
            var result = await mediator.Send(command);

            if (result)
                return Ok();

            return StatusCode(result.Code, new
            {
                error = result.FailureReason
            });
        }


        /// <summary>
        /// Update Permit info
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("updateinfopermit")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateInfoPermit([FromBody] UpdatePermitCommand command)
        {
            var result = await mediator.Send(command);

            if (result)
                return Ok();

            return StatusCode(result.Code, new
            {
                error = result.FailureReason
            });
        }

    }
}
