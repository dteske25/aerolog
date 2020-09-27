import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Button, Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import routes from '../utilities/routes';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    textAlign: 'center',
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  },
}));

const Home = () => {
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <Typography variant="h2">Aerolog</Typography>
      <Typography>Explore the logs of previous missions</Typography>
      <Link to={routes.seriesList}>
        <Button>Enter</Button>
      </Link>
    </div>
  );
};

export default Home;
