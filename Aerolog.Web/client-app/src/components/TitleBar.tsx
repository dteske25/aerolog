import React from 'react';
import {
  Typography,
  makeStyles,
  TextField,
  InputAdornment,
  Grid,
  Fade,
} from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import { Skeleton } from '@material-ui/lab';

const useStyles = makeStyles(() => ({
  search: {
    width: '100%',
  },
}));

interface ITitleBarProps {
  title: React.ReactNode;
  includeSearching?: boolean;
  searchText?: string;
  isLoading?: boolean;
}

const TitleBar = (props: ITitleBarProps) => {
  const classes = useStyles();
  const shouldShowSearchBar = props.includeSearching ?? true;
  if (props.isLoading) {
    return <TitleBarSkeleton />;
  }
  return (
    <Fade in>
      <Grid container justifyContent="space-between" spacing={3}>
        <Grid item md={4} sm={6} xs={12}>
          <Typography variant="h4">{props.title}</Typography>
        </Grid>
        {shouldShowSearchBar && (
          <Grid item md={4} sm={6} xs={12}>
            <TextField
              className={classes.search}
              label={props.searchText ?? `Search ${props.title}`}
              InputProps={{
                endAdornment: (
                  <InputAdornment position="end">
                    <SearchIcon />
                  </InputAdornment>
                ),
              }}
            />
          </Grid>
        )}
      </Grid>
    </Fade>
  );
};

const TitleBarSkeleton = () => {
  return (
    <Grid container justifyContent="space-between" spacing={3}>
      <Grid item md={4} sm={6} xs={12}>
        <Skeleton variant="rect" height={40} />
      </Grid>
      <Grid item md={4} sm={6} xs={12}>
        <Skeleton variant="rect" height={40} />
      </Grid>
    </Grid>
  );
};

export default TitleBar;
