using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSampleFirst.Application.Methods.TestMethod.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSampleFirst.WebApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TestController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult> TestMethod1()
        {
            return Ok(await Mediator.Send(new TestQuery()));
        }
    }
}
