// RESOURCE GUARD
import { useParams, Outlet, Navigate } from "react-router-dom";
import { useGameContext } from "../../contexts/GameContext";
import { useAuthContext } from "../../contexts/AuthContext";

export const GameOwner = ({ children }) => {
  const { gameId } = useParams();
  const { getGame } = useGameContext();
  const { userId } = useAuthContext();

  const currentGame = getGame(gameId);

  if (currentGame && currentGame._ownerId !== userId) {
    return <Navigate to={`/catalogue/${gameId}`} replace />
  }

  return children ? children : <Outlet />
};