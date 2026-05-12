export interface Pipeline {
  id: number;
  name: string;
  operatorName: string;
  material: string;
  diameterInches: number;
  lengthKm: number;
  maxOperatingPressurePsi: number;
  installationDate: string;
  status: string;
  segmentCount: number;
}

export interface PipeSegment {
  id: number;
  pipelineId: number;
  segmentName: string;
  startKP: number;
  endKP: number;
  wallThicknessNominalMm: number;
  wallThicknessMeasuredMm: number;
  coatingType: string;
  soilType: string;
  inspectionCount: number;
  anomalyCount: number;
}

export interface PipelineDetail {
  id: number;
  name: string;
  operatorName: string;
  material: string;
  diameterInches: number;
  lengthKm: number;
  maxOperatingPressurePsi: number;
  installationDate: string;
  status: string;
  segments: PipeSegment[];
}

export interface Inspection {
  id: number;
  pipeSegmentId: number;
  pipeSegmentName: string;
  pipelineName: string;
  inspectionDate: string;
  inspectionType: string;
  inspector: string;
  status: string;
  notes: string;
  anomalyCount: number;
}

export interface Anomaly {
  id: number;
  inspectionId: number;
  pipeSegmentId: number;
  pipeSegmentName: string;
  anomalyType: string;
  severity: string;
  depthPercent: number;
  lengthMm: number;
  widthMm: number;
  clockPosition: string;
  distanceFromUpstreamKP: number;
  repairRequired: boolean;
  repairDeadline: string | null;
}
