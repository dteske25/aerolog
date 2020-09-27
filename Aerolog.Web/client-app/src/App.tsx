import React from 'react';
import Layout from './components/Layout';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Info from './components/Info';
import Home from './components/Home';
import Series from './components/Series';
import Mission from './components/Mission';
import { createMuiTheme, ThemeProvider, IconButton } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { SnackbarProvider } from 'notistack';
import { LoadingProvider } from './utilities/LoadingContext';
import SeriesList from './components/SeriesList';
import routes from './utilities/routes';

const theme = createMuiTheme({
  palette: {
    type: 'dark',
    primary: {
      main: '#c62828',
    },
    secondary: {
      main: '#757575',
    },
  },
});

function App() {
  const notistackRef = React.createRef<any>();
  const onClickDismiss = (key: React.ReactText) => () => {
    notistackRef.current.closeSnackbar(key);
  };
  return (
    <ThemeProvider theme={theme}>
      <SnackbarProvider
        maxSnack={3}
        ref={notistackRef}
        action={(key) => (
          <IconButton onClick={onClickDismiss(key)}>
            <CloseIcon />
          </IconButton>
        )}
      >
        <LoadingProvider>
          <Router>
            <Layout>
              <Switch>
                <Route path={routes.missionDetails}>
                  <Mission />
                </Route>
                <Route path={routes.seriesDetails}>
                  <Series />
                </Route>
                <Route path={routes.seriesList}>
                  <SeriesList />
                </Route>
                <Route path={routes.info}>
                  <Info />
                </Route>
                <Route path={routes.about}>About</Route>
                <Route path={routes.home}>
                  <Home />
                </Route>
              </Switch>
            </Layout>
          </Router>
        </LoadingProvider>
      </SnackbarProvider>
    </ThemeProvider>
  );
}

export default App;
