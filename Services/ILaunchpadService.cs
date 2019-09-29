using GroundControl.Models;
using System.Threading.Tasks;

namespace GroundControl.Services
{
    public interface ILaunchpadService
    {
        Task<LaunchpadModel> getLaunchPadById(string id);
    }
}
