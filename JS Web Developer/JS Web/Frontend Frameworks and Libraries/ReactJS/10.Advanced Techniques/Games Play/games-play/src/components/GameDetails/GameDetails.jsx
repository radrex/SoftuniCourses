import { useParams, useNavigate, Link } from 'react-router-dom';
import { useEffect, useState, useReducer } from 'react';

import { gameServiceFactory } from '../../services/gameService';
import * as commentService from '../../services/commentService';
import { useService } from '../../hooks/useService';
import { useAuthContext } from '../../contexts/AuthContext';
import { gameReducer } from '../../reducers/gameReducer';

import { AddComment } from './AddComment/AddComment';

export const GameDetails = () => {
  const { gameId } = useParams();
  const { userId, isAuthenticated, userEmail } = useAuthContext();
  const [game, dispatch] = useReducer(gameReducer, {});
  const gameService = useService(gameServiceFactory);
  const navigate = useNavigate();

  useEffect(() => {
    Promise.all([
      gameService.getById(gameId),
      commentService.getAllByGameId(gameId),
    ]).then(([gameData, comments]) => {
      const gameState = { ...gameData, comments };
      dispatch({ type: 'GAME_FETCH', payload: gameState });
    });
  }, [gameId]);

  const onCommentSubmit = async (values) => {
    const response = await commentService.create(gameId, values.comment)
    dispatch({ type: 'COMMENT_ADD', payload: response, userEmail });
  };

  const isOwner = game._ownerId === userId;

  const onDeleteClick = async () => {
    await gameService.delete(game._id);

    // TODO: delete from state

    navigate('/catalogue');
  };

  return (
    <section id="game-details">
      <h1>Game Details</h1>
      <div className="info-section">

        <div className="game-header">
          <img className="game-img" src={game.imageUrl} />
          <h1>{game.title}</h1>
          <span className="levels">MaxLevel: {game.maxLevel}</span>
          <p className="type">{game.category}</p>
        </div>

        <p className="text">{game.summary}</p>

        {/* <!-- Bonus ( for Guests and Users ) --> */}
        <div className="details-comments">
          <h2>Comments:</h2>
          <ul>
            {game.comments && game.comments.map(x => (
              <li key={x._id} className="comment">
                <p>{x.author.email}: {x.comment}</p>
              </li>
            ))}
          </ul>
          {!game?.comments?.length && (
            <p className="no-comment">No comments.</p>
          )}
        </div>

        {/* <!-- Edit/Delete buttons ( Only for creator of this game )  --> */}
        {isOwner && (
          <div className="buttons">
            <Link to={`/catalogue/${game._id}/edit`} className="button">Edit</Link>
            <button className="button" onClick={onDeleteClick}>Delete</button>
          </div>
        )}

      </div>

      {isAuthenticated && <AddComment onCommentSubmit={onCommentSubmit} />}

    </section>
  );
};