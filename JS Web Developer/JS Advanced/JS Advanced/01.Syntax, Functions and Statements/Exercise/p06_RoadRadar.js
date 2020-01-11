function solve(arr) {
  let speed = +arr[0];
  let area = arr[1];

  switch (area) {
    case "motorway":  // speed limit 130 km/h
        console.log(getRadarMessage(130, speed));
      break;
      
    case "interstate":  // speed limit 90 km/h
        console.log(getRadarMessage(90, speed));
      break;
    
    case "city":  // speed limit 50 km/h
        console.log(getRadarMessage(50, speed));
      break;

    case "residential": // speed limit 20 km/h
        console.log(getRadarMessage(20, speed));
      break;

    default:
      break;
  }

  //---- Nested function / Closure --- for judge, if outside throws runtime error
  function getRadarMessage(speedLimit, speed) {
    let radarMessage = "";
  
    if (speed <= speedLimit) {
      return radarMessage;
    }
  
    let speedDifference = speed - speedLimit;
    if (speedDifference <= 20) {
      radarMessage = "speeding";
    }
    else if (speedDifference <= 40) {
      radarMessage = "excessive speeding";
    }
    else {
      radarMessage = "reckless driving";
    }
  
    return radarMessage;
  }
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);

