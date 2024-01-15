import { useEffect } from "react";
import { useParams } from "react-router";

import { useService } from "../../hooks/useService";
import { gameServiceFactory } from "../../services/gameService";
import { useForm } from "../../hooks/useForm";
import { useGameContext } from "../../contexts/GameContext";

export const EditGame = () => {
  const { onGameEditSubmit } = useGameContext(); 
  const { gameId } = useParams();
  const gameService = useService(gameServiceFactory);
  const { values, changeHandler, onSubmit, changeValues } = useForm({
    _id: '',
    title: '',
    category: '',
    maxLevel: '',
    imageUrl: '',
    sumamry: '',
  }, onGameEditSubmit);

  useEffect(() => {
    gameService.getById(gameId)
      .then(result => {
        changeValues(result);
      });
  }, [gameId]);

  return (
    <section id="edit-page" className="auth">
      <form id="edit" method="POST" onSubmit={onSubmit}>
        <div className="container">

          <h1>Edit Game</h1>
          <label for="leg-title">Legendary title:</label>
          <input
            type="text"
            id="title"
            name="title"
            value={values.title}
            onChange={changeHandler}
          />

          <label for="category">Category:</label>
          <input
            type="text"
            id="category"
            name="category"
            value={values.category}
            onChange={changeHandler}
          />

          <label for="levels">MaxLevel:</label>
          <input
            type="number"
            id="maxLevel"
            name="maxLevel"
            min="1"
            value={values.maxLevel}
            onChange={changeHandler}
          />

          <label for="game-img">Image:</label>
          <input
            type="text"
            id="imageUrl"
            name="imageUrl"
            value={values.imageUrl}
            onChange={changeHandler}
          />

          <label for="summary">Summary:</label>
          <textarea name="summary" id="summary" value={values.summary} onChange={changeHandler}></textarea>
          <input className="btn submit" type="submit" value="Edit Game" />

        </div>
      </form>
    </section>

  );
};