import { ChartData } from "./chart-data.model";
import { ActualFab } from "./actual-fab.model";

export interface ChartResult {
  ProjectName?: string;
  Labels?: Array<string>;
  ReportDate?: Date;
  Status?: string;
  ChartData1s?: Array<ChartData>;
  ChartData2s?: Array<ChartData>;
  ActualFabTables?: Array<ActualFab>;
}
