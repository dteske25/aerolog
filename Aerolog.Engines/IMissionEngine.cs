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
        Task<Mission> GetMissionByName(string missionName);
        Task<IEnumerable<Mission>> GetMissionsBySeriesId(string seriesId);
        Task<long> GetMissionCountBySeriesId(string seriesId);
        Task<IEnumerable<Mission>> GetAll();
        Task<Mission> Create(string missionName, string seriesId, File file = null);
        Task<Mission> Save(Mission mission);
    }
}
