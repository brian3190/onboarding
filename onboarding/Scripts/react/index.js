import '../../wwwroot/styles/styles.css';
import React, { Component } from 'react';
import { render } from 'react-dom';
import { BrowserRouter } from 'react-router-dom'
import App from './Components/App';
import 'semantic-ui-css/semantic.min.css';


ReactDOM.render(
    <BrowserRouter>
        <App />
    </BrowserRouter>,
    document.getElementById("root")
);


// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept();
    //module.hot.accept('./routes', () => { const NextApp = require('./routes').default; renderApp(); });
}