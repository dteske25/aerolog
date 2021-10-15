import React from 'react';
import { ApolloProvider } from '@apollo/client';
import { client } from './apiHelper';
import Layout from './components/Layout';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Info from './components/Info';
import Home from './components/Home';
import Series from './components/Series';
import Mission from './components/Mission';
import { ThemeProvider } from '@material-ui/core';
import { createTheme } from '@material-ui/core/styles';
import SeriesList from './components/SeriesList';
import routes from './utilities/routes';

const theme = createTheme({
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
  return (
    <ApolloProvider client={client}>
      <ThemeProvider theme={theme}>
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
      </ThemeProvider>
    </ApolloProvider>
  );
}

export default App;
