function chessBoard(n) {
  let currentColour = 'black'
  let previousColour = ''
  console.log('<div class="chessboard">')

  for (let rows = 1; rows <= n; rows++) {
      console.log('  <div>')

      for (let cols = 1; cols <= n; cols++) {
          console.log(`    <span class="${currentColour}"></span>`);

          previousColour = currentColour
          currentColour = previousColour === 'black' ? 'white' : 'black'
      }

      console.log('  </div>')
      if (n % 2 === 0) {
          previousColour = currentColour
          currentColour = previousColour === 'black' ? 'white' : 'black'
      }
  }

  console.log('</div>')
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
chessBoard(3);