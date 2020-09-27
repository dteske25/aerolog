import React, { useEffect, useState } from 'react';
import { useRouteMatch } from 'react-router';
import { getSeries } from '../services/seriesService';
import TitleBar from './TitleBar';
import { IInjectedLoadingProps, withLoading } from '../utilities/LoadingContext';
import ErrorBoundary from './ErrorBoundary';
import { ISeries } from '../types/series';
import { IMission } from '../types/mission';
import { getMissionsBySeriesId } from '../services/missionService';
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

const Series = (props: ISeriesProps & IInjectedLoadingProps) => {
  const { setLoading, isLoading } = props;
  const match = useRouteMatch<ISeriesUrlProps>();
  const [series, setSeries] = useState<ISeries>();
  const [missions, setMissions] = useState<IMission[]>();
  const loadData = React.useCallback(
    async (id: string) => {
      setLoading(true);
      setSeries(await getSeries(id));
      setMissions(await getMissionsBySeriesId(id));
      setLoading(false);
    },
    [setLoading],
  );

  useEffect(() => {
    loadData(match.params.id);
  }, [loadData, match.params.id]);

  const theme = useTheme();
  const classes = useStyles(theme);

  return (
    <ErrorBoundary message="Error loading series">
      <TitleBar title={series?.seriesName} searchText={`Search ${series?.seriesName} Missions`} isLoading={isLoading} />

      <Grid container spacing={3}>
        {isLoading && (
          <>
            <ImageCardSkeleton />
            <ImageCardSkeleton />
            <ImageCardSkeleton />
          </>
        )}
        {missions?.map((m) => (
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

export default withLoading(Series);
