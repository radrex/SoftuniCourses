//-------------------------------- IIFE --------------------------------
(function () {
  const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
  const suits = ['♠', '♥', '♦', '♣'];

  const Suits = {
    SPADES: '♠',
    HEARTS: '♥',
    DIAMONDS: '♦',
    CLUBS: '♣',
  };

  class Card {
    constructor(face, suit) {
      if (!faces.includes(face)) {
        throw new Error('Invalid Card Face!');
      }
      if (!suits.includes(suit)) {
        throw new Error('Invalid Card Suit!');
      }
      this.face = face;
      this.suit = suit;
    }
  }

  return {
    Suits: Suits,
    Card: Card
  }
}())

// Don't copy the code below in judge, you won't get any points, just the code above
// let Card = result.Card;
// let Suits = result.Suits;

let card = new Card("Q", Suits.CLUBS);
card.face = "A";
card.suit = Suits.DIAMONDS;
let card2 = new Card("1", Suits.DIAMONDS); // Should throw Error

//------------------- IIFE WITH GETTERS AND SETTERS --------------------
/*
  (function(){
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let suits = ['♠', '♥', '♦', '♣'];

    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣',
    };

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() { return this._face; }
        set face(face) {
            if (!faces.includes(face)) {
                throw new Error('Invalid Card Face!');
            }
            this._face = face;
            return;
        }

        get suit() { return this._suit; }
        set suit(suit) {
            if (!suits.includes(suit)) {
                throw new Error('Invalid Card Suit!');
            }
            this._suit = suit;
            return;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    }
  }())
*/
