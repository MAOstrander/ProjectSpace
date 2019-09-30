using GroundControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroundControl.DataLayer
{
    public interface ILaunchpadRepo
    {
        Task<IEnumerable<SpaceXApiReturnModel>> Get();
        Task<SpaceXApiReturnModel> GetById(string id);
    }
}
