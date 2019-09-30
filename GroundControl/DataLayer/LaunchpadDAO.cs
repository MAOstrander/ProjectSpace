using GroundControl.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
    }
}
