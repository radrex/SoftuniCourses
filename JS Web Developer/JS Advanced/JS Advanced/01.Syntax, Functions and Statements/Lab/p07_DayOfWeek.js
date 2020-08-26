function solve(day) {
  const daysMap = {
    "Monday": 1,
    "Tuesday": 2,
    "Wednesday": 3,
    "Thursday": 4,
    "Friday": 5,
    "Saturday": 6,
    "Sunday": 7
  }

  return daysMap[day] ? daysMap[day] : "error";
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve("Monday"));
console.log(solve("Friday"));
console.log(solve("Invalid"));

//------------- Pure Function -------------
/*
    const daysMap = {
      "Monday": 1,
      "Tuesday": 2,
      "Wednesday": 3,
      "Thursday": 4,
      "Friday": 5,
      "Saturday": 6,
      "Sunday": 7
    }

    function solve(map, day) {
      return map[day] ? map[day] : "error";
    }

    console.log(solve(daysMap, "Monday"));
    console.log(solve(daysMap, "Friday"));
    console.log(solve(daysMap, "Invalid"));
*/
