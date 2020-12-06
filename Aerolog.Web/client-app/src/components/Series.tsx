import React from 'react';
import { useRouteMatch } from 'react-router';
import { seriesQuery } from '../services/seriesService';
import { useQuery } from '@apollo/client';
import TitleBar from './TitleBar';
import ErrorBoundary from './ErrorBoundary';
import { IMission } from '../types/mission';
import { Grid, Button, useTheme, makeStyles } from '@material-ui/core';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import routes from '../utilities/routes';
import { Link } from 'react-router-dom';

const useStyles = makeStyles((theme) => ({
  headerRow: {
    display: 'flex',
    justifyContent: 'space-between',
  },
  search: {
    flex: '2 0 auto',
  },
  title: {
    flex: '1 0 auto',
  },
  link: {
    textDecoration: 'none',
  },
}));

interface ISeriesUrlProps {
  id: string;
}

interface ISeriesProps {}

const Series = (props: ISeriesProps) => {
  const match = useRouteMatch<ISeriesUrlProps>();
  const { loading, data, error } = useQuery(seriesQuery, { variables: { seriesId: match.params.id } });

  const theme = useTheme();
  const classes = useStyles(theme);

  if (error) {
    throw error.message;
  }

  return (
    <ErrorBoundary message="Error loading series">
      <TitleBar
        title={data?.series?.seriesName}
        searchText={`Search ${data?.series[0].seriesName} Missions`}
        isLoading={loading}
      />

      <Grid container spacing={3}>
        {loading && (
          <>
            <ImageCardSkeleton />
            <ImageCardSkeleton />
            <ImageCardSkeleton />
          </>
        )}
        {data?.series[0].missions?.map((m: IMission) => (
          <ImageCard
            key={m.id}
            file={m.file}
            title={m.missionName}
            actions={
              <Link className={classes.link} to={routes.getMissionDetails(m.id)}>
                <Button size="small" color="primary">
                  View Missions
                </Button>
              </Link>
            }
          />
        ))}
      </Grid>
    </ErrorBoundary>
  );
};

export default Series;
