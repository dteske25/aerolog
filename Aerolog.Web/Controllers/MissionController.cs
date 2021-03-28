using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aerolog.Engines;
using Aerolog.Web.Params;
using Microsoft.AspNetCore.Mvc;

namespace Aerolog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionEngine _missionEngine;
        public MissionController(IMissionEngine seriesEngine)
        {
            _missionEngine = seriesEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetMissions(string seriesId)
        {
            var missions = await _missionEngine.GetMissionsBySeriesId(seriesId);
            return Ok(missions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMission(string id)
        {
            var mission = await _missionEngine.GetMission(id);
            return Ok(mission);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMission([FromForm] CreateMissionParams missionParams)
        {
            var requestFile = missionParams.Files.FirstOrDefault();
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

            var mission = await _missionEngine.CreateMission(missionParams.MissionName, missionParams.SeriesId, file);
            return Ok(mission);
        }
    }
}
