using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
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
            Field(s => s.Speakers).Description("The speakers at each position identified");
            Field(s => s.UploadStatus).Description("The status of the upload and if it's been reviewed.");

            // Custom-mapped properties
            Field<FileType>("file", "Image associated with the mission.", resolve: c => fileEngine.GetById(c.Source.FileId));
            Field<SeriesType>("series", "The series this mission was a part of.", resolve: c => seriesEngine.GetSeries(c.Source.SeriesId));
            Field<ListGraphType<LogType>>("log", "Logs that were captured as part of this mission.", resolve: c => logEngine.GetLogsByMissionId(c.Source.Id));
            Field<ObjectGraphType<long>>("logCount", "Number of logs that were captured as part of this mission.", resolve: c => logEngine.GetLogCountByMissionId(c.Source.Id));
        }
    }
}
