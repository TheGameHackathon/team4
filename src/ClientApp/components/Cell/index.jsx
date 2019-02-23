import React from 'react';
import PropTypes from 'prop-types'
import styles from './styles.css'

const style4Jocker = {
    backgroundImage: "url(./static/images/card-joker.png)"
}

export default class Cell extends React.Component {
    render() {
        let classForCard = styles.card
        if (this.props.isFlipped === true)
            classForCard += ' ' + styles.cardFlipped
        return (
            <td className={styles.cell}>
                <div className={classForCard}>
                    <div className={styles.cardSide + ' ' + styles.cardBack}></div>
                    <div className={styles.cardSide + ' ' + styles.cardFace} style={style4Jocker}></div>
                </div>
            </td>
        )
    }
}

Cell.propTypes = {
    isFlipped: PropTypes.bool
}