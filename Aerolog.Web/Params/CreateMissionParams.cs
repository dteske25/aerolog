using Microsoft.AspNetCore.Http;

namespace Aerolog.Web.Params
{
    public class CreateMissionParams
    {
        public string MissionName { get; set; }
        public string SeriesId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
