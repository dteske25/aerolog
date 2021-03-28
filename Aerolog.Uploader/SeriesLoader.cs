using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Engines;

namespace Aerolog.Uploader.SeriesLoader
{

    public interface ISeriesLoader
    {
        Task<Core.Series> GetOrCreateSeries();
    }

    public abstract class BaseSeriesLoader: ISeriesLoader
    {
        private readonly ISeriesEngine _seriesEngine;
        public BaseSeriesLoader(ISeriesEngine seriesEngine)
        {
            _seriesEngine = seriesEngine;
        }

        protected abstract string SeriesName { get; }
        protected abstract string SeriesImage { get; }

        public async Task<Core.Series> GetOrCreateSeries()
        {

            var series = await _seriesEngine.GetSeriesByName(SeriesName);
            if (series == null)
            {
                Core.File file = null;
                if (!string.IsNullOrWhiteSpace(SeriesImage))
                {
                    file = await FileLoader.GetLocalFile(SeriesImage);
                }
                series = await _seriesEngine.CreateSeries(SeriesName, file);
            }
            return series;
        }
    }

    public class ApolloLoader : BaseSeriesLoader, ISeriesLoader
    {
        public ApolloLoader(ISeriesEngine seriesEngine) : base(seriesEngine)
        {
        }

        protected override string SeriesName => "Apollo";
        protected override string SeriesImage => @"R:\Code\aerolog\Data\Apollo\series.jpg";
    }

    public class GeminiLoader : BaseSeriesLoader, ISeriesLoader
    {
        public GeminiLoader(ISeriesEngine seriesEngine) : base(seriesEngine)
        {
        }

        protected override string SeriesName => "Gemini";
        protected override string SeriesImage => @"R:\Code\aerolog\Data\Gemini\series.jpg";
    }
}
