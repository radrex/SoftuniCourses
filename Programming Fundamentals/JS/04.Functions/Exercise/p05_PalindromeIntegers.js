function checkPalindromes(numbers = []) {
  function isPalindrome(number) {
    let numAsText = number.toString().split('').reverse().join('');
    let num = numAsText - '0';
    console.log(number === num ? "true" : "false");
  }

  for (let number of numbers) {
    isPalindrome(number);
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
checkPalindromes([123,323,421,121]);
checkPalindromes([32,2,232,1010]);