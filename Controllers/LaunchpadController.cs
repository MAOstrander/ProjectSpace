using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroundControl.Models;
using GroundControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GroundControl.Controllers
{
    [Route("api/launchpad")]
    [ApiController]
    public class LaunchpadController : ControllerBase
    {
        private ILaunchpadService _launchpadService;
        private ILogger<LaunchpadController> _logger;
        public LaunchpadController(ILaunchpadService launchpadService, ILogger<LaunchpadController> logger)
        {
            _launchpadService = launchpadService;
            _logger = logger;
        }

        // GET Health Check to make sure app is running
        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogDebug("System is logging as expected");
            return Ok("System Operational");
        }

        // GET Launchpad info retrieved by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchpadModel>> Get(string id)
        {
            // I want to use a logging service so that the logging can eventually be swapped out for cloudbased logging
            // loggingService.log("");
            // call a service with the given ID. This service will return a LaunchpadModel after checking either the api or a future database.
            try
            {
                LaunchpadModel response = await _launchpadService.getLaunchPadById(id);
                return Ok(response);

            }
            catch (Exception)
            {
                return NotFound();
            }

        }

    }
}
