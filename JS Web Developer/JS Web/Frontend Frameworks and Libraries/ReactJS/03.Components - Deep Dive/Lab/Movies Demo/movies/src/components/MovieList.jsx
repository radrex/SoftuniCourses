import Movie from "./Movie";

export default function MovieList({ movies, onMovieDelete }) {
  return (
    <ul>
      {movies.map(movie => <li key={movie.id}><Movie {...movie} onMovieDelete={onMovieDelete} /></li>)}
    </ul>
  );
}
