import { render, screen, waitFor } from '@testing-library/react';
import { describe, it, expect, vi, beforeEach, afterEach } from 'vitest';
import PipelineOverview from '../components/PipelineOverview';
import * as api from '../services/api';
import type { Pipeline } from '../types';

/**
 * Tests for PipelineOverview component — CANDIDATE FILLS IN TEST BODIES
 *
 * Instructions:
 * 1. Fill in the test method bodies below
 * 2. Run the tests to verify they fail (Red)
 * 3. Then implement the component to make them pass (Green)
 * 4. Refactor if needed
 *
 * The api module is already imported and can be mocked with vi.spyOn.
 * Use the mockPipelines array as test data.
 */

const mockPipelines: Pipeline[] = [
  {
    id: 1,
    name: 'Northern Trunk Line',
    operatorName: 'NorthSea Energy',
    material: 'Carbon Steel',
    diameterInches: 36,
    lengthKm: 142.5,
    maxOperatingPressurePsi: 1440,
    installationDate: '1998-06-15T00:00:00',
    status: 'Active',
    segmentCount: 4,
  },
  {
    id: 2,
    name: 'Southern Export Pipeline',
    operatorName: 'Gulf Pipelines Ltd',
    material: 'Carbon Steel',
    diameterInches: 24,
    lengthKm: 87.3,
    maxOperatingPressurePsi: 1200,
    installationDate: '2005-03-22T00:00:00',
    status: 'Active',
    segmentCount: 3,
  },
];

describe('PipelineOverview', () => {
  afterEach(() => {
    vi.restoreAllMocks();
  });

  describe('Loading State', () => {
    it('shows a loading indicator while fetching pipelines', () => {
      // TODO: Mock getPipelines to return a promise that doesn't resolve yet
      // TODO: Render the component
      // TODO: Assert that a loading indicator is visible

      throw new Error('Write this test first, then implement the component');
    });
  });

  describe('Success State', () => {
    it('renders pipeline data in a table after loading', async () => {
      // TODO: Mock getPipelines to resolve with mockPipelines
      // TODO: Render the component
      // TODO: Wait for the data to load
      // TODO: Assert that pipeline names appear in the document

      throw new Error('Write this test first, then implement the component');
    });

    it('displays the heading "Pipeline Overview"', async () => {
      // TODO: Mock getPipelines to resolve with mockPipelines
      // TODO: Render the component
      // TODO: Assert that the heading is present

      throw new Error('Write this test first, then implement the component');
    });

    it('displays operator, status, and segment count for each pipeline', async () => {
      // TODO: Mock getPipelines to resolve with mockPipelines
      // TODO: Render the component
      // TODO: Wait for data to load
      // TODO: Assert that operator names, statuses, and segment counts are visible

      throw new Error('Write this test first, then implement the component');
    });
  });

  describe('Error State', () => {
    it('shows an error message when the API call fails', async () => {
      // TODO: Mock getPipelines to reject with an error
      // TODO: Render the component
      // TODO: Wait for the error to appear
      // TODO: Assert that an error message is displayed

      throw new Error('Write this test first, then implement the component');
    });
  });

  describe('Empty State', () => {
    it('shows a message when no pipelines are returned', async () => {
      // TODO: Mock getPipelines to resolve with an empty array
      // TODO: Render the component
      // TODO: Wait for data to load
      // TODO: Assert that a "no pipelines" message is shown

      throw new Error('Write this test first, then implement the component');
    });
  });
});
