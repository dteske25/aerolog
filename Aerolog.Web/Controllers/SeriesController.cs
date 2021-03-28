using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aerolog.Engines;
using Aerolog.Web.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aerolog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesEngine _seriesEngine;
        public SeriesController(ISeriesEngine seriesEngine)
        {
            _seriesEngine = seriesEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var series = await _seriesEngine.GetAll();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeries(string id)
        {
            var series = await _seriesEngine.GetSeries(id);
            return Ok(series);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries([FromForm]CreateSeriesParams seriesParams)
        {
            var requestFile = seriesParams.Files.FirstOrDefault();
            Core.File file = null;
            if (requestFile != null)
            {
                file = new Core.File
                {
                    ContentType = requestFile?.ContentType,
                    FileName = requestFile?.FileName,
                };
                using (var stream = new MemoryStream())
                {
                    await requestFile.OpenReadStream().CopyToAsync(stream);
                    file.FileContent = stream.ToArray();
                }
            }
            
            var series = await _seriesEngine.CreateSeries(seriesParams.SeriesName, file);
            return Ok(series);
        }
    }
}
