import React from 'react';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import MailIcon from '@material-ui/icons/Mail';
import HomeIcon from '@material-ui/icons/Home';
import InfoIcon from '@material-ui/icons/Info';
import { NavLink, useRouteMatch } from 'react-router-dom';
import { makeStyles, useTheme } from '@material-ui/core';

const routes = [
  {
    key: "home",
    title: "Home",
    url: "/",
    icon: (className: string) => <HomeIcon className={className} />,
  },
  {
    key: "info",
    title: "Info",
    url: "/info",
    icon: (className: string) => <InfoIcon className={className} />,
  },
  {
    key: "about",
    title: "About",
    url: "/about"
  }
];

const useStyles = makeStyles((theme) => ({
  link: {
    textDecoration: "none",
    color: theme.palette.grey[500],
  },
  activeLink: {
    textDecoration: "none",
    color: theme.palette.primary.main,
    fontWeight: theme.typography.fontWeightBold
  }
}));

export default function Navbar() {
  const theme = useTheme();
  const classes = useStyles(theme);
  const match = useRouteMatch();
  console.log(match);
  return (
    <List>
      {routes.map(r => (
        <NavLink 
          className={classes.link} 
          activeClassName={classes.activeLink} 
          isActive={(match) => match?.url === r.url}
          to={r.url}
        >
          <ListItem button key={r.key}>
            {r.icon &&
              <ListItemIcon>{r.icon(match.url === r.url ? classes.activeLink : classes.link)}</ListItemIcon>
            }
            <ListItemText primary={r.title} />
          </ListItem>
        </NavLink>
      ))}
    </List>
  )

}
