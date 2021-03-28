using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface ISeriesEngine
    {
        Task<Series> GetSeries(string id);
        Task<Series> GetSeriesByName(string name);
        Task<Series> CreateSeries(string seriesName, File file = null);
        Task<IEnumerable<Series>> GetAll();
    }
}
