import MovieList from './components/MovieList';

function App() {

  const movies = [
    { title: 'Man of Steel', year: 2008, cast: ['Henry Cavil', 'Russell Crowe'] },
    { title: 'Harry Potter', year: 2008, cast: ['Daniel', 'Ema Watson'] },
    { title: 'Lord of the Rings', year: 2008, cast: ['Orlando Bloom', 'Vigo Mortensen'] },
  ];

  return (
    <div>
      <h1>React Movie List Demo</h1>
      <MovieList movies={movies} />
    </div>
  );
}

export default App;
