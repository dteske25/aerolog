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
        private readonly IFileAccessor _fileAccessor;
        public SeriesEngine(ISeriesAccessor seriesAccessor, IFileAccessor fileAccessor)
        {
            _seriesAccessor = seriesAccessor;
            _fileAccessor = fileAccessor;
        }
        public async Task<Series> CreateSeries(string seriesName, File file = null)
        {
            File createdFile = null;
            if (file != null)
            {
                createdFile = await _fileAccessor.Insert(file);
            }
            return await _seriesAccessor.Insert(new Series
            {
                SeriesName = seriesName,
                File = createdFile,
                FileId = createdFile?.Id
            });
        }

        public async Task<IEnumerable<Series>> GetAll()
        {
            var series = await _seriesAccessor.GetAll();
            return await LoadFiles(series);
        }

        public async Task<Series> GetSeries(string id)
        {
            var series = await _seriesAccessor.GetById(id);
            return await LoadFile(series);
        }

        private async Task<IEnumerable<Series>> LoadFiles(IEnumerable<Series> series)
        {
            return await Task.WhenAll(series.Select(s => LoadFile(s)));
        }

        private async Task<Series> LoadFile(Series series)
        {
            series.File = await _fileAccessor.GetById(series.FileId);
            return series;
        }
    }
}
