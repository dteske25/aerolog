using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;

namespace Aerolog.Accessors
{
    public class MissionAccessor : BaseMongoAccessor<Mission>, IMissionAccessor
    {
        public MissionAccessor(MongoContext context) : base(context)
        {
        }
    }
}
