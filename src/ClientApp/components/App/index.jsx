import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import api from '../../api';

export default class App extends React.Component {
  constructor () {
    super();
    this.state = {
      userName: "test",
      gameId: null,
      countOpenCards: 0,
    };
  }
  componentDidMount() {
    api.gameStart(this.state.userName)
      .then(response => {
        if(response.status === 200) {
          console.log(response);
          return response.json();
        } else {
          throw new Error(`${response.status} ${response.statusText}`);
        }
      })
      .then(data => {
        console.log(data);
        this.setState({gameId: data.gameId});
      })
      .catch(error => {
        console.error(error);
      });
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
  onCardClick = (coords, callback) => {
    console.log(coords);

  }
}
