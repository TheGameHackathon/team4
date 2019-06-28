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
      firstOpenCard: null,
      secondOpenCard: null,
      FIELD_SIZE: [8, 4],
      field: field,
      solvedCards: []
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
    const {solvedCards, field, FIELD_SIZE } = this.state;
    return (
      <div className={styles.field}>
        <Field
          onCardClick={this.onCardClick}
          FIELD_SIZE={FIELD_SIZE}
          field={field}
          solvedCards={solvedCards}
        />
      </div>
    );
  }
  onCardClick = (x, y) => {
    // console.log(coords);
    const { gameId, countOpenCards } = this.state;
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
        this.setState({solvedCards: data.field.solved});
        for(const card of data.field.opened) {
          console.log(card);
          if(x === card.position.x && y === card.position.y) {
            this.setNewField(y, x, card.imageUrl, true);
            switch (countOpenCards) {
              case 0:
                this.setState({
                  firstOpenCard: {x: x, y: y},
                  countOpenCards: countOpenCards + 1
                });
                break;
              case 1:
                this.setState({
                  secondOpenCard: {x: x, y: y},
                  countOpenCards: 0
                });

                setTimeout(() => {
                  const { x: x1, y: y1 }  = firstOpenCard;
                  const { x: x2, y: y2 }  = secondOpenCard;
                  this.setNewField(y1, x1, null, false);
                  this.setNewField(y2, x2, null, false);
                }, 3000);
                
                break;
            
              default:
                break;
            }
          }
        }
      });
  };
  setNewField = (y, x, imageUrl, cardFlipped) => {
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
              cardFlipped: cardFlipped
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
