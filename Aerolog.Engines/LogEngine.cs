using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public class LogEngine : ILogEngine
    {
        private readonly ILogAccessor _logAccessor;
        public LogEngine(ILogAccessor logAccessor)
        {
            _logAccessor = logAccessor;
        }

        public async Task<IEnumerable<Log>> GetAll()
        {
            return await _logAccessor.GetAll();
        }

        public async Task<Log> GetLog(string logId)
        {
            return await _logAccessor.GetById(logId);
        }

        public async Task<long> GetLogCountByMissionId(string missionId)
        {
            return await _logAccessor.Count(l => l.MissionId == missionId);

        }

        public async Task<IEnumerable<Log>> GetLogsByMissionId(string missionId)
        {
            return await _logAccessor.Get(l => l.MissionId == missionId);
        }

        public async Task<IEnumerable<Log>> GetLogsBySeriesId(string seriesId)
        {
            return await _logAccessor.Get(l => l.SeriesId == seriesId);
        }

        public async Task<Log> Save(Log log)
        {
            return await _logAccessor.Save(log);
        }

        public async Task DeleteAllLogsByMissionId(string missionId)
        {
            await _logAccessor.Delete(l => l.MissionId == missionId);
        }
    }
}
