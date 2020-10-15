
//---- WITH EVENT DELEGATION (attaching only 1 event listener and using 'target' to capture elements, without attaching event listener to each one of them) ----
function solve() {
  let cardsSection = document.getElementsByClassName('cards')[0];
  let leftSpan = document.getElementsByTagName('span')[0];
  let rightSpan = document.getElementsByTagName('span')[2];
  let historyDiv = document.getElementById('history');

  if (cardsSection === null || leftSpan === null || rightSpan === null || historyDiv === null) {
    throw new Error('Something went wrong...');
  }

  cardsSection.addEventListener('click', function(evt) {
    if (evt.target && evt.target.nodeName === 'IMG') {

      if (historyDiv.childElementCount === 8) {
        return;
      }

      if (evt.target.parentNode.id === 'player1Div' && leftSpan.textContent === '') {
        leftSpan.textContent = evt.target.name;
        evt.target.src = 'images/whiteCard.jpg';
        evt.target.style.border = '0px solid transparent';
      } else if (evt.target.parentNode.id === 'player2Div' && rightSpan.textContent === '') {
        rightSpan.textContent = evt.target.name;
        evt.target.src = 'images/whiteCard.jpg';
        evt.target.style.border = '0px solid transparent';
      }

      if (leftSpan.textContent !== '' && rightSpan.textContent !== '') {
        historyDiv.textContent += `[${leftSpan.textContent} vs ${rightSpan.textContent}] `;

        let player1Card = document.querySelector('#player1Div > img[src="images/whiteCard.jpg"][style*="border: 0px solid transparent;"]');
        let player2Card = document.querySelector('#player2Div > img[src="images/whiteCard.jpg"][style*="border: 0px solid transparent;"]');

        if (Number(leftSpan.textContent) > Number(rightSpan.textContent)) {
          player1Card.style.border = '2px solid green';
          player2Card.style.border = '2px solid red';
        } else {
          player1Card.style.border = '2px solid red';
          player2Card.style.border = '2px solid green';
        }

        leftSpan.textContent = '';
        rightSpan.textContent = '';
      } 
    }
  });
}
