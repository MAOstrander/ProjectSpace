using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroundControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroundControl.Controllers
{
    [Route("api/launchpad")]
    [ApiController]
    public class LaunchpadController : ControllerBase
    {
        // GET Health Check to make sure app is running
        [HttpGet]
        public ActionResult<string> Get()
        {

            return Ok("System Operational");
        }

        // GET Launchpad info retrieved by Id
        [HttpGet("{id}")]
        public ActionResult<LaunchpadModel> Get(string id)
        {
            // call a service with the given ID. This service will return a LaunchpadModel after checking either the api or a future database.

            LaunchpadModel response = new LaunchpadModel(id, "test", "nominal");
            return response;
        }

    }
}
