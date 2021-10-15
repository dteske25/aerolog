using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public class MissionEngine : IMissionEngine
    {

        private readonly IMissionAccessor _missionAccessor;
        public MissionEngine(IMissionAccessor seriesAccessor)
        {
            _missionAccessor = seriesAccessor;
        }

        public async Task<IEnumerable<Mission>> GetMissionsBySeriesId(string seriesId)
        {
            var missions = await _missionAccessor.Get(m => m.SeriesId == seriesId);
            return missions;
        }

        public async Task<Mission> GetMission(string id)
        {
            var mission = await _missionAccessor.GetById(id);
            return mission;
        }

        public async Task<Mission> Create(string missionName, string seriesId, string imagePath)
        {
            return await _missionAccessor.Insert(new Mission
            {
                MissionName = missionName,
                SeriesId = seriesId,
                Image = imagePath
            });
        }

        public async Task<long> GetMissionCountBySeriesId(string seriesId)
        {
            return await _missionAccessor.Count(m => m.SeriesId == seriesId);
        }

        public async Task<IEnumerable<Mission>> GetAll()
        {
            return await _missionAccessor.GetAll();
        }

        public async Task<Mission> GetMissionByName(string missionName)
        {
            var results = await _missionAccessor.Get(m => m.MissionName == missionName);
            return results.FirstOrDefault();
        }

        public async Task<Mission> Save(Mission mission)
        {
            return await _missionAccessor.Save(mission);
        }
    }
}
