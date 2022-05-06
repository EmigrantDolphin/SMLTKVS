import './App.css';
import 'antd/dist/antd.min.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Profile from './components/Profile';
import Login from './containers/Login';
import StandardSelection from './containers/StandardSelection';
import ConcreteTrial from './containers/StandardTrials/Concrete/ConcreteTrial';

function App() {
  return (
    <Router>
      <div className='App'>
        <Routes>
          <Route path="/profile" element={<Profile />} />
          <Route path="/" element={<StandardSelection />} />
          <Route path="/login" element={<Login />} />
          <Route path="/concreteTrial" element={<ConcreteTrial />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
