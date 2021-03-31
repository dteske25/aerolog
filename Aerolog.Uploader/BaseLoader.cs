using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Engines;

namespace Aerolog.Uploader.SeriesLoader
{
    public static class BaseLoaderHelpers
    {
        public static async Task<Core.Series> GetOrCreateSeries(ISeriesEngine _seriesEngine, string seriesName, string seriesImage)
        {
            var series = await _seriesEngine.GetSeriesByName(seriesName);
            if (series == null)
            {
                Core.File file = null;
                if (!string.IsNullOrWhiteSpace(seriesImage))
                {
                    file = await FileLoader.GetLocalFile(seriesImage);
                }
                series = await _seriesEngine.CreateSeries(seriesName, file);
                Console.WriteLine($"Series Created: {series.SeriesName}-{series.Id}");
            }
            else
            {
                Console.WriteLine($"Series Found: {series.SeriesName}-{series.Id}");
            }
            return series;
        }

        public static async Task<Core.Mission> GetOrCreateMission(IMissionEngine missionEngine, string missionName, string missionImage, string seriesId)
        {
            var mission = await missionEngine.GetMissionByName(missionName);
            if (mission == null)
            {
                Core.File file = null;
                if (!string.IsNullOrWhiteSpace(missionImage))
                {
                    file = await FileLoader.GetLocalFile(missionImage);
                }
                mission = await missionEngine.CreateMission(missionName, seriesId, file);
                Console.WriteLine($"Mission Created: {mission.MissionName}-{mission.Id}");
            }
            else
            {
                Console.WriteLine($"Mission Found: {mission.MissionName}-{mission.Id}");
            }
            return mission;
        }
    }
}
