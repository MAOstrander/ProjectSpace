using GroundControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroundControl.Services
{
    public interface ILaunchpadService
    {
        Task<LaunchpadModel> getLaunchPadById(string id);
        Task<IEnumerable<LaunchpadModel>> getAllLaunchpads(string status, string location);
    }
}
