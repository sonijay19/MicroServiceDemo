using Api.Domain.Dtos.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1.GetUserDetails
{
    [ApiController]
    [Route("api/v1/GetUserDetails")]
    public class GetUserDetailsController : Controller
    {
        private readonly IMediator _mediator;
        public GetUserDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GetUserDetailsRequest user)
        {
            var result = await _mediator.Send(user);
            if (result is null)
            {
                return StatusCode(400);
            }
            return Ok(result);
        }
    }
}
