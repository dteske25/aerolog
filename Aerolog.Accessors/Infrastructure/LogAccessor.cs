using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Core;

namespace Aerolog.Accessors.Infrastructure
{
    public class LogAccessor : BaseMongoAccessor<Log>, ILogAccessor
    {
        public LogAccessor(MongoContext context) : base(context)
        {
        }
    }
}
