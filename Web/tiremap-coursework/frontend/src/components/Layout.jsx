import { Routes, Route, Navigate } from 'react-router-dom';
import MapView from '../pages/MapView';
import ListView from '../pages/ListView';
import TabNavigation from './TabNavigation';

function Layout() {
  return (
    <div className="flex flex-col bg-slate-700">
      
      <div className="flex-1">
        <Routes>
          <Route path="/" element={<Navigate to="/map" replace />} />
          <Route path="/map" element={<MapView />} />
          <Route path="/list" element={<ListView />} />
        </Routes>
      </div>

      <TabNavigation />
    </div>
  );
}

export default Layout;
