using GroundControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroundControl.Services
{
    public class LaunchpadService : ILaunchpadService
    {
        private readonly IHttpClientFactory _clientFactory;
        public LaunchpadModel Launchpad { get; private set; }
        public bool LaunchpadRetrievalError { get; private set; }
        public LaunchpadService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }
        public async Task<LaunchpadModel> getLaunchPadById(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spacexdata.com/v3/launchpads/{id}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Launchpad = await response.Content
                    .ReadAsAsync<LaunchpadModel>();
            }
            else
            {
                LaunchpadRetrievalError = true;
                Launchpad = new LaunchpadModel(id, "name", "status");
            }


            return Launchpad;
        }
    }

}
