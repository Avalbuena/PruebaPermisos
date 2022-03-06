using MediatR;
using Microsoft.AspNetCore.Mvc;
using Permissions.Domain.Application.PermitType.Queries.GetAllPermitType;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Api.Controllers
{
    /// <summary>
    /// permittypes endpoint. 
    /// </summary>
    [Route("api/permittypes")]
    [ApiController]
    public class PermitTypesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PermitTypesController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }

        /// <summary>
        /// Get all Permit type
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallpermittype")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllPermitTypes()
        {

            var query = new GetAllPermitTypesQuery();

            var result = await mediator.Send(query);

            if (!result.Any())
                return NotFound(new { message = "No se encontraron datos." });

            return Ok(result);

        }
    }
}
