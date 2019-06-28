import React from 'react';
import styles from './styles.css'

export default function Cell(props) {
    return (
      <td className={styles.cell}>
        {props.children}
      </td>
    );
}