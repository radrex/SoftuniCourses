import { useGameContext } from '../../contexts/GameContext';
import { CatalogueItem } from './CatalogueItem';

export const Catalogue = () => {
  const { games } = useGameContext();

  return (
    <section id="catalog-page">
      <h1>All Games</h1>
      {games.map(game => <CatalogueItem key={game._id} {...game} />)}
      {games.length === 0 && <h3 className="no-articles">No articles yet</h3>}
    </section>
  );
};