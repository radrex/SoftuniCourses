function solution(num) {
  return function addNext(nextNum) {
    return num + nextNum;
  }
}

// Don't copy the code below in judge, you won't get any points, just the code above
let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));
