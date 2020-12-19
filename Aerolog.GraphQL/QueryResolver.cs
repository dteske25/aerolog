using System.Collections.Generic;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.GraphQL.Infrastructure;
using GraphQL.Types;

namespace Aerolog.GraphQL
{
    public class QueryResolver : IQueryResolver
    {
        private readonly ISeriesAccessor _seriesAccessor;
        private readonly IMissionAccessor _missionAccessor;
        private readonly ILogAccessor _logAccessor;
        private readonly IEventAccessor _eventAccessor;

        public QueryResolver(ISeriesAccessor seriesAccessor, IMissionAccessor missionAccessor, ILogAccessor logAccessor, IEventAccessor eventAccessor)
        {
            _seriesAccessor = seriesAccessor;
            _missionAccessor = missionAccessor;
            _logAccessor = logAccessor;
            _eventAccessor = eventAccessor;
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
                return await _seriesAccessor.Get(s => s.Id == seriesId);
            }
            return await _seriesAccessor.GetAll();
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
                return await _missionAccessor.Get(m => m.Id == missionId);
            }
            var seriesId = context.GetArgument<string>("seriesId");
            if (seriesId != null)
            {
                return await _missionAccessor.Get(m => m.SeriesId == seriesId);
            }
            return await _missionAccessor.GetAll();
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
                return await _logAccessor.Get(l => l.Id == logId);
            }
            var missionId = context.GetArgument<string>("missionId");
            if (missionId != null)
            {
                return await _logAccessor.Get(l => l.MissionId == missionId);
            }
            var seriesId = context.GetArgument<string>("seriesId");
            if (seriesId != null)
            {
                return await _logAccessor.Get(l => l.SeriesId == seriesId);
            }
            return await _logAccessor.GetAll();
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
                return await _eventAccessor.Get(e => e.Id == eventId);
            }
            var missionId = context.GetArgument<string>("missionId");
            return await _eventAccessor.Get(e => e.MissionId == missionId);
        }
    }
}
