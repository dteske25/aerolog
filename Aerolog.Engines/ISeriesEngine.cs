using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface ISeriesEngine
    {
        Task<Series> GetSeries(string id);
        Task<Series> CreateSeries(string seriesName);
        Task<IEnumerable<Series>> GetAll();
    }
}
