import React from 'react';
import Timeline from './Timeline';

const Mission = () => {
  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100%', width: '100%' }}>
      <div style={{ flex: '5 0 0', display: 'flex' }}>
        <div style={{ backgroundColor: 'red', flex: '4 0 auto' }}>slide show</div>
        <div style={{ backgroundColor: 'blue', flex: '1 0 auto' }}>chat area</div>
      </div>
      <div style={{ backgroundColor: 'green', flex: '1 0 0' }}>
        <Timeline
          events={[
            { text: 'Launch', timestamp: '1969-07-16 08:32:00 AM' },
            { text: 'Translunar Injection', timestamp: '1969-07-16 11:16:16 AM' },
            { text: 'CSM-LM docking', timestamp: '1969-07-16 11:56:03 AM' },
            { text: 'Lunar orbit insertion', timestamp: '1969-07-19 12:21:50 AM' },
            { text: 'CSM-LM separation', timestamp: '1969-07-20 01:11:53 PM' },
            { text: 'Lunar landing', timestamp: '1969-07-20 03:17:40 PM' },
            { text: 'Begin EVA', timestamp: '1969-07-20 09:39:33 PM' },
            { text: 'First step on surface', timestamp: '1969-07-20 09:56:15 PM' },
            { text: 'Lunar liftoff', timestamp: '1969-07-21 12:54:01 PM' },
            { text: 'LM-CSM docking', timestamp: '1969-07-21 04:34:00 PM' },
            { text: 'Transearth injection', timestamp: '1969-07-21 11:54:42 PM' },
            { text: 'Splashdown', timestamp: '1969-07-24 11:50:35 AM' },
          ]}
          value={new Date()}
        />
      </div>
    </div>
  );
};

export default Mission;
