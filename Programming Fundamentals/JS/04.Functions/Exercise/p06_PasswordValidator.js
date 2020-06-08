function validatePassword(password) {
  let isPasswordLengthValid = validatePasswordLength(password);
  let isPasswordCompositionValid = validatePasswordComposition(password);
  let isPasswordDigitsCountValid = validatePasswordDigitCount(password);

  if (isPasswordLengthValid && isPasswordCompositionValid && isPasswordDigitsCountValid) {
    console.log("Password is valid");
  } else {
    if (!isPasswordLengthValid) {
      console.log("Password must be between 6 and 10 characters");
    }
    if (!isPasswordCompositionValid) {
      console.log("Password must consist only of letters and digits");
    }
    if (!isPasswordDigitsCountValid) {
      console.log("Password must have at least 2 digits");
    }
  }

  function validatePasswordLength(password) { return (password.length >= 6 && password.length <= 10); }

  function validatePasswordComposition(password) {
    for (let digit of password) {
      digit = digit.charCodeAt(0);
      if (!(digit >= 48 && digit <= 57) && !(digit >= 65 && digit <= 90) && !(digit >= 97 && digit <= 122)) {
        return false;
      }
    }
    return true;
  }

  function validatePasswordDigitCount(password) {
    let digitCount = 0;
    for (let digit of password) {
      digit = digit.charCodeAt(0);
      if (digit >= 48 && digit <= 57) {
        digitCount++;
      }
    }

    return digitCount < 2 ? false : true;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
validatePassword('logIn');
validatePassword('MyPass123');
validatePassword('Pa$s$s');
