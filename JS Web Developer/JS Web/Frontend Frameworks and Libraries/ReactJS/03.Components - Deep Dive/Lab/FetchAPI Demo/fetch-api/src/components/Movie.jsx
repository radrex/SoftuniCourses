import { useEffect } from "react";
import styles from './Movie.module.css';

export default function Movie({
  id,
  title,
  year,
  plot,
  posterUrl,
  director,
  onMovieDelete,
  onMovieSelect,
  selected,
}) {
  // Mount
  useEffect(() => {
    console.log(`Movie ${title} - mounted!`);
  }, [title]);

  // Mount + Update
  useEffect(() => {
    console.log(`Movie ${title} - update!`);
  }, [selected, title]);

  // Unmount
  useEffect(() => {
    return () => {
      console.log(`Movie ${title} - unmounted!`);
    };
  }, [title]);

  return (
    <article className={styles['movie-article']}>
      <h3>{title}, {year}</h3>
      { selected && <h4>Selected</h4> }

      <main>
        <img src={posterUrl} alt={title} />
        <p>{plot}</p>
      </main>
      <footer>
        <p>{director}</p>
        <button onClick={() => onMovieDelete(id)}>Delete</button>
        <button onClick={() => onMovieSelect(id)}>Select</button>
      </footer>
    </article>
  );
}