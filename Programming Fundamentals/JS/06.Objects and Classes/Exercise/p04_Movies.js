function solve(tokens = []) {
  let movies = [];

  while (tokens.length !== 0) {
    let movieData = tokens.shift();

    if (movieData.includes('addMovie')) {
      movieData = movieData.replace('addMovie ', '');
      let movie = { name: movieData };
      movies.push(movie);
    } else if (movieData.includes('directedBy')) {
      movieData = movieData.replace(' directedBy ', '|').split('|');
      let movie = movies.find(x => x.name === movieData[0]);
  
      if (movie !== undefined) {
        movie.director = movieData[1];
      }
    } else {
      movieData = movieData.replace(' onDate ', '|').split('|');
      let movie = movies.find(x => x.name === movieData[0]);
  
      if (movie !== undefined) {
        movie.date = movieData[1];
      }
    }
  }

  movies.filter(x => Object.keys(x).length === 3).forEach(x => console.log(JSON.stringify(x)));
}

// Don't copy the calling of the function in judge, you won't get any points, just the code above
solve(['addMovie Fast and Furious',
       'addMovie Godfather',
       'Inception directedBy Christopher Nolan',
       'Godfather directedBy Francis Ford Coppola',
       'Godfather onDate 29.07.2018',
       'Fast and Furious onDate 30.07.2018',
       'Batman onDate 01.08.2018',
       'Fast and Furious directedBy Rob Cohen']);
