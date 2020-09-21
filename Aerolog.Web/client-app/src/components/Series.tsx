import React from 'react';
import { useRouteMatch } from 'react-router';

interface ISeriesProps {
  id: string;
}

const Series = () => {
  const match = useRouteMatch();
  console.log(match);
  return <div>Series Individual</div>;
};

export default Series;
