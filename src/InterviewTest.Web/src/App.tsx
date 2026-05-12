import React from 'react';
import { BrowserRouter as Router, Routes, Route, NavLink } from 'react-router-dom';
import InspectionList from './components/InspectionList';
import AnomalyDashboard from './components/AnomalyDashboard';
import PipelineOverview from './components/PipelineOverview';

const App: React.FC = () => {
  return (
    <Router>
      <div style={{ fontFamily: 'system-ui, -apple-system, sans-serif' }}>
        <nav style={{
          backgroundColor: '#1a1a2e',
          padding: '12px 24px',
          display: 'flex',
          gap: '20px',
          alignItems: 'center'
        }}>
          <h1 style={{ color: '#e0e0e0', margin: 0, fontSize: '18px', marginRight: '24px' }}>
            Pipeline Integrity Management
          </h1>
          <NavLink to="/" style={({ isActive }) => ({
            color: isActive ? '#4fc3f7' : '#b0b0b0',
            textDecoration: 'none',
            fontWeight: isActive ? 'bold' : 'normal'
          })}>
            Inspections
          </NavLink>
          <NavLink to="/anomalies" style={({ isActive }) => ({
            color: isActive ? '#4fc3f7' : '#b0b0b0',
            textDecoration: 'none',
            fontWeight: isActive ? 'bold' : 'normal'
          })}>
            Anomalies
          </NavLink>
          <NavLink to="/pipelines" style={({ isActive }) => ({
            color: isActive ? '#4fc3f7' : '#b0b0b0',
            textDecoration: 'none',
            fontWeight: isActive ? 'bold' : 'normal'
          })}>
            Pipelines
          </NavLink>
        </nav>

        <main style={{ padding: '24px' }}>
          <Routes>
            <Route path="/" element={<InspectionList />} />
            <Route path="/anomalies" element={<AnomalyDashboard />} />
            <Route path="/pipelines" element={<PipelineOverview />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
};

export default App;
