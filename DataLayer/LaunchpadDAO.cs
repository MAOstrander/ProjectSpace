using GroundControl.Models;
using System.Threading.Tasks;

namespace GroundControl.DataLayer
{
    public class LaunchpadDAO :ILaunchpadDAO
    {
        private ILaunchpadRepo _launchpadRepo;
        public LaunchpadDAO(ILaunchpadRepo repo)
        {
            _launchpadRepo = repo;
        }

        public async Task<LaunchpadModel> getLaunchPadById(string id)
        {
            var dataObject = await _launchpadRepo.GetById(id);
            var response = new LaunchpadModel(dataObject.Id, dataObject.Full_name, dataObject.Status);
            return response;
        }
    }
}
