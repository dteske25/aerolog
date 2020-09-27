import React, { useEffect, useState } from 'react';
import { getAllSeries } from '../services/seriesService';
import { Grid, makeStyles, useTheme, Button } from '@material-ui/core';
import TitleBar from './TitleBar';
import { Link } from 'react-router-dom';
import ErrorBoundary from './ErrorBoundary';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import { IInjectedLoadingProps, withLoading } from '../utilities/LoadingContext';
import { ISeries } from '../types/series';

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

const SeriesList = (props: ISeriesList & IInjectedLoadingProps) => {
  const { setLoading, isLoading } = props;
  const [series, setSeries] = useState<ISeries[]>();

  const theme = useTheme();
  const classes = useStyles(theme);

  const loadData = React.useCallback(async () => {
    setLoading(true);
    setSeries(await getAllSeries());
    setLoading(false);
  }, [setLoading]);

  useEffect(() => {
    loadData();
  }, [loadData]);
  return (
    <ErrorBoundary message="Failed to load Series">
      <TitleBar title="Series" isLoading={isLoading} />

      <Grid container spacing={3}>
        {isLoading && (
          <>
            <ImageCardSkeleton />
            <ImageCardSkeleton />
            <ImageCardSkeleton />
          </>
        )}
        {series?.map((s) => (
          <ImageCard
            key={s.id}
            file={s.file}
            title={s.seriesName}
            actions={
              <Link className={classes.link} to={`/series/${s.id}`}>
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

export default withLoading(SeriesList);
