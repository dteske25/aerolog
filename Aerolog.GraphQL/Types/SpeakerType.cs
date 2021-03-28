using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Core;
using GraphQL.Types;

namespace Aerolog.GraphQL.Types
{
    public class SpeakerType : ObjectGraphType<Speaker>
    {
        public SpeakerType()
        {
            Name = "Speaker";
            Description = "Person(s) who participated in mission";

            Field(s => s.Name).Description("Name of speaker");
            Field(s => s.Label).Description("Short identifier used for logs");
        }
    }
}
