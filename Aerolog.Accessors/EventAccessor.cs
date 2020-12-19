using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;

namespace Aerolog.Accessors
{
    public class EventAccessor : BaseMongoAccessor<Event>, IEventAccessor
    {
        public EventAccessor(MongoContext context) : base(context)
        {
        }
    }
}
