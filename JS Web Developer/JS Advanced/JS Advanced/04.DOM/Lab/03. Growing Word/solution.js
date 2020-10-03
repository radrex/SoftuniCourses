//---- I ----
function growingWord() {
  const colors = ['blue', 'green', 'red'];

  let paragraph = document.getElementsByTagName('p')[2];
  if (paragraph === null) {
    throw new Error('Something is wrong...');
  }

  let color = paragraph.style.color;
  paragraph.style.color = color === '' ? 'blue' : colors[(colors.indexOf(color) + 1) % colors.length];

  let px = parseInt(paragraph.style.fontSize);
  paragraph.style.fontSize = `${!px ? '2' : px * 2}px`;
}

/* ---- II ----
  function growingWord() {
    const word = document.querySelector("#exercise > p");
    if (word === null) {
      throw new Error('Something is wrong...');
    }
    let px = 2;
    let colorChanges = {
      "blue": "green",
      "green": "red",
      "red": "blue"
    };
    if (!word.hasAttribute("style")) {
      word.setAttribute("style", `color:blue; font-size: ${px}px`);
    } else {
      let currentPx = word.style["font-size"];
      px = currentPx.substr(0, currentPx.length - 2) * 2;
      let currentColor = word.style.color; 
      word.setAttribute("style", `color:${colorChanges[currentColor]}; font-size: ${px}px`)
    }
  }
*/

/* ---- III ------------------ NOT WORKING IN JUDGE ----------------------
  function growingWord() {
    //----------- GET DATA -----------
    let colors = [...document.getElementById('colors').children].reduce((colors, color) => {
      colors.push(getComputedStyle(color).backgroundColor);
      return colors;
    }, []);

    let paragraph = document.querySelector("#exercise > p");

    if (colors.length === 0 || paragraph === null) {
      throw new Error('Something is wrong...');
    }

    //----------- SET NEW PROPERTIES ON CLICK -----------
    if (getComputedStyle(paragraph).fontSize === '0px') {
      paragraph.setAttribute("style", `color:${colors[0]}; font-size: ${2}px`);
    } else {
      let color = paragraph.style.color;
      let px = parseInt(paragraph.style['font-size']) * 2;
      paragraph.setAttribute("style", `color:${colors[(colors.indexOf(color) + 1) % colors.length]}; font-size: ${px}px`);
    }
  }
*/