function solve(ticketData, sortCriteria) {
  class Ticket {
    constructor(destination, price, status) {
      this.destination = destination;
      this.price = price;
      this.status = status;
    }
  }

  let tickets = ticketData.slice()
                          .map(x => x.split('|'))
                          .reduce((acc, [destination, price, status]) => {
                            acc.push(new Ticket(destination, +price, status));
                            return acc;
                          }, [])
                          .sort((a, b) => sortCriteria !== 'price' ? a[sortCriteria].localeCompare(b[sortCriteria]) : a[sortCriteria] - b[sortCriteria]);
  return tickets;
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
console.log(solve(['Philadelphia|94.20|available',
                   'New York City|95.99|available',
                   'New York City|95.99|sold',
                   'Boston|126.20|departed'],'destination'));