function solve(country) {
  switch (country) {
    case "USA":
    case "England":
      console.log("English");
      break;

    case "Spain":
    case "Argentina":
    case "Mexico":
      console.log("Spanish");
      break;

    default:
      console.log("unknown");
      break;
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('USA');
solve('Germany')