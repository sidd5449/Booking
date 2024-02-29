import './App.css';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import SlotInfo from './pages/SlotInfo';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/:id' element={<SlotInfo />} />
      </Routes>
    </div>
  );
}

export default App;
