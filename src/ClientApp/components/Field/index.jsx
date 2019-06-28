import React from 'react';
import styles from './styles.css'

import Cell from '../Cell/index';

export default class Field extends React.Component {
  constructor(props) {
    super(props);
    this.FIELD_SIZE = [8,4];
  }
  renderRow = (y) => {
    const {...rest} = this.props;
    const X = this.FIELD_SIZE[0];
    let cells = [];
    for(let i = 0; i < X; i++) {
      cells.push(
        <Cell key={`Cell_${i}_${y}`} x={i} y={y} {...rest}></Cell>
      );
    }
    return (
      <tr className="row" key={`Row_${y}`}>{cells}</tr>
    );
  }

  render () {
    const Y = this.FIELD_SIZE[1];
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
