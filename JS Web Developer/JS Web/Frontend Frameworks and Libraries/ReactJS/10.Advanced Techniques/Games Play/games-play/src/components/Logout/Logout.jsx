import { useContext, useEffect } from "react";
import { AuthContext } from "../../contexts/AuthContext";
import { Navigate } from "react-router-dom";

export const Logout = () => {
  const { onLogout } = useContext(AuthContext);

  useEffect(() => {
    onLogout();
  }, [onLogout]);

  return (
    <Navigate to="/" />
  );
};