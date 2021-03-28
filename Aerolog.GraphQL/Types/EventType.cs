using System;
using System.Collections.Generic;
using System.Text;
using Aerolog.Accessors;
using Aerolog.Core;
using Aerolog.Engines;
using Aerolog.GraphQL.QueryTypes;
using GraphQL.Types;

namespace Aerolog.GraphQL.Types
{
    public class EventType : ObjectGraphType<Event>
    {

        public EventType(IFileEngine fileEngine, IMissionEngine missionEngine, ISeriesEngine seriesEngine)
        {
            Name = "Event";
            Description = "Major events that occurred during the mission";

            Field(e => e.Id);
            Field(e => e.Text);
            Field(e => e.Timestamp);
            Field<FileType>("file", "Image associated with the series.", resolve: c => fileEngine.GetById(c.Source.FileId));
            Field<MissionType>("mission", "Mission the event occurred on.", resolve: c => missionEngine.GetMission(c.Source.MissionId));
            Field<SeriesType>("series", "Series of missions associated with the event.", resolve: c => seriesEngine.GetSeries(c.Source.SeriesId));
        }
    }
}
