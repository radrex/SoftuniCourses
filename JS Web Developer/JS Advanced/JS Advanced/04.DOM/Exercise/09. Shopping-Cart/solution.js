function solve() {
  let boughtProducts = new Map();

  //----------- GET DATA -----------
  let buttons = document.getElementsByTagName('button');
  let checkoutBtn = document.getElementsByClassName('checkout')[0];
  let addBtnElements = document.getElementsByClassName('add-product');
  let textAreaElement = document.getElementsByTagName('textarea')[0];

  if (buttons.length <= 0 || checkoutBtn === null || addBtnElements.length <= 0 || textAreaElement === null) {
    throw new Error('Something went wrong...');
  }

  //----------- ADD EVENT LISTENERS ON ADD BUTTONS -----------
  for (let i = 0; i < addBtnElements.length; i++) {
    addBtnElements[i].addEventListener('click', function(click) {
      let btnDiv = click.target.parentElement;
      let price = Number(btnDiv.nextElementSibling.textContent);
      let name = btnDiv.previousElementSibling.children[0].textContent;
      let img = btnDiv.previousElementSibling.previousElementSibling.children[0].src;

      if (!boughtProducts.has(name)) {
        boughtProducts.set(name, { price: 0, img: img });
      }

      boughtProducts.get(name).price += price;
      textAreaElement.textContent += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
    });
  }

  //----------- ADD EVENT LISTENER ON CHECKOUT BUTTON -----------
  checkoutBtn.addEventListener('click', function() {
    textAreaElement.textContent += `You bought ${[...boughtProducts.keys()].join(', ')} for ${[...boughtProducts.values()].reduce((totalPrice, product) => totalPrice + product.price, 0).toFixed(2)}.`;
    [...buttons].forEach(x => x.setAttribute('disabled', true));
  });
}


/* ---- NOT WORKING IN JUDGE ----
  function solve() {
    let boughtProducts = new Map();

    //----------- GET DATA -----------
    let productNames = [...document.getElementsByClassName('product-title')].map(x => x.textContent);
    let productPictures = [...document.getElementsByTagName('img')].map(x => x.src);
    let productPrices = [...document.getElementsByClassName('product-line-price')].map(x => +x.textContent);

    let buttons = document.getElementsByTagName('button');
    let checkoutBtn = document.getElementsByClassName('checkout')[0];
    let addBtnElements = document.getElementsByClassName('add-product');
    let textAreaElement = document.getElementsByTagName('textarea')[0];

    //----------- ADD EVENT LISTENERS ON ADD BUTTONS -----------
    for (let i = 0; i < addBtnElements.length; i++) {
      addBtnElements[i].addEventListener('click', function() {
        if (!boughtProducts.has(productNames[i])) {
          boughtProducts.set(productNames[i], { price: 0, img: productPictures[i] });
        }
        boughtProducts.get(productNames[i]).price += productPrices[i];
        textAreaElement.textContent += `Added ${productNames[i]} for ${productPrices[i].toFixed(2)} to the cart.\n`;
      });
    }
    
    //----------- ADD EVENT LISTENER ON CHECKOUT BUTTON -----------
    checkoutBtn.addEventListener('click', function() {
      textAreaElement.textContent += `You bought ${[...boughtProducts.keys()].join(', ')} for ${[...boughtProducts.values()].reduce((totalPrice, product) => totalPrice + product.price, 0).toFixed(2)}.`;
      [...buttons].forEach(x => x.setAttribute('disabled', true));
    });
  }
*/
