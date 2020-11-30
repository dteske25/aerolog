using Aerolog.Accessors;
using Aerolog.Core;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class SeriesType: ObjectGraphType<Series>
    {
        public SeriesType(IMissionAccessor missionAccessor, IFileAccessor fileAccessor)
        {
            Name = "Series";
            Description = "A set of missions that contributed to a larger objective";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.SeriesName).Description("The name of the series.");

            // Custom-mapped properties
            Field<FileType>("file", "Image associated with the series.", resolve: c => fileAccessor.GetById(c.Source.FileId));
            Field<ListGraphType<MissionType>>("missions", "Which missions are part of this series.", resolve: c => missionAccessor.Get(m => m.SeriesId == c.Source.Id));
            Field<IntGraphType>("missionCount", "Number of missions that are part of this series.", resolve: c => missionAccessor.Count(m => m.SeriesId == c.Source.Id));
        }
    }
}
