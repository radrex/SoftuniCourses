function solve(arr = []) {
  let library = new Map();

  while (arr.length !== 0) {
    let tokens = arr.shift().split(/ -> |: |, /);
    
    if (tokens.length === 2) {
      let [shelf, genre] = tokens;
      shelf = +shelf;
      if (!library.has(shelf)) {
        library.set(shelf, new Map([[genre, []]]));
      }
    } else if (tokens.length === 3) {
      let [title, author, genre] = tokens;

      for (let shelf of library) {
        let isFound = [...shelf[1]].find(x => x[0] === genre);
        if (isFound !== undefined) {
          let book = { title, author, genre };
          isFound[1].push(book);
          break;
        }
      }      
    }
  }

  library = new Map([...library].sort((a, b) => [...b[1]][0][1].length - [...a[1]][0][1].length));
  for (let key of library.keys()) {
    let books = [...library.get(key)][0][1];
    books.sort((a, b) => a.title.localeCompare(b.title));
  }

  for (let [shelf, [...genre]] of library) {
    console.log(`${shelf} ${genre[0][0]}: ${genre[0][1].length}`);
    for (let book of genre[0][1]) {
      console.log(`--> ${book.title}: ${book.author}`);
    }
  }
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['1 -> history',
       '1 -> action',
       'Death in Time: Criss Bell, mystery',
       '2 -> mystery',
       '3 -> sci-fi',
       'Child of Silver: Bruce Rich, mystery',
       'Hurting Secrets: Dustin Bolt, action',
       'Future of Dawn: Aiden Rose, sci-fi',
       'Lions and Rats: Gabe Roads, history',
       '2 -> romance',
       'Effect of the Void: Shay B, romance',
       'Losing Dreams: Gail Starr, sci-fi',
       'Name of Earth: Jo Bell, sci-fi',
       'Pilots of Stone: Brook Jay, history']);
