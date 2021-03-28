import React from 'react';
import { useQuery } from '@apollo/client';
import { allSeriesQuery } from '../services/seriesService';
import { Grid, makeStyles, useTheme, Button } from '@material-ui/core';
import TitleBar from './TitleBar';
import { Link } from 'react-router-dom';
import ErrorBoundary from './ErrorBoundary';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import { ISeries } from '../types/series';
import routes from '../utilities/routes';

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

interface ISeriesList {}

const SeriesList = (props: ISeriesList) => {
  const theme = useTheme();
  const classes = useStyles(theme);
  const { loading, data, error } = useQuery(allSeriesQuery);

  if (error) {
    throw error.message;
  }

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
        {data?.series?.map((s: ISeries) => (
          <ImageCard
            key={s.id}
            file={s.file}
            title={s.seriesName}
            actions={
              <Link className={classes.link} to={routes.getSeriesDetails(s.id)}>
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

export default SeriesList;
