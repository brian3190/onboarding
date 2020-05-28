//import '../../wwwroot/styles/styles.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom'
import App from './Components/App';
//import 'semantic-ui-css/semantic.min.css';


ReactDOM.render(
    <div>
        <h1>Hello World</h1>
    </div>,
    document.getElementById('root')
)


// Allow Hot Module Replacement
/*if (module.hot) {
    module.hot.accept();
    //module.hot.accept('./routes', () => { const NextApp = require('./routes').default; renderApp(); });
}*/