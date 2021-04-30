import React from 'react';
import Particles, { RecursivePartial, IOptions } from 'react-tsparticles';
import 'pathseg';
import { default as StarryNightAnimationParams } from './StarryNight.config.json';

const StarryNightAnimation = () => (
  <Particles
    style={{
      position: 'fixed',
      top: '0',
      left: '0',
      right: '0',
      bottom: '0',
      height: '100%',
      width: '100%',
      zIndex: -1,
    }}
    options={StarryNightAnimationParams as RecursivePartial<IOptions>}
  />
);
export default StarryNightAnimation;
