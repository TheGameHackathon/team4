import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
  constructor () {
    super();
    this.state = {
      countOpenCards: 0,
    };
  }

  render () {
    return (
      <div className={ styles.field }>
        <div>
        </div>
        <Field
          onCardClick={this.onCardClick}
        />
      </div>
    );
  }
  onCardClick = (x, y) => {
    console.log(x, y);
  }
}
