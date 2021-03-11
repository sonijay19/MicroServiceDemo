using Api.Domain.Dtos.InsertUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.v1.InsertUserDetail
{
    [ApiController]
    [Route("api/v1/InsertUserDetail")]
    public class InsertUserDetailController : Controller
    {
        private readonly IMediator _mediator;
        public InsertUserDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut]
        public async Task<IActionResult> Index(InsertUserRequest user)
        {
            var abc = await _mediator.Send(user);
            if (abc)
            {
                return StatusCode(200);
            }
            return StatusCode(400);
        }
    }
}
