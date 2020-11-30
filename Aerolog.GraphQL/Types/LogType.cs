using Aerolog.Accessors;
using Aerolog.Core;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class LogType: ObjectGraphType<Log>
    {
        public LogType(IMissionAccessor missionAccessor)
        {
            Name = "Log";
            Description = "Transcribed logs from a mission";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.SpeakerName);
            Field(s => s.Text);
            Field(s => s.Timestamp);

            // Custom-mapped properties
            Field<MissionType>("mission", "The mission during which the log was captured", resolve: c => missionAccessor.Get(m => m.Id == c.Source.MissionId));
        }
    }
}
