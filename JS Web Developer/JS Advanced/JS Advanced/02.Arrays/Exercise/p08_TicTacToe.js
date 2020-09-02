function solve(arr = []) {
  let board = [[false, false, false],
               [false, false, false],
               [false, false, false]];
  
  let isPlayerXTurn = true;
  
  for (let i = 0; i < arr.length; i++) {
    let [row, col] = arr[i].split(' ').map(x => +x);

    if (board[row][col] === false) {
      if (isPlayerXTurn) {
        board[row][col] = 'X';
        if (isWinner(board, 'X')) {
          return `Player X wins!\n${printMatrix()}`;
        }
        isPlayerXTurn = false;
      } else {
        board[row][col] = 'O';
        if (isWinner(board, 'O')) {
          return `Player O wins!\n${printMatrix()}`;
        }
        isPlayerXTurn = true;
      }
    } else if (board[row][col] === 'X' || board[row][col] === 'O' && board.includes(false)) {
      console.log(`This place is already taken. Please choose another!`);
    }
  }

  return `The game ended! Nobody wins :(\n${printMatrix()}`;

  //------------- FUNCTIONS -------------
  function isWinner(board = [], player) {
    if ((board[0][0] === player && board[1][1] === player && board[2][2] === player) || (board[0][2] === player && board[1][1] === player && board[2][0] === player)) {
      return true;  // check diagonals
    }

    for (let i = 0; i < 3; i++) {
      if ((board[i][0] === player && board[i][1] === player && board[i][2] === player) || (board[0][i] === player && board[1][i] === player  && board[2][i] === player) === true) {
        return true; // check rows and cols
      }
    }
    return false;
  }

  //-------------------------------------
  function printMatrix() {
    let printedMatrix = '';
    board.forEach(row => printedMatrix += row.join('\t') + '\n');
    return printedMatrix;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(["0 1",
                   "0 0",
                   "0 2", 
                   "2 0",
                   "1 0",
                   "1 1",
                   "1 2",
                   "2 2",
                   "2 1",
                   "0 0"]));

console.log(solve(["0 0",
                   "0 0",
                   "1 1",
                   "0 1",
                   "1 2",
                   "0 2",
                   "2 2",
                   "1 2",
                   "2 2",
                   "2 1"]));

console.log(solve(["0 1",
                   "0 0",
                   "0 2",
                   "2 0",
                   "1 0",
                   "1 2",
                   "1 1",
                   "2 1",
                   "2 2",
                   "0 0"]));