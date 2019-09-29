using GroundControl.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroundControl.DataLayer
{
    public class LaunchpadRepo :ILaunchpadRepo
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _appConfiguration;
        private readonly ILogger<LaunchpadRepo> _logger;

        public SpaceXApiReturnModel Launchpad { get; private set; }
        public IEnumerable<SpaceXApiReturnModel> AllLaunchPads { get; private set; }
        public bool LaunchpadRetrievalError { get; private set; }
        public LaunchpadRepo(IConfiguration appConfiguration, ILogger<LaunchpadRepo> logger, IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _appConfiguration = appConfiguration;
            _logger = logger;
        }

        public async Task<IEnumerable<SpaceXApiReturnModel>> Get()
        {
            var requestUrl = _appConfiguration["API_BASE_URL"];
            _logger.LogInformation("LaunchpadRepo Get requestUrl={RequestUrl}", requestUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("LaunchpadRepo GetById apicall succeeded");
                AllLaunchPads = await response.Content
                    .ReadAsAsync<List<SpaceXApiReturnModel>>();
            }
            else
            {
                _logger.LogInformation("LaunchpadRepo GetById apicall failed");
                LaunchpadRetrievalError = true;
                AllLaunchPads = new List<SpaceXApiReturnModel>(); ;
            }


            return AllLaunchPads;

        }

        public async Task<SpaceXApiReturnModel> GetById(string id)
        {
            var requestUrl = _appConfiguration["API_BASE_URL"] + id;
            _logger.LogInformation("LaunchpadRepo GetById requestUrl={RequestUrl}", requestUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("LaunchpadRepo GetById apicall succeeded");
                Launchpad = await response.Content
                    .ReadAsAsync<SpaceXApiReturnModel>();
            }
            else
            {
                _logger.LogInformation("LaunchpadRepo GetById apicall failed");
                LaunchpadRetrievalError = true;
                Launchpad = new SpaceXApiReturnModel();
            }


            return Launchpad;
        }
    }
}
