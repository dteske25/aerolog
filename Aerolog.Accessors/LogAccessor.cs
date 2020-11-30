using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;

namespace Aerolog.Accessors
{
    public class LogAccessor : BaseMongoAccessor<Log>, ILogAccessor
    {
        public LogAccessor(MongoContext context) : base(context)
        {
        }
    }
}
