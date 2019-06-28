import React from "react";
import styles from "./styles.css";
import api from "../../api";


export default class Card extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
        // cardFlipped: false
    };
  }
  render() {
      // const { cardFlipped  } = this.state;
      // const { imageUrl } = this.props;
      const {imageUrl, cardFlipped} = this.props;
    const styleForImage = {
        ...(imageUrl ? {backgroundImage: `url(${imageUrl}`} : {})
    };
      const cardClassName = `${styles.card} ${
          cardFlipped ? styles.cardFlipped : ""
          }`;

    return (
      // Если у карты есть класс cardFlipped, она будет лежать "лицом" вверх,
        // если нет, то рубашкой вверх.
      <div className={cardClassName} onClick={this.handleClick}>
        {/* Это разметка карты. В ней есть два элемента, один для лицевой стороны, другой для рубашки.
          Оба элемента важны для правильной работы анимации переворачивания.
          Лицевая сторона карты задается ссылкой на соответствующую картинку в атрибуте style */}
          <div className={`${styles.cardSide} ${styles.cardBack}`}/>
        <div
          className={`${styles.cardSide} ${styles.cardFace}`}
          style={styleForImage}
        />
      </div>
    );
  }

    handleClick = event => {
        if (this.props.cardFlipped) {
            return;
        }
        const {x, y} = this.props;
        this.props.onCardClick(x, y);
    };
}
