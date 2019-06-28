import React from "react";
import styles from "./styles.css";
import Field from "../Field";
import api from "../../api";

export default class App extends React.Component {
  constructor() {
    super();
    const field = Array.from(Array(4)).map(y =>
      Array.from(Array(8)).map(x => 
        ({
          imageUrl: null,
          cardFlipped: false
        })
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
          // console.log(response);
          return response.json();
        } else {
          throw new Error(`${response.status} ${response.statusText}`);
        }
      })
      .then(data => {
        console.log('После клика', data);
        for(const card of data.field.opened) {
          console.log(card);
          if(x === card.position.x && y === card.position.y) {
            this.setNewField(y, x, card.imageUrl);
          }
        }
      });
  };
  setNewField = (y, x, imageUrl) => {
    this.setState(prevState => {
      const newState = {
        ...prevState,
        field: [
          ...prevState.field.slice(0, y),
          [
            ...prevState.field[y].slice(0,x),
            {
              ...prevState.field[y][x],
              imageUrl: imageUrl,
              cardFlipped: true
            },
            ...prevState.field[y].slice(x+1)
          ],
          ...prevState.field.slice(y+1)
        ]
      }
      return newState;
    })
  }
}
