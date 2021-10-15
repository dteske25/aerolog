import React from 'react';
import { useQuery } from '@apollo/client';
import { Grid, makeStyles, useTheme, Button } from '@material-ui/core';
import TitleBar from './TitleBar';
import { Link } from 'react-router-dom';
import ErrorBoundary from './ErrorBoundary';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import routes from '../utilities/routes';
import { AllSeriesDocument, Series as SeriesType } from '../types';

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

const SeriesList = () => {
  const theme = useTheme();
  const classes = useStyles(theme);
  const { loading, data, error } = useQuery(AllSeriesDocument);

  if (error) {
    throw error.message;
  }

  const series =
    data?.series?.filter(
      (s): s is SeriesType => s !== null && s !== undefined,
    ) ?? [];

  return (
    <ErrorBoundary message="Failed to load Series">
      <TitleBar title="Series" isLoading={loading} />

      <Grid container spacing={3}>
        {loading && (
          <>
            <ImageCardSkeleton />
            <ImageCardSkeleton />
            <ImageCardSkeleton />
          </>
        )}
        {series.map((s) => {
          return (
            <ImageCard
              key={s.id}
              imageUrl={s.image}
              title={s.seriesName}
              actions={
                <Link
                  className={classes.link}
                  to={routes.getSeriesDetails(s.id)}
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

export default SeriesList;
