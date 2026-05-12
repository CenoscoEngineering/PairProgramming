import { useState, useEffect } from 'react';
import { Inspection } from '../types';

function ActionButtons({
  inspectionId,
  onSelect,
  onDelete,
  selectedId,
}: {
  inspectionId: number;
  onSelect: (id: number) => void;
  onDelete: (id: number) => void;
  selectedId: number | null;
}) {
  return (
    <div style={{ display: 'flex', gap: 4 }}>
      <button
        style={{ backgroundColor: selectedId === inspectionId ? '#4CAF50' : '#2196F3', color: 'white', border: 'none', padding: '4px 8px', cursor: 'pointer' }}
        onClick={() => onSelect(inspectionId)}
      >
        {selectedId === inspectionId ? 'Selected' : 'Select'}
      </button>
      <button
        style={{ backgroundColor: '#f44336', color: 'white', border: 'none', padding: '4px 8px', cursor: 'pointer' }}
        onClick={() => onDelete(inspectionId)}
      >
        Delete
      </button>
    </div>
  );
}

function InspectionRow({
  inspection,
  index,
  onSelect,
  onDelete,
  onFilter,
  selectedId,
}: {
  inspection: Inspection;
  index: number;
  onSelect: (id: number) => void;
  onDelete: (id: number) => void;
  onFilter: (field: string, value: string) => void;
  selectedId: number | null;
}) {
  return (
    <tr
      id={'inspection-' + inspection.id}
      style={{
        backgroundColor: selectedId === inspection.id ? '#e8f5e9' : index % 2 === 0 ? '#ffffff' : '#f5f5f5',
      }}
    >
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{inspection.id}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{inspection.pipeSegmentName}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{inspection.pipelineName}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{new Date(inspection.inspectionDate).toLocaleDateString()}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>
        <span
          style={{ cursor: 'pointer', textDecoration: 'underline', color: '#1976d2' }}
          onClick={() => onFilter('inspectionType', inspection.inspectionType)}
        >
          {inspection.inspectionType}
        </span>
      </td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>
        <span
          style={{
            padding: '2px 8px',
            borderRadius: '12px',
            backgroundColor: inspection.status === 'Completed' ? '#c8e6c9' : inspection.status === 'In Progress' ? '#fff9c4' : '#ffcdd2',
            fontSize: '0.85em',
          }}
        >
          {inspection.status}
        </span>
      </td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{inspection.inspector}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>{inspection.anomalyCount}</td>
      <td style={{ padding: '8px', borderBottom: '1px solid #ddd' }}>
        <ActionButtons
          inspectionId={inspection.id}
          onSelect={onSelect}
          onDelete={onDelete}
          selectedId={selectedId}
        />
      </td>
    </tr>
  );
}

function InspectionTable({
  inspections,
  onSelect,
  onDelete,
  onFilter,
  selectedId,
}: {
  inspections: Inspection[];
  onSelect: (id: number) => void;
  onDelete: (id: number) => void;
  onFilter: (field: string, value: string) => void;
  selectedId: number | null;
}) {
  return (
    <table style={{ width: '100%', borderCollapse: 'collapse', marginTop: 10 }}>
      <thead>
        <tr style={{ backgroundColor: '#e0e0e0' }}>
          <th style={{ padding: '8px', textAlign: 'left' }}>ID</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Segment</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Pipeline</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Date</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Type</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Status</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Inspector</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Anomalies</th>
          <th style={{ padding: '8px', textAlign: 'left' }}>Actions</th>
        </tr>
      </thead>
      <tbody>
        {inspections.map((inspection, index) => (
          <InspectionRow
            key={index}
            inspection={inspection}
            index={index}
            onSelect={onSelect}
            onDelete={onDelete}
            onFilter={onFilter}
            selectedId={selectedId}
          />
        ))}
      </tbody>
    </table>
  );
}

