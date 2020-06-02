function dayOfWeek(day) {
  let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
  if (day >= 1 && day <= 7) {
    console.log(days[day - 1]);
  } else {
    console.log('Invalid day!');
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
dayOfWeek(3);
dayOfWeek(6);
dayOfWeek(11);
