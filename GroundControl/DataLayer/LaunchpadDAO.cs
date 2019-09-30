using GroundControl.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GroundControl.DataLayer
{
    public class LaunchpadDAO :ILaunchpadDAO
    {
        private ILaunchpadRepo _launchpadRepo;
        private ILogger<LaunchpadDAO> _logger;
        public LaunchpadDAO(ILaunchpadRepo repo, ILogger<LaunchpadDAO> logger)
        {
            _launchpadRepo = repo;
            _logger = logger;
        }

        public async Task<LaunchpadModel> getLaunchPadById(string id)
        {
            var dataObject = await _launchpadRepo.GetById(id);
            _logger.LogInformation("LaunchpadDAO getLaunchPadById creating new LaunchpadModel with {Id} {Full_Name} {Status}", dataObject.Id, dataObject.Full_name, dataObject.Status);

            var response = new LaunchpadModel(dataObject.Id, dataObject.Full_name, dataObject.Status);
            return response;
        }

        public async Task<IEnumerable<LaunchpadModel>> getAllLaunchpads(string status, string location)
        {
            var dataObject = await _launchpadRepo.Get();

            if (!string.IsNullOrWhiteSpace(status))
            {
                dataObject = dataObject.Where(x => x.Status == status);
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                dataObject = dataObject.Where(x => x.Full_name.Contains(location));
            }
            var responseObject = new List<LaunchpadModel>();
            foreach (var modelToChange in dataObject)
            {
                var modelItem = new LaunchpadModel(modelToChange.Id, modelToChange.Full_name, modelToChange.Status);
                _logger.LogInformation("LaunchpadDAO getAllLaunchpads creating new LaunchpadModel with {Id} {Full_Name} {Status}", modelToChange.Id, modelToChange.Full_name, modelToChange.Status);
                responseObject.Add(modelItem);
            }


            return responseObject;
        }
    }
}
