import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';

const baseUrl = 'https://swapi.dev/api';

export const CharacterFilms = () => {
  const { characterId } = useParams();
  const [films, setFilms] = useState([]);

  // imagine fetching something like /people/${characterId}/films from swapi, because API is not implemented like that and won't serve the purpose of the demo.
  useEffect(() => {
    fetch(`${baseUrl}/films`)
      .then(res => res.json())
      .then(data => {
        setFilms(data.results);
      })
  }, [characterId]);

  return (
    <>
      <h1>Character films</h1>
      {
        films.map(x => {
            const id = x.url.split('/').filter(x => x).pop();
            return <li key={id}><Link to={`/films/${id}`}>{x.title}</Link></li>
          }
        )
      }
    </>
  )
};