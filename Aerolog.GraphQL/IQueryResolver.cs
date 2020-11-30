using Aerolog.GraphQL.Infrastructure;

namespace Aerolog.GraphQL
{
    public interface IQueryResolver
    {

        QueryResolverArguments GetSeries { get; }
        QueryResolverArguments GetMissions { get; }
        QueryResolverArguments GetLogs { get; }
    }
}
