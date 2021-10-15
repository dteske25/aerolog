using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using GraphQL.Types;

namespace Aerolog.GraphQL.QueryTypes
{
    public class SeriesType: ObjectGraphType<Series>
    {
        public SeriesType(IMissionEngine missionEngine)
        {
            Name = "Series";
            Description = "A set of missions that contributed to a larger objective";

            // Auto-mapped properties
            Field(s => s.Id);
            Field(s => s.SeriesName).Description("The name of the series.");
            Field(s => s.Image).Description("Image associated with the mission.");

            // Custom-mapped properties
            Field<ListGraphType<MissionType>>("missions", "Which missions are part of this series.", resolve: c => missionEngine.GetMissionsBySeriesId(c.Source.Id));
            Field<LongGraphType>("missionCount", "Number of missions that are part of this series.", resolve: c => missionEngine.GetMissionCountBySeriesId(c.Source.Id));
        }
    }
}
