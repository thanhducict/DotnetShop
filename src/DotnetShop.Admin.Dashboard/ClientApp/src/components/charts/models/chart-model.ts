import { CustomChartType } from "../../shared/utils";

export interface ChartModel {
    charType: CustomChartType;
    title: string;
    generalValue: string;
    comparisonValue?: string;
    labels: string[];
    data: number[];
}
