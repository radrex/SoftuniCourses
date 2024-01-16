import { useState, useEffect, useCallback, useMemo } from 'react';
import LatestGame from './LatestGame';

export const Home = () => {
  const [latestGames, setLatestGames] = useState([]);

  useEffect(() => {
    fetch(`http://localhost:3030/data/games`)
      .then(res => res.json())
      .then(result => {
        setLatestGames(result.map(x => ({ ...x, rating: 0 })));
      });
  }, []);

  const onLikeClick = useCallback((gameId) => {
    setLatestGames(state => state.map(x => x._id === gameId ? { ...x, rating: x.rating + 1 } : x));
  }, [])

  const result = useMemo(() => {
    // Slow calculation
    return 42;
  }, []);

  return (
    <section id="welcome-world">

      <div className="welcome-message">
        <h2>ALL new games are</h2>
        <h3>Only in GamesPlay</h3>
      </div>
      <img src="./images/four_slider_img01.png" alt="hero" />

      <div id="home-page">
        <h1>Latest Games - {result}</h1>

        {latestGames.map(game => <LatestGame key={game._id} {...game} onLikeClick={onLikeClick} />)}

        {latestGames.length === 0 && <p className="no-articles">No games yet</p>}
      </div>
    </section>
  );
}