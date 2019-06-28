import React from 'react';
import styles from './styles.css';

import Card from '../Card/index';
import api from '../../api';

export default class Cell extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
      const {solved, ...rest} = this.props;
    return (
      <td className={styles.cell}>
          {solved ? null : <Card {...rest}/>}
      </td>
    );
  }
}