using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Core;

namespace Aerolog.Accessors.Infrastructure
{
    public class MissionAccessor : BaseMongoAccessor<Mission>, IMissionAccessor
    {
        public MissionAccessor(MongoContext context) : base(context)
        {
        }
    }
}
