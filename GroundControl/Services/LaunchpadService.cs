using GroundControl.DataLayer;
using GroundControl.Models;
using System.Threading.Tasks;

namespace GroundControl.Services
{
    public class LaunchpadService : ILaunchpadService
    {
        private readonly ILaunchpadDAO dao;
        public LaunchpadService(ILaunchpadDAO launchpadDAO)
        {
            dao = launchpadDAO;
        }
        public async Task<LaunchpadModel> getLaunchPadById(string id)
        {
            return await dao.getLaunchPadById(id);
        }
    }

}
