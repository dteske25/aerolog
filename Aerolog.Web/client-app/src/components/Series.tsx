import React from 'react';
import { useRouteMatch } from 'react-router';
import { SERIES_BY_ID_QUERY } from '../services/seriesService';
import { useQuery } from '@apollo/client';
import TitleBar from './TitleBar';
import ErrorBoundary from './ErrorBoundary';
import { IMission } from '../types/mission';
import { Grid, Button, useTheme, makeStyles } from '@material-ui/core';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import routes from '../utilities/routes';
import { Link } from 'react-router-dom';
import { seriesByIdVariables, seriesById } from '../services/__generated__/seriesById';

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
  const { loading, data, error } = useQuery<seriesById, seriesByIdVariables>(SERIES_BY_ID_QUERY, {
    variables: { seriesId: match.params.id },
  });

  const theme = useTheme();
  const classes = useStyles(theme);

  if (error) {
    throw error.message;
  }

  let series = null;
  if (data?.series) {
    series = data.series[0];
  }

  return (
    <ErrorBoundary message="Error loading series">
      <TitleBar title={series?.seriesName} searchText={`Search ${series?.seriesName} Missions`} isLoading={loading} />

      <Grid container spacing={3}>
        {loading && (
          <>
            <ImageCardSkeleton />
            <ImageCardSkeleton />
            <ImageCardSkeleton />
          </>
        )}
        {series?.missions?.map((m) => {
          console.log(m);
          if (!m) {
            return null;
          }
          return (
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
          );
        })}
      </Grid>
    </ErrorBoundary>
  );
};

export default Series;
