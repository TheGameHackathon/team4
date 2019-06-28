import React from "react";
import styles from "./styles.css";
import Field from "../Field";
import api from "../../api";

export default class App extends React.Component {
  constructor() {
    super();
    const field = Array.from(Array(4)).map(y =>
      Array.from(Array(8)).map(x => 
        ({ imageUrl: null })
      )
    );
    this.state = {
      userName: "test",
      gameId: null,
      countOpenCards: 0,
      FIELD_SIZE: [8, 4],
      field: field
    };
  }

  componentDidMount() {
    api
      .gameStart(this.state.userName)
      .then(response => {
        if (response.status === 200) {
          // console.log(response);
          return response.json();
        } else {
          throw new Error(`${response.status} ${response.statusText}`);
        }
      })
      .then(data => {
        // console.log(data);
        this.setState({ gameId: data.gameId });
      })
      .catch(error => {
        console.error(error);
      });
  }

  render() {
    const { field, FIELD_SIZE } = this.state;
    return (
      <div className={styles.field}>
        <Field
          onCardClick={this.onCardClick}
          FIELD_SIZE={FIELD_SIZE}
          field={field}
        />
      </div>
    );
  }
  onCardClick = (x, y) => {
    // console.log(coords);
    const { gameId } = this.state;
    api
      .openCard(gameId, x, y)
      .then(response => {
        if (response.status === 200) {
          console.log(response);
          return response.json();
        } else {
          throw new Error(`${response.status} ${response.statusText}`);
        }
      })
      .then(data => {
        console.log(data);
      });
  };
}
