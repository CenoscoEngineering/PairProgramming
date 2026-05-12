import { render, screen } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach } from 'vitest';
import InspectionList from '../components/InspectionList';

/**
 * CODE REVIEW: These tests contain several test smells. Can you identify them?
 */

// SMELL: Mocking fetch globally instead of using MSW or injecting a service
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

// SMELL: Replacing window.fetch globally — affects all tests and is hard to reset properly
beforeEach(() => {
  (global as any).fetch = vi.fn(() =>
    Promise.resolve({
      ok: true,
      json: () => Promise.resolve(mockInspections),
    })
  );
});

// SMELL: No afterEach cleanup — if a test fails, fetch mock leaks to other test files

describe('InspectionList', () => {
  it('renders the component', () => {
    // SMELL: Testing implementation details — checking for internal CSS classes
    const { container } = render(<InspectionList />);
    const wrapper = container.querySelector('.inspection-list-wrapper');
    // SMELL: This assertion is brittle — depends on exact class name that might change
    expect(wrapper || container.firstChild).toBeTruthy();
  });

  it('matches snapshot', () => {
    // SMELL: Snapshot abuse — large snapshot that breaks on ANY markup change
    // This tests nothing specific and creates maintenance burden
    const { container } = render(<InspectionList />);
    expect(container).toMatchSnapshot();
  });

  it('renders inspection heading', () => {
    render(<InspectionList />);
    // SMELL: This is the only test that uses proper accessible queries
    // but it only tests the heading text, not the actual data display
    expect(screen.getByText('Inspection List')).toBeTruthy();
  });

  it('has filter dropdowns', () => {
    // SMELL: No waitFor or findBy — component hasn't finished loading data yet
    // This test passes by accident because it only checks initial render
    const { container } = render(<InspectionList />);
    const selects = container.querySelectorAll('select');
    // SMELL: Querying by element type — fragile and non-semantic
    expect(selects.length).toBeGreaterThan(0);
  });

  // SMELL: No user interaction tests at all
  // Missing: test filtering, test sorting, test selecting an inspection, test delete
  // Missing: test loading state, test error state, test empty state
  // Missing: test with no inspections returned
});
