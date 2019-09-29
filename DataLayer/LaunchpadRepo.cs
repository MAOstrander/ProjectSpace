using GroundControl.Models;
using Microsoft.Extensions.Configuration;
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

        public SpaceXApiReturnModel Launchpad { get; private set; }
        public IEnumerable<SpaceXApiReturnModel> AllLaunchPads { get; private set; }
        public bool LaunchpadRetrievalError { get; private set; }
        public LaunchpadRepo(IConfiguration appConfiguration, IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
            _appConfiguration = appConfiguration;
        }

        public async Task<IEnumerable<SpaceXApiReturnModel>> Get()
        {
            var requestUrl = _appConfiguration["API_BASE_URL"];
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                AllLaunchPads = await response.Content
                    .ReadAsAsync<List<SpaceXApiReturnModel>>();
            }
            else
            {
                LaunchpadRetrievalError = true;
                AllLaunchPads = new List<SpaceXApiReturnModel>(); ;
            }


            return AllLaunchPads;

        }

        public async Task<SpaceXApiReturnModel> GetById(string id)
        {
            var requestUrl = _appConfiguration["API_BASE_URL"] + id;
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Launchpad = await response.Content
                    .ReadAsAsync<SpaceXApiReturnModel>();
            }
            else
            {
                LaunchpadRetrievalError = true;
                Launchpad = new SpaceXApiReturnModel();
            }


            return Launchpad;
        }
    }
}
