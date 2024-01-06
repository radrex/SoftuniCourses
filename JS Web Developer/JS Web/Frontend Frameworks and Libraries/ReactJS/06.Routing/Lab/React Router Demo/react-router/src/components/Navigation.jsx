import styles from './Navigation.module.css';

import { Link, NavLink } from 'react-router-dom';

export const Navigation = () => {
	return (
		<nav className={styles.navigation}>
			<ul>
				<li><Link to="/">Home</Link></li>
				<li><NavLink style={({isActive}) => ({color: isActive ? 'purple' : 'orangered'})} to="/about">About</NavLink></li>
				<li><NavLink className={({isActive}) => isActive ? styles['nav-active'] : undefined} to="/characters">Characters</NavLink></li>
			</ul>
		</nav>
	);
};