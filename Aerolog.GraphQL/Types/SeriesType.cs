using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class SeriesType: ObjectGraphType<Series>
    {
        public SeriesType(IMissionEngine missionEngine, IFileEngine fileEngine)
        {
            Name = "Series";
            Description = "A set of missions that contributed to a larger objective";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.SeriesName).Description("The name of the series.");
            Field(s => s.UploadStatus).Description("The status of the upload and if it's been reviewed.");

            // Custom-mapped properties
            Field<FileType>("file", "Image associated with the series.", resolve: c => fileEngine.GetById(c.Source.FileId));
            Field<ListGraphType<MissionType>>("missions", "Which missions are part of this series.", resolve: c => missionEngine.GetMissionsBySeriesId(c.Source.Id));
            Field<ObjectGraphType<long>>("missionCount", "Number of missions that are part of this series.", resolve: c => missionEngine.GetMissionCountBySeriesId(c.Source.Id));
        }
    }
}
