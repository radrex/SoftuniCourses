import { requestFactory} from './requester';

const baseUrl = 'http://localhost:3030/data/games';

export const gameServiceFactory = (token) => {
  const request = requestFactory(token);

  const getAll = async () => {
    const result = await request.get(baseUrl);
    const games = Object.values(result);

    return games;
  };

  const create = async (gameData) => {
    const result = await request.post(baseUrl, gameData);
    return result;
  };

  const getById = async (gameId) => {
    const result = await request.get(`${baseUrl}/${gameId}`);
    return result;
  };

  const edit = (gameId, data) => request.put(`${baseUrl}/${gameId}`, data);

  const deleteGame = (gameId) => request.delete(`${baseUrl}/${gameId}`);

  return {
    getAll,
    create,
    getById,
    // addComment,
    delete: deleteGame,
    edit,
  };
};