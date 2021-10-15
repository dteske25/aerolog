import React from 'react';
import { useRouteMatch } from 'react-router';
import { useQuery } from '@apollo/client';
import TitleBar from './TitleBar';
import ErrorBoundary from './ErrorBoundary';
import { Grid, Button, useTheme, makeStyles } from '@material-ui/core';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import routes from '../utilities/routes';
import { Link } from 'react-router-dom';
import { SeriesByIdDocument, Mission as MissionType } from '../types';

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

const Series = () => {
  const match = useRouteMatch<ISeriesUrlProps>();
  const { loading, data, error } = useQuery(SeriesByIdDocument, {
    variables: { seriesId: match.params.id },
  });

  const theme = useTheme();
  const classes = useStyles(theme);

  if (error) {
    throw error.message;
  }

  const series = data?.series?.[0];
  const missions =
    series?.missions?.filter(
      (m): m is MissionType => m !== null && m !== undefined,
    ) ?? [];

  return (
    <ErrorBoundary message="Error loading series">
      <TitleBar
        title={series?.seriesName}
        searchText={`Search ${series?.seriesName} Missions`}
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
        {missions.map((m) => {
          return (
            <ImageCard
              key={m.id}
              imageUrl={m.image}
              title={m.missionName}
              actions={
                <Link
                  className={classes.link}
                  to={routes.getMissionDetails(m.id)}
                >
                  <Button size="small" color="primary">
                    View Missions
                  </Button>
                </Link>
              }
            />
          );
        })}
      </Grid>
    </ErrorBoundary>
  );
};

export default Series;
