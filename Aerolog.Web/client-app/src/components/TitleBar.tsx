import React from 'react';
import {
  Typography,
  makeStyles,
  TextField,
  InputAdornment,
  Grid,
} from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';

const useStyles = makeStyles(() => ({
  search: {
    width: '100%',
  },
}));

interface ITitleBarProps {
  title: string;
}

const TitleBar = (props: ITitleBarProps) => {
  const classes = useStyles();
  return (
    <Grid container spacing={3}>
      <Grid item md={4} sm={6} xs={12}>
        <Typography variant="h4">{props.title}</Typography>
      </Grid>
      <Grid item md={8} sm={6} xs={12}>
        <TextField
          className={classes.search}
          label={`Search ${props.title}`}
          InputProps={{
            endAdornment: (
              <InputAdornment position="end">
                <SearchIcon />
              </InputAdornment>
            ),
          }}
        />
      </Grid>
    </Grid>
  );
};

export default TitleBar;
