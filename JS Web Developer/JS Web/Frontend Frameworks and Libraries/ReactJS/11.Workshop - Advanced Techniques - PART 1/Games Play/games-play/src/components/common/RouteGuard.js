import { Navigate, Outlet } from "react-router-dom";

import { useAuthContext } from "../../contexts/AuthContext";

// Way 1
export const RouteGuard = ({ children }) => {
  const { isAuthenticated } = useAuthContext();

  if (!isAuthenticated) {
    return <Navigate to="/login" />
  }

  return children ? children : <Outlet />
};

// Way 2
// export const RouteGuard = () => {
//   const { isAuthenticated } = useAuthContext();

//   if (!isAuthenticated) {
//     return <Navigate to="/login" />
//   }

//   return <Outlet />
// };

// Way 3
// export const RouteGuard = ({ children }) => {
//   const { isAuthenticated } = useAuthContext();

//   if (!isAuthenticated) {
//     return <Navigate to="/login" />
//   }

//   return (
//     <>
//       {children}
//     </>
//   )
// };