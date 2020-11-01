function printDeckOfCards(cards) {
  class Card {
    constructor(face, suit) {
      this.face = face.toUpperCase();
      this.suit = suit.toUpperCase();
    }

    get face() { return this._face }
    set face(x) {
      let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
      if (!faces.includes(x)) {
        throw new Error('Error');
      }
      this._face = x;
    }

    get suit() { return this._suit }
    set suit(x) {
      let suits = ['S', 'H', 'D', 'C'];
      if (!suits.includes(x)) {
        throw new Error('Error');
      }
      this._suit = x;
    }

    toString() {
      let suits = new Map([['S', '\u2660'],
                           ['H', '\u2665'],
                           ['D', '\u2666'],
                           ['C', '\u2663']]);
      return `${this.face}${suits.get(this.suit)}`;
    }
  }

  let lastLoggedMessage = '';
  let deck = [];
  for (let card of cards) {
    let face = card.substring(0, card.length - 1);
    let suit = card.substr(card.length - 1, 1);

    try {
      deck.push(new Card(face, suit));
    } catch (err) {
      log(`Invalid card: ${card}`);
      return lastLoggedMessage;
    }
  }

  log(deck.join(" "));

  function log(msg) {
    lastLoggedMessage = msg;
    console.log(msg);
  }

  return lastLoggedMessage;
}

module.exports = {
  printDeckOfCards,
};