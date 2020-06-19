function decode(message = []) {
  let templateMatrixLenght = parseInt(message.shift());
  let templateMatrix = [];

  for (let i = 0; i < templateMatrixLenght; i++) {
    templateMatrix[i] = message.shift().split(' ').map(Number);
  }

  for (let row = 0; row < message.length; row++) {
    message[row] = message[row].split(' ').map(Number);
  }

  let r = 0;  // TEMPLATE MATRIX ROW
  let c = 0;  // TEMPLATE MATRIX COLUMN

  for (let row = 0; row < message.length; row++) {
    for (let i = 0; i < message[row].length; i++) {                                         
      message[row][i] += templateMatrix[r][c];  // SUM VALUES FROM TEMPLATE AND MESSAGE MATRIX ||| 4 + 59 = 63 -> X ||| Number of symbols on the stone = 27 -> Y |
      message[row][i] -= (parseInt(message[row][i] / 27) * 27); // DECODE VALUE ||| Formula -> X - (parseInt(X / Y) * Y)
                                                               //               |||           63 - (parseInt(63 / 27) * 27) --> 63 - (2 * 27) = 9 ---> "I" from Stone

      message[row][i] += 64;  // 1("A" from stone) + 64("@" from ASCII) = 65 ("A" in ASCII TABLE)) |||   9("I") + 64("@") = 73("I" in ASCII)

      templateMatrix[r].length - 1 > c ? c++ : c = 0;
    }

    c = 0;
    templateMatrix.length - 1 > r ? r++ : r = 0;
  }

  let decodedMessage = '';
  message.forEach(row => row.forEach(x => decodedMessage += (x !== 64) ? String.fromCharCode(x) : " ")); // IF symbol is equal to 64("@") append whitespace instead
  
  return decodedMessage;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(decode([ '2',
                     '59 36',
                     '82 52',
                     '4 18 25 19 8',
                     '4 2 8 2 18',
                     '23 14 22 0 22',
                     '2 17 13 19 20',
                     '0 9 0 22 22' ]));
      
console.log(decode([ '2',
                     '31 32',
                     '74 37',
                     '19 0 23 25',
                     '22 3 12 17',
                     '5 9 23 11',
                     '12 18 10 22' ]));
