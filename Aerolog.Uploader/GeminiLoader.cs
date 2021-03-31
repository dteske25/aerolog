using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Core;
using Aerolog.Engines;

namespace Aerolog.Uploader.SeriesLoader
{
    public class GeminiLoader : ILoader
    {
        private readonly ISeriesEngine _seriesEngine;
        private readonly IMissionEngine _missionEngine;
        public GeminiLoader(ISeriesEngine seriesEngine, IMissionEngine missionEngine)
        {
            _seriesEngine = seriesEngine;
            _missionEngine = missionEngine;
        }

        public async Task Populate()
        {
            var series = await BaseLoaderHelpers.GetOrCreateSeries(_seriesEngine, "Gemini", @"R:\Code\aerolog\Data\Gemini\series.jpg");
            var missions = new List<(string, string)>()
            {
                ("Gemini 1", ""),
                ("Gemini 2", ""),
                ("Gemini 3", ""),
                ("Gemini IV", ""),
                ("Gemini V", ""),
                ("Gemini VII", ""),
                ("Gemini VI-A", ""),
                ("Gemini VIII", ""),
                ("Gemini IX-A", ""),
                ("Gemini X", ""),
                ("Gemini XI", ""),
                ("Gemini XII", ""),
            };

            foreach ((var name, var path) in missions)
            {
                await BaseLoaderHelpers.GetOrCreateMission(_missionEngine, name, path, series.Id);
            }
        }
    }
}
