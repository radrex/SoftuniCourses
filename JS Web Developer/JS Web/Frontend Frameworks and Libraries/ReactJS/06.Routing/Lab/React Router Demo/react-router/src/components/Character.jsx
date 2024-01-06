import styles from './Navigation.module.css';
import { useEffect, useState } from "react";
import { useParams, useNavigate, Link, Routes, Route } from "react-router-dom";
import { CharacterFilms } from './CharacterFilms';

const baseUrl = 'https://swapi.dev/api/people';

export const Character = () => {
  const { characterId } = useParams();
  const navigate = useNavigate(); // navigation with hook
  const [character, setCharacter] = useState({});

  useEffect(() => {
    fetch(`${baseUrl}/${characterId}`)
      .then(res => res.json())
      .then(data => {
        setCharacter(data);
      })
  }, [characterId]);

  const onBackButtonClickWithHook = () => {
    // navigate(-1); // go back
    navigate('/characters'); // go back
  };

  return (
    <>
      <h1>Character Page</h1>
      <h2>{character.name}</h2>
      <button onClick={onBackButtonClickWithHook}>Back to characters list with hook</button>

      {/* Nested Router */}
      <nav className={styles.navigation}>
        <ul>
          <li><Link to="films">Films</Link></li>
          <li><Link to="vehicles">Vehicles</Link></li>
          <li><Link to="starships">Starships</Link></li>
        </ul>
      </nav>

      {/* Try commenting the code below to see how it works (for example when clicking on "Films") */}
      <Routes>
        <Route path="/films" element={<CharacterFilms />} />
        <Route path="/vehicles" element={<h5>Vehicles</h5>} />
        <Route path="/starships" element={<h5>Starships</h5>} />
      </Routes>
    </>
  );
};