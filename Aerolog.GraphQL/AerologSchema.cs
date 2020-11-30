using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Aerolog.GraphQL
{
    public class AerologSchema : Schema
    {
        public AerologSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<Query>();
            // Mutation = resolver.Resolve<Mutation>();
        }
    }
}
