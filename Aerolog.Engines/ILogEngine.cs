using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface ILogEngine
    {
        Task<IEnumerable<Log>> GetLogsByMissionId(string missionId);
        Task<IEnumerable<Log>> GetLogsBySeriesId(string seriesId);
        Task<Log> GetLog(string logId);
        Task<IEnumerable<Log>> GetAll();
        Task<long> GetLogCountByMissionId(string missionId);
    }
}
