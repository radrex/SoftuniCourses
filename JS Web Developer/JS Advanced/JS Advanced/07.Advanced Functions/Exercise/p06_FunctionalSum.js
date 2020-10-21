function add(a) {
  let curry = (b) => {
    a += b
    return curry
  }
  curry.toString = () => a
  return curry
}

// Don't copy the code below in judge, you won't get any points, just the code above
console.log(+add(1))
console.log(+add(1)(6)(-3));