export default function InspectionList() {
  const [inspections, setInspections] = useState<Inspection[]>([]);
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [filterType, setFilterType] = useState<string>('');
  const [filterStatus, setFilterStatus] = useState<string>('');
  const [sortDateAsc, setSortDateAsc] = useState<boolean>(true);
  const [searchTerm, setSearchTerm] = useState<string>('');

  useEffect(() => {
    fetch('/api/inspections')
      .then((res) => res.json())
      .then((data) => setInspections(data));
  }, []);

  const handleSelect = (id: number) => {
    setSelectedId(id);
    document.getElementById('inspection-' + id)?.scrollIntoView({ behavior: 'smooth', block: 'center' });
  };

  const handleDelete = (id: number) => {
    setInspections(inspections.filter((i) => i.id !== id));
    if (selectedId === id) {
      setSelectedId(null);
    }
  };

  const handleFilter = (field: string, value: string) => {
    if (field === 'inspectionType') {
      setFilterType(value);
    } else if (field === 'status') {
      setFilterStatus(value);
    }
  };

  const filtered = inspections
    .filter((i) => (filterType ? i.inspectionType === filterType : true))
    .filter((i) => (filterStatus ? i.status === filterStatus : true))
    .filter((i) =>
      searchTerm
        ? i.pipeSegmentName.toLowerCase().includes(searchTerm.toLowerCase()) ||
          i.inspector.toLowerCase().includes(searchTerm.toLowerCase()) ||
          i.pipelineName.toLowerCase().includes(searchTerm.toLowerCase())
        : true,
    )
    .sort((a, b) => {
      const dateA = new Date(a.inspectionDate).getTime();
      const dateB = new Date(b.inspectionDate).getTime();
      return sortDateAsc ? dateA - dateB : dateB - dateA;
    });

  const inspectionTypes = [...new Set(inspections.map((i) => i.inspectionType))];
  const statuses = [...new Set(inspections.map((i) => i.status))];

  return (
    <div style={{ padding: 20 }}>
      <h1 style={{ marginBottom: 10 }}>Inspection List</h1>

      {/* Filter controls */}
      <div style={{ display: 'flex', gap: 12, marginBottom: 16, flexWrap: 'wrap', alignItems: 'center' }}>
        <input
          type="text"
          placeholder="Search by segment, pipeline, or inspector..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4, minWidth: 260 }}
        />

        <select
          value={filterType}
          onChange={(e) => setFilterType(e.target.value)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4 }}
        >
          <option value="">All Types</option>
          {inspectionTypes.map((t, i) => (
            <option key={i} value={t}>
              {t}
            </option>
          ))}
        </select>

        <select
          value={filterStatus}
          onChange={(e) => setFilterStatus(e.target.value)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4 }}
        >
          <option value="">All Statuses</option>
          {statuses.map((s, i) => (
            <option key={i} value={s}>
              {s}
            </option>
          ))}
        </select>

        <button
          onClick={() => setSortDateAsc(!sortDateAsc)}
          style={{ padding: '6px 12px', border: '1px solid #ccc', borderRadius: 4, cursor: 'pointer' }}
        >
          Sort by Date {sortDateAsc ? '↑' : '↓'}
        </button>

        <span style={{ marginLeft: 'auto', color: '#666' }}>
          Showing {filtered.length} of {inspections.length} inspections
        </span>
      </div>

      {/* Selected inspection detail */}
      {selectedId && (
        <div style={{ padding: 12, marginBottom: 16, backgroundColor: '#e3f2fd', borderRadius: 4, border: '1px solid #90caf9' }}>
          <strong>Selected Inspection #{selectedId}</strong>
          {(() => {
            const sel = inspections.find((i) => i.id === selectedId);
            if (!sel) return null;
            return (
              <div style={{ marginTop: 8 }}>
                <div>Pipeline: {sel.pipelineName} — Segment: {sel.pipeSegmentName}</div>
                <div>Inspector: {sel.inspector} — Date: {new Date(sel.inspectionDate).toLocaleDateString()}</div>
                <div>Notes: {sel.notes || 'None'}</div>
              </div>
            );
          })()}
        </div>
      )}

      <InspectionTable
        inspections={filtered}
        onSelect={handleSelect}
        onDelete={handleDelete}
        onFilter={handleFilter}
        selectedId={selectedId}
      />
    </div>
  );
}
