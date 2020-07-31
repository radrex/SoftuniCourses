function solve(arr = []) {
  let vip = [];
  let regular = [];
  let reservation = arr.shift();
  while (reservation !== 'PARTY') {
      if (/^\d+/.test(reservation)) {
          vip.push(reservation);
      } else {
          regular.push(reservation);
      }
      reservation = arr.shift();
  }

  for (let guest of arr) {
      if (vip.indexOf(guest) >= 0) {
          vip.splice(vip.indexOf(guest), 1);
      }
      if (regular.indexOf(guest) >= 0) {
          regular.splice(regular.indexOf(guest), 1);
      }
  }

  console.log(vip.length + regular.length);
  vip.forEach(el => console.log(el));
  regular.forEach(el => console.log(el));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['7IK9Yo0h',
       '9NoBUajQ',
       'Ce8vwPmE',
       'SVQXQCbc',
       'tSzE5t0p',
       'PARTY',
       '9NoBUajQ',
       'Ce8vwPmE',
       'SVQXQCbc']);

solve(['m8rfQBvl',
       'fc1oZCE0',
       'UgffRkOn',
       '7ugX7bm0',
       '9CQBGUeJ',
       '2FQZT3uC',
       'dziNz78I',
       'mdSGyQCJ',
       'LjcVpmDL',
       'fPXNHpm1',
       'HTTbwRmM',
       'B5yTkMQi',
       '8N0FThqG',
       'xys2FYzn',
       'MDzcM9ZK',
       'PARTY',
       '2FQZT3uC',
       'dziNz78I',
       'mdSGyQCJ',
       'LjcVpmDL',
       'fPXNHpm1',
       'HTTbwRmM',
       'B5yTkMQi',
       '8N0FThqG',
       'm8rfQBvl',
       'fc1oZCE0',
       'UgffRkOn',
       '7ugX7bm0',
       '9CQBGUeJ']);