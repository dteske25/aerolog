using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Core;
using Nest;

namespace Aerolog.Engines
{
    public interface IMissionEngine
    {
        Task<Mission> GetMission(string id);
        Task<IEnumerable<Mission>> GetMissionsBySeriesId(string seriesId);
        Task<Mission> CreateMission(string missionName, string seriesId, File file = null);
    }
}
