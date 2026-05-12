import { useState, useEffect } from 'react';
import { Anomaly, PipeSegment } from '../types';

export default function AnomalyDashboard() {
  const [anomalies, setAnomalies] = useState<Anomaly[]>([]);
  const [segments, setSegments] = useState<PipeSegment[]>([]);
  const [selectedAnomaly, setSelectedAnomaly] = useState<Anomaly | null>(null);
  const [filterType, setFilterType] = useState<string>('');
  const [filterSeverity, setFilterSeverity] = useState<string>('');
  const [criticalCount, setCriticalCount] = useState<number>(0);
  const [highCount, setHighCount] = useState<number>(0);
  const [averageSeverityDepth, setAverageSeverityDepth] = useState<number>(0);
  const [showDetails, setShowDetails] = useState<boolean>(false);

  useEffect(() => {
    fetch('/api/anomalies')
      .then((res) => res.json())
      .then((data) => {
        setAnomalies(data);
      });
  }, []);

  useEffect(() => {
    if (anomalies.length === 0) return;

    const segmentIds = [...new Set(anomalies.map((a) => a.pipeSegmentId))];

    segmentIds.forEach((segId) => {
      fetch(`/api/pipesegments/${segId}`)
        .then((res) => res.json())
        .then((segment) => {
          setSegments((prev) => {
            if (prev.find((s) => s.id === segment.id)) return prev;
            return [...prev, segment];
          });
        });
    });
  }, [anomalies]);

  useEffect(() => {
    if (anomalies.length === 0) return;

    const critical = anomalies.filter((a) => a.severity === 'Critical').length;
    const high = anomalies.filter((a) => a.severity === 'High').length;
    const avgDepth =
      anomalies.reduce((sum, a) => sum + a.depthPercent, 0) / anomalies.length;

    setCriticalCount(critical);
    setHighCount(high);
    setAverageSeverityDepth(Math.round(avgDepth * 100) / 100);
  }, [segments, anomalies]);

  const handleSelectAnomaly = (anomaly: Anomaly) => {
    console.log('Previously selected:', selectedAnomaly?.id);
    setSelectedAnomaly(anomaly);
    setShowDetails(true);
  };

  useEffect(() => {
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === 'Escape') {
        if (selectedAnomaly) {
          console.log('Closing details for anomaly:', selectedAnomaly.id);
        }
        setShowDetails(false);
        setSelectedAnomaly(null);
      }
    };

    window.addEventListener('keydown', handleKeyDown);
    return () => window.removeEventListener('keydown', handleKeyDown);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const getSegmentName = (segmentId: number) => {
    const seg = segments.find((s) => s.id === segmentId);
    return seg ? seg.segmentName : 'Loading...';
  };

  const filteredAnomalies = anomalies
    .filter((a) => (filterType ? a.anomalyType === filterType : true))
    .filter((a) => (filterSeverity ? a.severity === filterSeverity : true));

  const anomalyTypes = [...new Set(anomalies.map((a) => a.anomalyType))];
  const severities = [...new Set(anomalies.map((a) => a.severity))];

  return (
    <div style={{ padding: 20 }}>
      <h1>Anomaly Dashboard</h1>

      <div style={{ display: 'flex', gap: 16, marginBottom: 20 }}>
        <div style={{ padding: 16, backgroundColor: '#e3f2fd', borderRadius: 8, flex: 1, textAlign: 'center' }}>
          <div style={{ fontSize: 24, fontWeight: 'bold' }}>{anomalies.length}</div>
          <div style={{ color: '#666' }}>Total Anomalies</div>
        </div>
        <div style={{ padding: 16, backgroundColor: '#ffebee', borderRadius: 8, flex: 1, textAlign: 'center' }}>
          <div style={{ fontSize: 24, fontWeight: 'bold', color: '#c62828' }}>{criticalCount}</div>
          <div style={{ color: '#666' }}>Critical</div>
        </div>
        <div style={{ padding: 16, backgroundColor: '#fff3e0', borderRadius: 8, flex: 1, textAlign: 'center' }}>
          <div style={{ fontSize: 24, fontWeight: 'bold', color: '#e65100' }}>{highCount}</div>
          <div style={{ color: '#666' }}>High</div>
        </div>
        <div style={{ padding: 16, backgroundColor: '#f3e5f5', borderRadius: 8, flex: 1, textAlign: 'center' }}>
          <div style={{ fontSize: 24, fontWeight: 'bold' }}>{averageSeverityDepth}%</div>
          <div style={{ color: '#666' }}>Avg Depth %</div>
        </div>
      </div>

      {/* Filters */}
      <div style={{ display: 'flex', gap: 12, marginBottom: 16 }}>
        <select
          value={filterType}
          onChange={(e) => setFilterType(e.target.value)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4 }}
        >
          <option value="">All Types</option>
          {anomalyTypes.map((t, i) => (
            <option key={i} value={t}>{t}</option>
          ))}
        </select>
        <select
          value={filterSeverity}
          onChange={(e) => setFilterSeverity(e.target.value)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4 }}
        >
          <option value="">All Severities</option>
          {severities.map((s, i) => (
            <option key={i} value={s}>{s}</option>
          ))}
        </select>
        <span style={{ marginLeft: 'auto', color: '#666', alignSelf: 'center' }}>
          {filteredAnomalies.length} anomalies shown
        </span>
      </div>

      {/* Anomaly list */}
      <div style={{ display: 'flex', gap: 20 }}>
        <div style={{ flex: 2 }}>
          <table style={{ width: '100%', borderCollapse: 'collapse' }}>
            <thead>
              <tr style={{ backgroundColor: '#e0e0e0' }}>
                <th style={{ padding: 8, textAlign: 'left' }}>ID</th>
                <th style={{ padding: 8, textAlign: 'left' }}>Segment</th>
                <th style={{ padding: 8, textAlign: 'left' }}>Type</th>
                <th style={{ padding: 8, textAlign: 'left' }}>Severity</th>
                <th style={{ padding: 8, textAlign: 'left' }}>Depth %</th>
                <th style={{ padding: 8, textAlign: 'left' }}>Repair</th>
              </tr>
            </thead>
            <tbody>
              {filteredAnomalies.map((anomaly, index) => (
                <tr
                  key={index}
                  onClick={() => handleSelectAnomaly(anomaly)}
                  style={{
                    cursor: 'pointer',
                    backgroundColor: selectedAnomaly?.id === anomaly.id ? '#e8f5e9' : index % 2 === 0 ? '#fff' : '#f5f5f5',
                  }}
                >
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>{anomaly.id}</td>
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>{getSegmentName(anomaly.pipeSegmentId)}</td>
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>{anomaly.anomalyType}</td>
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>
                    <span
                      style={{
                        padding: '2px 8px',
                        borderRadius: 12,
                        fontSize: '0.85em',
                        backgroundColor:
                          anomaly.severity === 'Critical' ? '#ffcdd2' :
                          anomaly.severity === 'High' ? '#ffe0b2' :
                          anomaly.severity === 'Medium' ? '#fff9c4' : '#c8e6c9',
                      }}
                    >
                      {anomaly.severity}
                    </span>
                  </td>
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>{anomaly.depthPercent}%</td>
                  <td style={{ padding: 8, borderBottom: '1px solid #ddd' }}>
                    {anomaly.repairRequired ? '⚠️ Yes' : 'No'}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        {/* Detail panel */}
        {showDetails && selectedAnomaly && (
          <div style={{ flex: 1, padding: 16, backgroundColor: '#fafafa', borderRadius: 8, border: '1px solid #e0e0e0' }}>
            <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 12 }}>
              <h3 style={{ margin: 0 }}>Anomaly #{selectedAnomaly.id}</h3>
              <button
                onClick={() => { setShowDetails(false); setSelectedAnomaly(null); }}
                style={{ background: 'none', border: 'none', fontSize: 18, cursor: 'pointer' }}
              >
                ✕
              </button>
            </div>
            <div style={{ display: 'grid', gap: 8, fontSize: '0.9em' }}>
              <div><strong>Segment:</strong> {selectedAnomaly.pipeSegmentName}</div>
              <div><strong>Type:</strong> {selectedAnomaly.anomalyType}</div>
              <div><strong>Severity:</strong> {selectedAnomaly.severity}</div>
              <div><strong>Depth:</strong> {selectedAnomaly.depthPercent}%</div>
              <div><strong>Dimensions:</strong> {selectedAnomaly.lengthMm}mm × {selectedAnomaly.widthMm}mm</div>
              <div><strong>Clock Position:</strong> {selectedAnomaly.clockPosition || 'N/A'}</div>
              <div><strong>Distance from Upstream:</strong> {selectedAnomaly.distanceFromUpstreamKP} KP</div>
              <div><strong>Repair Required:</strong> {selectedAnomaly.repairRequired ? 'Yes' : 'No'}</div>
              {selectedAnomaly.repairDeadline && (
                <div><strong>Repair Deadline:</strong> {new Date(selectedAnomaly.repairDeadline).toLocaleDateString()}</div>
              )}
            </div>
          </div>
        )}
      </div>
    </div>
  );
}
