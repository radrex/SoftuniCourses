import { AuthProvider } from './contexts/AuthContext';
import { GameProvider } from './contexts/GameContext';
import { withAuth } from './hoc/withAuth';

import { Routes, Route } from 'react-router-dom';

import { RouteGuard } from './components/common/RouteGuard';
import { GameOwner } from './components/common/GameOwner';
import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Login } from './components/Login/Login';
import { Logout } from './components/Logout/Logout';
import { Register } from './components/Register/Register';
import { CreateGame } from './components/CreateGame/CreateGame';
import { Catalogue } from './components/Catalogue/Catalogue';
import { GameDetails } from './components/GameDetails/GameDetails';
import { EditGame } from './components/EditGame/EditGame';

function App() {

  // const EnhancedLogin = withAuth(Login);
  return (
    <AuthProvider>
      <GameProvider>
        <div id="box">
          <Header />

          <main id="main-content">
            <Routes>
              <Route path="/" element={<Home />} />
              {/* <Route path="/login" element={<EnhancedLogin />} /> */}
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/catalogue" element={<Catalogue />} />
              <Route path="/catalogue/:gameId" element={<GameDetails />} />

              {/* Using route guard - WAY 1, 2 (RouteGuard.js) */}
              <Route element={<RouteGuard />}>
                {/* EditGame will go into Outlet in the RouteGuard.js */}
                <Route path="/catalogue/:gameId/edit" element={
                  <GameOwner>
                    <EditGame />
                  </GameOwner>
                } />
                <Route path="/create-game" element={<CreateGame />} />
                <Route path="/logout" element={<Logout />} />
              </Route>

              {/* Using route guard - WAY 3 (RouteGuard.js) */}
              {/* <Route path="/create-game" element={
              <RouteGuard>
                <CreateGame onCreateGameSubmit={onCreateGameSubmit} />
              </RouteGuard>
            } /> */}

            </Routes>
          </main>

        </div>
      </GameProvider>
    </AuthProvider >
  );
}

export default App;
