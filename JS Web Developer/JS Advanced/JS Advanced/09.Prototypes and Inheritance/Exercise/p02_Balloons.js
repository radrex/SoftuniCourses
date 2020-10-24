function balloons() {
  //----------- BASE CLASS -----------
  class Balloon {
    constructor(color, gasWeight) {
      this.color = color;
      this.gasWeight = gasWeight;
    }
  }

  //----------- CHILD CLASS -----------
  class PartyBalloon extends Balloon {
    constructor(color, gasWeight, ribbonColor, ribbonLength) {
      super(color, gasWeight);
      this.ribbonColor = ribbonColor;
      this.ribbonLength = ribbonLength;
      this._ribbon = {color: ribbonColor, length: ribbonLength};
    }

    get ribbon() { return this._ribbon }
  }

  //----------- CHILD CLASS -----------
  class BirthdayBalloon extends PartyBalloon {
    constructor(color, gasWeight, ribbonColor, ribbonLength, text) {
      super(color, gasWeight, ribbonColor, ribbonLength);
      this._text = text;
    }

    get text() { return this._text }
  }

  return { Balloon, PartyBalloon, BirthdayBalloon };
}

// Don't copy the code below in judge, you won't get any points, just the code above
let balloonClasses = balloons();
let partyBalloon = new balloonClasses.PartyBalloon('red', 10, 'white', 5);
let birthdayBalloon = new balloonClasses.BirthdayBalloon('orange', 100, 'black', 15, 'Happy Birthday');

console.log(partyBalloon.ribbon);
console.log(birthdayBalloon.ribbon);
console.log(birthdayBalloon.text);

