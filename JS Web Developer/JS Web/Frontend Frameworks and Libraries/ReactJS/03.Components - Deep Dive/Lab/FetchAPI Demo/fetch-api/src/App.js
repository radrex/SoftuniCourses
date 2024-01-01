import { useState, useEffect } from 'react';
import MovieList from './components/MovieList';

function App() {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    fetch(`http://localhost:3000/movies.json`)
      .then(res => res.json())
      .then(data => {
        setMovies(data.movies);
      });
  }, []);

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
