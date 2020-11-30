using System;
using GraphQL.Types;

namespace Aerolog.GraphQL.Infrastructure
{
    public class QueryResolverArguments<T, V>
    {
        public QueryArguments Args { get; set; }
        public Func<ResolveFieldContext<T>, V> Resolve { get; set; }
    }

    public class QueryResolverArguments<T> : QueryResolverArguments<object, T> { };
    public class QueryResolverArguments : QueryResolverArguments<object, object> { };
}
