import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Cart } from './components/Cart';
import { Shop } from './components/Shop';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/shop' component={Shop} />
                <Route path='/cart' component={Cart} />
            </Layout>
        );
    }
}
