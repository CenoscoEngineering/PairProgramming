import React from 'react';

/**
 * PipelineOverview Component — CANDIDATE IMPLEMENTS THIS
 *
 * Requirements:
 * 1. Fetch and display a list of pipelines from GET /api/pipelines
 * 2. Show each pipeline's name, operator, material, diameter, length, status, and segment count
 * 3. Display in a table or card layout
 * 4. Show a loading state while fetching
 * 5. Show an error message if the fetch fails
 * 6. Clicking a pipeline row/card could navigate to detail (bonus)
 *
 * The API service is already set up in '../services/api' with a getPipelines() function.

 */

const PipelineOverview: React.FC = () => {
  // TODO: Implement this component
  // 1. Use useState for pipelines, loading, and error state
  // 2. Use useEffect to fetch pipelines on mount
  // 3. Render a loading indicator while fetching
  // 4. Render an error message if fetch fails
  // 5. Render the pipeline list in a table

  return (
    <div>
      <h2>Pipeline Overview</h2>
      <p>TODO: Implement this component</p>
    </div>
  );
};

export default PipelineOverview;
