import { useState } from 'react';
import { movies as movieData } from './movies';
import MovieList from './components/MovieList';

function App() {
  const [movies, setMovies] = useState(movieData);

  const onMovieDelete = (id) => {
    setMovies(state => state.filter(x => x.id !== id));
  };

  const onMovieSelect = (id) => {
    setMovies(state => state.map(x => ({...x, selected: x.id === id})));
  };

  return (
    <div>
      <h1>Movie Collection</h1>

      <MovieList movies={movies} onMovieDelete={onMovieDelete} onMovieSelect={onMovieSelect} />
    </div>
  );
}

export default App;
