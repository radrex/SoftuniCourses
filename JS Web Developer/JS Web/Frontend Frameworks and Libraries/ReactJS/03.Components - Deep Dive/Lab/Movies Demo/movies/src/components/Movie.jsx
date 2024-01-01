export default function Movie({ id, title, year, plot, posterUrl, director, onMovieDelete }) {
  return (
    <article>
      <h3>{title}, {year}</h3>
      <main>
        <img src={posterUrl} alt={title} />
        <p>{plot}</p>
      </main>
      <footer>
        <p>{director}</p>
        <button onClick={() => onMovieDelete(id)}>Delete</button>
      </footer>
    </article>
  );
}