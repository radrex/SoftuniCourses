//--------------- WITH MAP ----------------
function solve(input) {
  return input.slice()
              .map(([width, height]) => ({
                width, height,
                area: () => width * height,
                compareTo (rect) {
                  return rect.area() - this.area() || rect.width - this.width;
                },
              }))
              .sort((a, b) => a.compareTo(b));
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(solve([[10,5],[5,12]]));
console.log(solve([[10,5], [3,20], [5,12]]));

//-------------- WITH REDUCE --------------
/*
  function solve(input) {
    return input.slice()
                .reduce((acc, [width, height]) => {
                  acc.push({
                    width, height,
                    area: () => width * height,
                    compareTo (rect) {
                      return rect.area() - this.area() || rect.width - this.width;
                    },
                  });
                  return acc;
                }, [])
                .sort((a, b) => a.compareTo(b));
  }

  // Don't copy the code below in judge, you won't get any points, just the code above
  console.log(solve([[10,5],[5,12]]));
  console.log(solve([[10,5], [3,20], [5,12]]));
*/
