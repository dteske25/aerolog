using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using Aerolog.GraphQL.Infrastructure;
using GraphQL.Types;

namespace Aerolog.GraphQL
{
    public class QueryResolver : IQueryResolver
    {
        private readonly ISeriesEngine _seriesEngine;
        private readonly IMissionEngine _missionEngine;
        private readonly ILogEngine _logEngine;
        private readonly IEventEngine _eventEngine;

        public QueryResolver(ISeriesEngine seriesEngine, IMissionEngine missionEngine, ILogEngine logEngine, IEventEngine eventEngine)
        {
            _seriesEngine = seriesEngine;
            _missionEngine = missionEngine;
            _logEngine = logEngine;
            _eventEngine = eventEngine;
        }

        public QueryResolverArguments GetSeries => new QueryResolverArguments
        {
            Args = new QueryArguments(new QueryArgument<StringGraphType> { Name = "seriesId" }),
            Resolve = GetSeriesFunc
        };

        private async Task<IEnumerable<Series>> GetSeriesFunc(ResolveFieldContext<object> context)
        {
            var seriesId = context.GetArgument<string>("seriesId");

            if (seriesId != null)
            {
                var series = await _seriesEngine.GetSeries(seriesId);
                return new List<Series> { series };
            }
            return await _seriesEngine.GetAll();
        }

        public QueryResolverArguments GetMissions => new QueryResolverArguments
        {
            Args = new QueryArguments(new QueryArgument<StringGraphType> { Name = "missionId" }, new QueryArgument<StringGraphType> { Name = "seriesId" }),
            Resolve = GetMissionFunc
        };

        private async Task<IEnumerable<Mission>> GetMissionFunc(ResolveFieldContext<object> context)
        {
            var missionId = context.GetArgument<string>("missionId");
            if (missionId != null)
            {
                var mission = await _missionEngine.GetMission(missionId);
                return new List<Mission> { mission };
            }
            var seriesId = context.GetArgument<string>("seriesId");
            if (seriesId != null)
            {
                return await _missionEngine.GetMissionsBySeriesId(seriesId);
            }
            return await _missionEngine.GetAll();
        }

        public QueryResolverArguments GetLogs => new QueryResolverArguments
        {
            Args = new QueryArguments(new QueryArgument<StringGraphType> { Name = "logId" }, new QueryArgument<StringGraphType> { Name = "missionId" }, new QueryArgument<StringGraphType> { Name = "seriesId" }),
            Resolve = GetLogFunc
        };

        private async Task<IEnumerable<Log>> GetLogFunc(ResolveFieldContext<object> context)
        {
            var logId = context.GetArgument<string>("logId");
            if (logId != null)
            {
                var log = await _logEngine.GetLog(logId);
                return new List<Log> { log };
            }
            var missionId = context.GetArgument<string>("missionId");
            if (missionId != null)
            {
                return await _logEngine.GetLogsByMissionId(missionId);
            }
            var seriesId = context.GetArgument<string>("seriesId");
            if (seriesId != null)
            {
                return await _logEngine.GetLogsBySeriesId(seriesId);
            }
            return await _logEngine.GetAll();
        }

        public QueryResolverArguments GetEvents => new QueryResolverArguments
        {
            Args = new QueryArguments(new QueryArgument<StringGraphType> { Name = "eventId" }, new QueryArgument<StringGraphType> { Name = "missionId" }),
            Resolve = GetEventFunc
        };

        private async Task<IEnumerable<Event>> GetEventFunc(ResolveFieldContext<object> context)
        {
            var eventId = context.GetArgument<string>("eventId");
            if (eventId != null)
            {
                var @event = await _eventEngine.GetEvent(eventId);
                return new List<Event> { @event };
            }
            var missionId = context.GetArgument<string>("missionId");
            return await _eventEngine.GetEventsByMissionId(missionId);
        }
    }
}
