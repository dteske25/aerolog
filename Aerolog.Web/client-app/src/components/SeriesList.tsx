import React, { useEffect, useState } from 'react';
import { getAllSeries, ISeries } from '../services/seriesService';
import {
  Typography,
  Card,
  CardContent,
  Grid,
  CardActions,
  makeStyles,
  useTheme,
  CardMedia,
  Button,
  TextField,
  InputAdornment,
} from '@material-ui/core';
import TitleBar from './TitleBar';
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

const SeriesList = () => {
  const [series, setSeries] = useState<ISeries[]>();
  const loadData = async () => {
    setSeries(await getAllSeries());
  };

  const theme = useTheme();
  const classes = useStyles(theme);
  useEffect(() => {
    loadData();
  }, []);
  return (
    <div>
      <TitleBar title="Series" />

      <Grid container spacing={3}>
        {series?.map((s) => (
          <Grid key={s.id} item xs={12} sm={6} md={4}>
            <Card>
              <CardMedia
                image="/static/images/cards/contemplative-reptile.jpg"
                title="Contemplative Reptile"
              />
              <CardContent>
                <Typography>{s.seriesName}</Typography>
              </CardContent>
              <CardActions>
                <Link className={classes.link} to={`/series/${s.id}`}>
                  <Button size="small" color="primary">
                    View Missions
                  </Button>
                </Link>
              </CardActions>
            </Card>
          </Grid>
        ))}
      </Grid>
    </div>
  );
};

export default SeriesList;
