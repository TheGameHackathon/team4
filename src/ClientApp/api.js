/** Работа с api, отсылка запросов через fetch
 * каждая функция возращает стандартный промис от fetch'а. Пока так мб можно лучше обернуть, хз
 */
const api = {
  gameStart: function (userName) {
    const body = {userName: userName};
    let headers = new Headers({"Content-Type": "application/json"});
    const options = {
      method: 'post',
      // mode: 'cors',
      headers: headers,
      body: JSON.stringify(body)
    };
    return fetch("/api/game/start", options);
  },
  openCard: function(gameId, x, y) {
    const body = {
      x: x,
      y: y
    };
    let headers = new Headers({"Content-Type": "application/json"});
    const options = {
      method: 'post',
      // mode: 'cors',
      headers: headers,
      body: JSON.stringify(body)
    };
    return fetch(`/api/game/${gameId}/card/open`, options);
  }
};
export default api;