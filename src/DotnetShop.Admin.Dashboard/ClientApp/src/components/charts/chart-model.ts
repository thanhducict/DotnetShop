import { CustomChartType } from "../shared/utils";

export interface ChartModel {
    charType: CustomChartType;
    title: string;
    generalValue: string;
    comparisonValue?: string;
    labels: string[];
    datasets: {
        lable?: string;
        data: number[];
        backgroundColor?: string[];
        borderColor?: string[];
        borderWidth?: number;
        fill?: boolean;
        maxBarThickness?: number;
        tension?: number;
        pointRadius?: number;
    }[];
}
