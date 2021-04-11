import React from 'react';

const Mission = () => {
  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100%', width: '100%' }}>
      <div style={{ flex: '5 0 0', display: 'flex' }}>
        <div style={{ backgroundColor: 'red', flex: '4 0 auto' }}>slide show</div>
        <div style={{ backgroundColor: 'blue', flex: '1 0 auto' }}>chat area</div>
      </div>
      <div style={{ backgroundColor: 'green', flex: '1 0 0' }}></div>
    </div>
  );
};

export default Mission;
