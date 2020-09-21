import React from 'react';
import Layout from './components/Layout';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Info from './components/Info';
import Home from './components/Home';
import Series from './components/Series';
import {
  createMuiTheme,
  ThemeProvider,
  Button,
  IconButton,
} from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import { SnackbarProvider } from 'notistack';

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
        <Router>
          <Layout>
            <Switch>
              <Route path="/series/:id">
                <Series />
              </Route>
              <Route path="/info">
                <Info />
              </Route>
              <Route path="/about">About</Route>
              <Route path="/">
                <Home />
              </Route>
            </Switch>
          </Layout>
        </Router>
      </SnackbarProvider>
    </ThemeProvider>
  );
}

export default App;
