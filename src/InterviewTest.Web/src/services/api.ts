import type { Pipeline, PipelineDetail, Inspection, Anomaly, PipeSegment } from '../types';

const API_BASE = '/api';

async function fetchJson<T>(url: string): Promise<T> {
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error(`API error: ${response.status} ${response.statusText}`);
  }
  return response.json() as Promise<T>;
}

function buildQuery(params: Record<string, string | number | undefined>): string {
  const entries = Object.entries(params).filter(
    ([, v]) => v !== undefined && v !== null && v !== ''
  );
  if (entries.length === 0) return '';
  return '?' + new URLSearchParams(entries.map(([k, v]) => [k, String(v)])).toString();
}

export function getPipelines(): Promise<Pipeline[]> {
  return fetchJson<Pipeline[]>(`${API_BASE}/pipelines`);
}

export function getPipelineById(id: number): Promise<PipelineDetail> {
  return fetchJson<PipelineDetail>(`${API_BASE}/pipelines/${id}`);
}

export function getInspections(params?: { type?: string; status?: string }): Promise<Inspection[]> {
  const query = params ? buildQuery(params) : '';
  return fetchJson<Inspection[]>(`${API_BASE}/inspections${query}`);
}

export function getAnomalies(params?: { type?: string; severity?: string }): Promise<Anomaly[]> {
  const query = params ? buildQuery(params) : '';
  return fetchJson<Anomaly[]>(`${API_BASE}/anomalies${query}`);
}

export function getPipeSegments(params?: {
  pipelineId?: number;
  search?: string;
  page?: number;
}): Promise<PipeSegment[]> {
  const query = params ? buildQuery(params) : '';
  return fetchJson<PipeSegment[]>(`${API_BASE}/pipesegments${query}`);
}
