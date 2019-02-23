import React from 'react';
import styles from './styles.css'
import Cell from '../Cell'

export default class Field extends React.Component {
    render() {
        return (
            <table className={styles.field}>
                <tbody>
                    <tr className={styles.row}>
                        <Cell isFlipped />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                    </tr>
                    <tr className={styles.row}>
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                    </tr>
                    <tr className={styles.row}>
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                        <Cell />
                    </tr>
                </tbody>
            </table>
        );
    }
}
