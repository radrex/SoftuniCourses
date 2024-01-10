import { Link } from 'react-router-dom';

export const Header = () => {
  return (
    <header>
      {/* <!-- Navigation --> */}
      <h1><Link className="home" to="/">GamesPlay</Link></h1>
      <nav>
        <Link to="/catalogue">All games</Link>
        {/* <!-- Logged-in users --> */}
        <div id="user">
          <Link to="/create-game">Create Game</Link>
          <Link to="/logout">Logout</Link>
        </div>
        {/* <!-- Guest users --> */}
        <div id="guest">
          <Link to="/login">Login</Link>
          <Link to="/register">Register</Link>
        </div>
      </nav>
    </header>
  );
};