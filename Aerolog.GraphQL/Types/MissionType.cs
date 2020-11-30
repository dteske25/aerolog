using Aerolog.Accessors;
using Aerolog.Core;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class MissionType: ObjectGraphType<Mission>
    {
        public MissionType(ISeriesAccessor seriesAccessor, IFileAccessor fileAccessor, ILogAccessor logAccessor)
        {
            Name = "Mission";
            Description = "A set of missions that contributed to a larger objective";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.MissionName).Description("The name of the mission.");

            // Custom-mapped properties
            Field<FileType>("file", "Image associated with the mission.", resolve: c => fileAccessor.GetById(c.Source.FileId));
            Field<SeriesType>("series", "The series this mission was a part of.", resolve: c => seriesAccessor.GetById(c.Source.SeriesId));
            Field<ListGraphType<LogType>>("log", "Logs that were captured as part of this mission.", resolve: c => logAccessor.Get(l => l.MissionId == c.Source.Id));
            Field<IntGraphType>("logCount", "Number of logs that were captured as part of this mission.", resolve: c => logAccessor.Count(l => l.MissionId == c.Source.Id));
        }
    }
}
