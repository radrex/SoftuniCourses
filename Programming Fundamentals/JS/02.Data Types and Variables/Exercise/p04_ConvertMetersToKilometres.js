function metersToKm(meters) {
  let kilometers = meters / 1000.0;
  return kilometers.toFixed(2);
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(metersToKm(1852));
console.log(metersToKm(798));
