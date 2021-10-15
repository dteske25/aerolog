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
    }
}
