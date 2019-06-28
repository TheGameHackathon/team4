import React from 'react';
import styles from './styles.css'
import api from '../../api';

export default class Card extends React.Component{
  constructor(props) {
    super(props);
    this.state = {
      imageUrl: null,
      cardFlipped: false
    }
  }
  render() {
    const { imageUrl, cardFlipped } = this.state;
    const styleForImage = {
      ...(imageUrl ? {backgroundImage: `url(${imageUrl}`} : {})
    };
    const cardClassName = `${styles.card} ${cardFlipped ? styles.cardFlipped : '' }`;

    return (
      // Если у карты есть класс cardFlipped, она будет лежать "лицом" вверх,
      //       если нет, то рубашкой вверх.
      <div className={cardClassName} onClick={this.handleClick}>
        {/* Это разметка карты. В ней есть два элемента, один для лицевой стороны, другой для рубашки.
            Оба элемента важны для правильной работы анимации переворачивания.
            Лицевая сторона карты задается ссылкой на соответствующую картинку в атрибуте style */}
        <div className={`${styles.cardSide} ${styles.cardBack}`}></div>
        <div
          className={`${styles.cardSide} ${styles.cardFace}`}
          style={styleForImage}
        ></div>
      </div>
    );
  }
  handleClick = (event) => {
    console.log(event, this)
    // debugger
    this.setState({
      imageUrl: api.openCard(),
      cardFlipped: true
    });

  }
}