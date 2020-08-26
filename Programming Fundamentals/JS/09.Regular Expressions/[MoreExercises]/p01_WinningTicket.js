function solve(tickets = []) {
  tickets = tickets[0].split(/[, ]+/g);

  let pattern = /(\@{6,}|\${6,}|\^{6,}|\#{6,})/g;

  if (tickets !== null) {
    for (let ticket of tickets) {
      if (ticket.length !== 20) {
        console.log('invalid ticket');
        continue;
      }

      let leftSide = ticket.substring(0, 10).match(pattern);
      let rightSide = ticket.substring(10).match(pattern);

      if (leftSide === null || rightSide === null) {
        console.log(`ticket "${ticket}" - no match`);
        continue;
      }

      let minLen = Math.min(leftSide[0].length, rightSide[0].length);
      let left = leftSide[0].substring(0, minLen);
      let right = rightSide[0].substring(0, minLen);

      if (left === right) {
        console.log(left.length === 10 ? `ticket "${ticket}" - ${minLen}${left.substring(0, 1)} Jackpot!` :
                                         `ticket "${ticket}" - ${minLen}${left.substring(0, 1)}`);
      } else {
        console.log(`ticket "${ticket}" - no match`);
      }
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['Cash$$$$$$Ca$$$$$$sh']);
solve(['$$$$$$$$$$$$$$$$$$$$, aabb  , th@@@@@@eemo@@@@@@ey']);
solve(['validticketnomatch:(']);
