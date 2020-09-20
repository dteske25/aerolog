using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;

namespace Aerolog.Accessors
{
    public class SeriesAccessor : BaseMongoAccessor<Series>, ISeriesAccessor
    {
        public SeriesAccessor(MongoContext context) : base(context)
        {
        }
    }
}
