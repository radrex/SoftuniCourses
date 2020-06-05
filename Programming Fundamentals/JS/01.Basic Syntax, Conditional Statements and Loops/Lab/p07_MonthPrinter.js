function solve(month) {
  switch (month) {
    case 1:     console.log("January");     break;
    case 2:     console.log("February");    break;
    case 3:     console.log("March");       break;
    case 4:     console.log("April");       break;
    case 5:     console.log("May");         break;
    case 6:     console.log("June");        break;
    case 7:     console.log("July");        break;
    case 8:     console.log("August");      break;
    case 9:     console.log("September");   break;
    case 10:    console.log("October");     break;
    case 11:    console.log("November");    break;
    case 12:    console.log("December");    break;

    default:    console.log("Error!");      break;
  }

  //---- Different Approach ----
  // const months = {
  //   1: "January",
  //   2: "February",
  //   3: "March",
  //   4: "April",
  //   5: "May",
  //   6: "June",
  //   7: "July",
  //   8: "August",
  //   9: "September",
  //   10: "October",
  //   11: "November",
  //   12: "December",
  // }

  // console.log((months[month] || "Error!"));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(2);
solve(13);