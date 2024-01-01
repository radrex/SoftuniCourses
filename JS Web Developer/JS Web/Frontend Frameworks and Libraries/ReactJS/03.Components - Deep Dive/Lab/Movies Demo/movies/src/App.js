import { useState } from 'react';
import { movies as movieData } from './movies';
import MovieList from './components/MovieList';

function App() {
  const [movies, setMovies] = useState(movieData);

  const onMovieDelete = (id) => {
    setMovies(state => state.filter(x => x.id !== id));
  };

  return (
    <div>
      <h1>Movie Collection</h1>

      <MovieList movies={movies} onMovieDelete={onMovieDelete} />
    </div>
  );
}

export default App;
