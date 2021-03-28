using System;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace Aerolog.GraphQL
{
    public class AerologSchema : Schema
    {
        public AerologSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = resolver.GetRequiredService<Query>();
            // Mutation = resolver.Resolve<Mutation>();
        }
    }
}
