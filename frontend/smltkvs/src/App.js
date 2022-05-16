import './App.css';
import 'antd/dist/antd.min.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Profile from './components/Profile';
import Login from './containers/Login';
import MainMenu from './containers/MainMenu';
import ConcreteCubeTrial from './containers/concreteTests/ConcreteCubeTrial';
import { routes } from './routes';
import ConcreteCubeTrialView from './containers/concreteTests/ConcreteCubeTrialView';

function App() {
  return (
    <Router>
      <div className='App'>
        <Routes>
          <Route path="/profile" element={<Profile />} />
          <Route path={routes.home} element={<MainMenu />} />
          <Route path={routes.login} element={<Login />} />
          <Route path={routes.concreteCubeTrial} element={<ConcreteCubeTrial />} />
          <Route path={routes.concreteCubeTrialView} element={<ConcreteCubeTrialView />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
