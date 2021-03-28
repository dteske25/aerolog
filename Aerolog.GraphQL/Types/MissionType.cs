using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using Aerolog.GraphQL.Types;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class MissionType: ObjectGraphType<Mission>
    {
        public MissionType(ISeriesEngine seriesEngine, IFileEngine fileEngine, ILogEngine logEngine)
        {
            Name = "Mission";
            Description = "A set of missions that contributed to a larger objective";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.MissionName).Description("The name of the mission.");

            // Custom-mapped properties
            Field<ListGraphType<SpeakerType>>("speakers", "Speakers whose voice was recorded in logs during this mission.", resolve: c => c.Source.Speakers);
            Field<FileType>("file", "Image associated with the mission.", resolve: c => fileEngine.GetById(c.Source.FileId));
            Field<SeriesType>("series", "The series this mission was a part of.", resolve: c => seriesEngine.GetSeries(c.Source.SeriesId));
            Field<ListGraphType<LogType>>("log", "Logs that were captured as part of this mission.", resolve: c => logEngine.GetLogsByMissionId(c.Source.Id));
            Field<LongGraphType>("logCount", "Number of logs that were captured as part of this mission.", resolve: c => logEngine.GetLogCountByMissionId(c.Source.Id));
        }
    }
}
