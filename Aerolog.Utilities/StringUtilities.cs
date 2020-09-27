using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Aerolog.Utilities
{
    public static class StringUtilities
    {
        public static ObjectId ToObjectId(this string str)
        {
            return ObjectId.Parse(str);
        }
    }
}
