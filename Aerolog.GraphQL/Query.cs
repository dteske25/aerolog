﻿using Aerolog.GraphQL.QueryTypes;
using GraphQL.Types;

namespace Aerolog.GraphQL
{
    public class Query: ObjectGraphType
    {
        public Query(IQueryResolver queryResolver)
        {
            Name = "Query";
            Field<ListGraphType<SeriesType>>("series", arguments: queryResolver.GetSeries.Args, resolve: queryResolver.GetSeries.Resolve);
            Field<ListGraphType<MissionType>>("mission", arguments: queryResolver.GetMissions.Args, resolve: queryResolver.GetMissions.Resolve);
            Field<ListGraphType<LogType>>("log", arguments: queryResolver.GetLogs.Args, resolve: queryResolver.GetLogs.Resolve);
            // Field<FileQueryType>("file", resolve: context => new { });
        }
    }
}
