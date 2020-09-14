import React from 'react';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import HomeIcon from '@material-ui/icons/Home';
import InfoIcon from '@material-ui/icons/Info';
import { NavLink, useLocation } from 'react-router-dom';
import { makeStyles, useTheme } from '@material-ui/core';
import clsx from 'clsx';

const routes = [
  {
    key: 'home',
    title: 'Home',
    url: '/',
    Icon: HomeIcon,
  },
  {
    key: 'info',
    title: 'Info',
    url: '/info',
    Icon: InfoIcon,
  },
  {
    key: 'about',
    title: 'About',
    url: '/about',
  },
];

const useStyles = makeStyles((theme) => ({
  link: {
    textDecoration: 'none',
    color: theme.palette.primary.contrastText,
  },
  activeLink: {
    textDecoration: 'none',
    color: theme.palette.primary.contrastText,
    fontWeight: theme.typography.fontWeightBold,
  },
  activeLinkBackground: {
    backgroundColor: theme.palette.primary.main,
  },
}));

export default function Navbar() {
  const theme = useTheme();
  const classes = useStyles(theme);
  const location = useLocation();
  return (
    <List>
      {routes.map(({ key, title, url, Icon }) => {
        const className =
          location.pathname === url ? classes.activeLink : classes.link;
        return (
          <NavLink
            className={classes.link}
            activeClassName={classes.activeLink}
            isActive={(match) => match?.url === url}
            to={url}
            key={key}
          >
            <ListItem
              className={clsx(
                location.pathname === url && classes.activeLinkBackground,
              )}
              button
            >
              {Icon && (
                <ListItemIcon>
                  <Icon className={className} />
                </ListItemIcon>
              )}
              <ListItemText className={className} primary={title} />
            </ListItem>
          </NavLink>
        );
      })}
    </List>
  );
}
