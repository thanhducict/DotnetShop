export interface ChartModel {
    charType: ChartType;
    title: string;
    generalValue: string;
    comparisonValue?: string;
    label: string[];
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

export enum ChartType {
    LINE = "line",
    BAR = "bar",
    AREA = "area",
    PIE = "pie",
    DOUGHNUT = "doughnut",
    RADAR = "radar",
    POLAR_AREA = "polarArea",
    BUBBLE = "bubble",
    SCATTER = "scatter",
}
