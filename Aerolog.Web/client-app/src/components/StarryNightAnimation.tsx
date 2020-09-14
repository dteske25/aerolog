import React from 'react';
import Particles from 'react-tsparticles';
import 'pathseg';
import { default as StarryNightAnimationParams } from './StarryNight.config.json';

const StarryNightAnimation = () => (
  <div
    style={{
      position: 'absolute',
      top: '0',
      left: '0',
      right: '0',
      bottom: '0',
    }}
  >
    <Particles params={StarryNightAnimationParams} />
  </div>
);
export default StarryNightAnimation;
