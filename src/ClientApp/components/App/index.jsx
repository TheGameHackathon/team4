import React from 'react';
import styles from './styles.css';
import Field from '../Field/index';

export default class App extends React.Component {
    constructor () {
        super();
        // this.state = {
        //     score: 50,
        // };
    }

    render () {
        return (
            <div className={ styles.field }>
                <div>
                </div>
                <Field />
            </div>
        );
    }
}
