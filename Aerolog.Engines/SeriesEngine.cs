using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public class SeriesEngine : ISeriesEngine
    {
        private readonly ISeriesAccessor _seriesAccessor;
        public SeriesEngine(ISeriesAccessor seriesAccessor)
        {
            _seriesAccessor = seriesAccessor;
        }

        public async Task<Series> CreateSeries(string seriesName, string seriesImage)
        {
            return await _seriesAccessor.Insert(new Series
            {
                SeriesName = seriesName,
                Image = seriesImage
            });
        }

        public async Task<IEnumerable<Series>> GetAll()
        {
            var series = await _seriesAccessor.GetAll();
            return series;
        }

        public async Task<Series> GetSeries(string id)
        {
            var series = await _seriesAccessor.GetById(id);
            return series;
        }

        public async Task<Series> GetSeriesByName(string name)
        {
            var series = await _seriesAccessor.Get(s => s.SeriesName == name);
            return series.FirstOrDefault();
        }
    }
}
