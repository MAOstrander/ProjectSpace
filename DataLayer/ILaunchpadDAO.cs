using GroundControl.Models;
using System.Threading.Tasks;

namespace GroundControl.DataLayer
{
    public interface ILaunchpadDAO
    {
        Task<LaunchpadModel> getLaunchPadById(string id);
    }
}
