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
        private readonly IFileAccessor _fileAccessor;
        public MissionEngine(IMissionAccessor seriesAccessor, IFileAccessor fileAccessor)
        {
            _missionAccessor = seriesAccessor;
            _fileAccessor = fileAccessor;
        }

        public async Task<IEnumerable<Mission>> GetMissionsBySeriesId(string seriesId)
        {
            var missions = await _missionAccessor.Get(m => m.SeriesId == seriesId);
            return await LoadFiles(missions);
        }

        public async Task<Mission> GetMission(string id)
        {
            var mission = await _missionAccessor.GetById(id);
            return await LoadFile(mission);
        }

        public async Task<Mission> Create(string missionName, string seriesId, File file = null)
        {
            File createdFile = null;
            if (file != null)
            {
                createdFile = await _fileAccessor.Insert(file);
            }
            return await _missionAccessor.Insert(new Mission
            {
                MissionName = missionName,
                SeriesId = seriesId,
                File = createdFile,
                FileId = createdFile?.Id
            });
        }

        private async Task<IEnumerable<Mission>> LoadFiles(IEnumerable<Mission> missions)
        {
            return await Task.WhenAll(missions.Select(s => LoadFile(s)));
        }

        private async Task<Mission> LoadFile(Mission mission)
        {
            if (mission.FileId != null)
            {
                mission.File = await _fileAccessor.GetById(mission.FileId);
            }
            return mission;
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
