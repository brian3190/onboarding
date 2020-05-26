import React, { Component } from 'react';
import NavMenu from './NavMenu';
import Routes from './Routes';
import Footer from './Footer';

const App = () => (
    <div>
        <NavMenu />
        <Routes>
            {this.props.children}
        </Routes>
        <Footer />
    </div>
)

export default App;