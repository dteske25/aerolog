using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface ISeriesEngine
    {
        Task<Series> GetSeries(string id);
        Task<Series> GetSeriesByName(string name);
        Task<Series> CreateSeries(string seriesName, string seriesImage);
        Task<IEnumerable<Series>> GetAll();
    }
}
