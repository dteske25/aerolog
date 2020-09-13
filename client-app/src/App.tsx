import React from 'react';
import Layout from './components/Layout';
import {
  BrowserRouter as Router, Route, Switch
} from "react-router-dom";
import Info from './components/Info';
import Home from './components/Home';

function App() {
  return (
    <div className="App">
      <Router>
        <Layout>
          <Switch>
          <Route path="/info">
            <Info />  
          </Route> 
          <Route path="/about">
            About
          </Route>
          <Route path="/">
            <Home />
          </Route> 

          </Switch>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
