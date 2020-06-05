function getNextDayDate(year, month, day) {
  let nextDayDate = new Date(year, --month, ++day);
  return`${nextDayDate.getFullYear()}-${nextDayDate.getMonth()+1}-${nextDayDate.getDate()}`;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(getNextDayDate(2016, 9, 30));
