import React, { Component } from 'react';
import Activity from './Components/Activity';

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <Activity />
    );
  }
}
