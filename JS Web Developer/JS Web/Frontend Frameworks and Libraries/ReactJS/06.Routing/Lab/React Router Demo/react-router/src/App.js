import { Routes, Route } from 'react-router-dom';
import { Home } from './components/Home';
import { About } from './components/About';
import { NotFound } from './components/NotFound';
import { Navigation } from './components/Navigation';
import { CharacterList } from './components/CharacterList';
import { Character } from './components/Character';

function App() {
  return (
    <>
      <Navigation />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/home" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="*" element={<NotFound />} />
        <Route path="/characters" element={<CharacterList />} />
        <Route path="/characters/:characterId/*" element={<Character />} />
      </Routes>
    </>
  );
}

export default App;
