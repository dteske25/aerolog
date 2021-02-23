using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class LogType: ObjectGraphType<Log>
    {
        public LogType(IMissionEngine missionEngine)
        {
            Name = "Log";
            Description = "Transcribed logs from a mission";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.SpeakerName);
            Field(s => s.Text);
            Field(s => s.Timestamp);
            Field(s => s.UploadStatus).Description("The status of the upload and if it's been reviewed.");

            // Custom-mapped properties
            Field<MissionType>("mission", "The mission during which the log was captured", resolve: c => missionEngine.GetMission(c.Source.MissionId));
        }
    }
}
