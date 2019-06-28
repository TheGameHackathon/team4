import React from 'react';
import styles from './styles.css'

import Cell from '../Cell/index';

export default class Field extends React.Component {
  constructor(props) {
    super(props);
    // this.FIELD_SIZE = [8,4];
  }
  renderRow = (y) => {
    const {FIELD_SIZE, field, ...rest} = this.props;
    const X = FIELD_SIZE[0];
    let cells = [];
    for(let x = 0; x < X; x++) {
      // console.log(y, x, field[y]);
      cells.push(
        <Cell
          key={`Cell_${x}_${y}`}
          x={x} y={y}
          imageUrl={field[y][x].imageUrl}
          cardFlipped={field[y][x].cardFlipped}
          {...rest}
        ></Cell>
      );
    }
    return (
      <tr className="row" key={`Row_${y}`}>{cells}</tr>
    );
  }

  render () {
    const Y = this.props.FIELD_SIZE[1];
    let rows = [];
    for(let i = 0; i < Y; i++) {
      rows.push(this.renderRow(i));
    }
    return (
      <table className={styles.field}>
        <tbody>
          {rows}
        </tbody>
      </table>
    );
  }
}
