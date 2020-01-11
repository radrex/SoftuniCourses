function solve(steps, stepLength, speed) {

  let meters = steps * stepLength;
  let km = meters / 1000;
  let restTime = Math.floor(meters / 500);
  let seconds = Math.ceil(km / speed * 3600 + restTime * 60);

  //-------------- HOURS --------------
  let hours = Math.floor(seconds / 3600);
  seconds -= hours * 3600;

  //------------- MINUTES -------------
  let minutes = Math.floor(seconds / 60);
  seconds -= minutes * 60;

  hours = (hours < 10 ? "0" : "") + hours;
  minutes = (minutes < 10 ? "0" : "") + minutes;
  seconds = (seconds < 10 ? "0" : "") + seconds;

  console.log(`${hours}:${minutes}:${seconds}`);
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);
