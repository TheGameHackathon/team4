import React from 'react';
import styles from './styles.css'

export default function Card(props){
  console.log(styles);
  return (
    // Если у карты есть класс cardFlipped, она будет лежать "лицом" вверх,
    //       если нет, то рубашкой вверх.
    <div className={styles.card}>
      {/* Это разметка карты. В ней есть два элемента, один для лицевой стороны, другой для рубашки.
          Оба элемента важны для правильной работы анимации переворачивания.
          Лицевая сторона карты задается ссылкой на соответствующую картинку в атрибуте style */}
      <div className={`${styles.cardSide} ${styles.cardBack} ${this.props.cardFlipped && 'cardFlipped'}`}></div>
      <div className={`${styles.cardSide} ${styles.cardBack}`} style="background-image: url('images/card-joker.png')"></div>
    </div>
  );
}