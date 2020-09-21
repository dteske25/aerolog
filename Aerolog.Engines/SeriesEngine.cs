using System;
using System.Collections.Generic;
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
        public async Task<Series> CreateSeries(string seriesName)
        {
            return await _seriesAccessor.Insert(new Series
            {
                SeriesName = seriesName
            });
        }

        public async Task<IEnumerable<Series>> GetAll()
        {
            return await _seriesAccessor.GetAll();
        }

        public async Task<Series> GetSeries(string id)
        {
            return await _seriesAccessor.GetById(id);
        }
    }
}
