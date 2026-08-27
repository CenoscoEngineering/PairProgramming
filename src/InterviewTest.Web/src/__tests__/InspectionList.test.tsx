import { render, screen } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import InspectionList from '../components/InspectionList';

/**
 * CODE REVIEW: These tests contain several test smells. Can you identify them?
 */

const mockInspections = [
  {
    id: 1, pipeSegmentId: 1, pipeSegmentName: 'NTL-SEG-001', pipelineName: 'Northern Trunk Line',
    inspectionDate: '2024-01-15', inspectionType: 'ILI', inspector: 'John Smith',
    status: 'Completed', notes: 'Test notes', anomalyCount: 2
  },
  {
    id: 2, pipeSegmentId: 2, pipeSegmentName: 'NTL-SEG-002', pipelineName: 'Northern Trunk Line',
    inspectionDate: '2024-02-10', inspectionType: 'UT', inspector: 'Jane Doe',
    status: 'Completed', notes: null, anomalyCount: 1
  }
];

beforeEach(() => {
  (global as any).fetch = vi.fn(() =>
    Promise.resolve({
      ok: true,
      json: () => Promise.resolve(mockInspections),
    })
  );
});


describe('InspectionList', () => {
  it('renders the component', () => {
    const { container } = render(<InspectionList />);
    const wrapper = container.querySelector('.inspection-list-wrapper');
    expect(wrapper || container.firstChild).toBeTruthy();
  });

  it('matches snapshot', () => {
    const { container } = render(<InspectionList />);
    expect(container).toMatchSnapshot();
  });

  it('renders inspection heading', () => {
    render(<InspectionList />);
    expect(screen.getByText('Inspection List')).toBeTruthy();
  });

  it('has filter dropdowns', () => {
    const { container } = render(<InspectionList />);
    const selects = container.querySelectorAll('select');
    expect(selects.length).toBeGreaterThan(0);
  });
});
