using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Accessors;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public class EventEngine : IEventEngine
    {
        private readonly IEventAccessor _eventAccessor;
        public EventEngine(IEventAccessor eventAccessor)
        {
            _eventAccessor = eventAccessor;
        }
        public async Task<Event> GetEvent(string eventId)
        {
            return await _eventAccessor.GetById(eventId);
        }

        public async Task<IEnumerable<Event>> GetEventsByMissionId(string missionId)
        {
            return await _eventAccessor.Get(e => e.MissionId == missionId);
        }
    }
}
