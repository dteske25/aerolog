using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Core;
using Aerolog.Engines;

namespace Aerolog.Uploader.SeriesLoader
{
    public class ApolloLoader : ILoader
    {
        private readonly ISeriesEngine _seriesEngine;
        private readonly IMissionEngine _missionEngine;
        public ApolloLoader(ISeriesEngine seriesEngine, IMissionEngine missionEngine)
        {
            _seriesEngine = seriesEngine;
            _missionEngine = missionEngine;
        }

        public async Task Populate()
        {
            var series = await BaseLoaderHelpers.GetOrCreateSeries(_seriesEngine, "Apollo", @"R:\Code\aerolog\Data\Apollo\series.jpg");
            var missions = new List<(string, string)>()
            {
                ("Apollo 1", @"R:\Code\aerolog\Data\Apollo\apollo1.jpg"),
                ("Apollo 7", @"R:\Code\aerolog\Data\Apollo\apollo7.jpeg"),
                ("Apollo 8", @"R:\Code\aerolog\Data\Apollo\apollo8.jpg"),
                ("Apollo 9", @"R:\Code\aerolog\Data\Apollo\apollo9.jpg"),
                ("Apollo 10", @"R:\Code\aerolog\Data\Apollo\apollo10.jpg"),
                ("Apollo 11", @"R:\Code\aerolog\Data\Apollo\apollo11.jpg"),
                ("Apollo 12", @"R:\Code\aerolog\Data\Apollo\apollo12.jpg"),
                ("Apollo 13", @"R:\Code\aerolog\Data\Apollo\apollo13.jpg"),
                ("Apollo 14", @"R:\Code\aerolog\Data\Apollo\apollo14.jpg"),
                ("Apollo 15", @"R:\Code\aerolog\Data\Apollo\apollo15.jpg"),
                ("Apollo 16", @"R:\Code\aerolog\Data\Apollo\apollo16.jpg"),
                ("Apollo 17", @"R:\Code\aerolog\Data\Apollo\apollo17.jpg"),
            };

            foreach ((var name, var path) in missions)
            {
                await BaseLoaderHelpers.GetOrCreateMission(_missionEngine, name, path, series.Id);
            }

        }
    }
}
