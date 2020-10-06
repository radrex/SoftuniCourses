function solve() {
  //----------- GET DATA -----------
  let input = document.getElementById('input');
  let select = document.getElementById('selectMenuTo');
  let convertBtn = document.getElementsByTagName('button')[0];
  let result = document.getElementById('result');

  if (input === null || select === null || convertBtn === null || result === null) {
    throw new Error('Something went wrong...');
  }

  //-------- CONSTRUCT HTML --------
  let binaryOpt = document.createElement('option');
  binaryOpt.value = 'binary';
  binaryOpt.textContent = 'Binary';
  select.appendChild(binaryOpt);
  
  let hexOpt = document.createElement('option');
  hexOpt.value = 'hexadecimal';
  hexOpt.textContent = 'Hexadecimal';
  select.appendChild(hexOpt);

  convertBtn.addEventListener('click', function() {
    const actions = {
      'binary': 2,
      'hexadecimal': 16,
    };
    result.value = Number(input.value).toString(actions[select.value]).toUpperCase();
  });
}