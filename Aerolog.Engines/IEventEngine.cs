using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aerolog.Core;

namespace Aerolog.Engines
{
    public interface IEventEngine
    {
        Task<Event> GetEvent(string eventId);
        Task<IEnumerable<Event>> GetEventsByMissionId(string missionId);
    }
}
