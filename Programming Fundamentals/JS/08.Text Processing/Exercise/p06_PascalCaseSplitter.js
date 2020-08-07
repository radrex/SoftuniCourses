function solve(text) {
  text = text.replace(/([A-Z])/g, ' $1').replace(/^./, function(str){ return str.toUpperCase(); }).trim().split(' ');
  console.log(text.join(', '));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');
