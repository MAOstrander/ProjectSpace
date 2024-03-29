﻿using GroundControl.Models;
using GroundControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Health Check to make sure app is running
        /// </summary>
        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogDebug("System is logging as expected");
            return Ok("System Operational");
        }

        /// <summary>
        /// Launchpad info retrieved by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchpadModel>> Get(string id)
        {
            // I went with Serilogs so that I can eventually configure it for cloud-based logging using CloudWatch or some other analog of it
            // but I implemented it with ILogger so that I could swap out the logger for another if needed and to make unit tests easier
            _logger.LogDebug("Launchpad Get called with Id: {Id}", id);

            // call a service with the given ID. This service will return a LaunchpadModel after checking either the api or a future database.
            try
            {
                LaunchpadModel response = await _launchpadService.getLaunchPadById(id);
                _logger.LogDebug("Launchpad Get returned from service with response of: {Response}", response);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError("Launchpad Get encountered an exception: {Ex}", ex);
                return NotFound();
            }

        }


        /// <summary>
        /// Launchpad set returned by criteria
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<List<LaunchpadModel>>> GetAll(string status, string namesearch)
        {
            _logger.LogDebug("Status of launchpads requested was: {Status}", status);
            _logger.LogDebug("Requested name/location contains part of the following phrase: {Namesearch}", namesearch);

            try
            {
                var response = await _launchpadService.getAllLaunchpads(status, namesearch);
                _logger.LogDebug("Launchpad Get returned from service with response of: {Response}", response);
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError("Launchpad Get encountered an exception: {Ex}", ex);
                return NotFound();
            }

        }

    }
}
