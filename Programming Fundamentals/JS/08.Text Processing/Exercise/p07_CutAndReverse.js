function solve(text) {
  let mid = Math.ceil(text.length / 2);
  let slice1 = text.slice(0, mid).split('').reverse().join('');
  let slice2 = text.slice(mid).split('').reverse().join('');

  console.log(slice1);
  console.log(slice2);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('tluciffiDsIsihTgnizamAoSsIsihT');
solve('sihToDtnaCuoYteBIboJsihTtAdooGoSmI');
