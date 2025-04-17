import React from "react";
import withChartHeader, { ChartHeaderProps } from "./chart-layout/chart-layout";
import { Line } from "react-chartjs-2";

interface LineChartProps extends ChartHeaderProps {
    isLoading: boolean;
    label: string[];
    datasets: any;
    options?: any;
}

const GraphicArea: React.FC<LineChartProps> = (props) => {
    return (
        <div className="line-chart">
            {props.isLoading ? (
                <div className="line-chart__loading-spinner">Loading...</div>
            ) : (
                <Line
                    data={{
                        labels: props.label,
                        datasets: props.datasets,
                    }}
                    height={350}
                    options={{
                        ...{
                            responsive: true,
                            maintainAspectRatio: false,
                            aspectRatio: 2,
                            plugins: {
                                legend: {
                                    display: false,
                                },
                            },
                            scales: {
                                x: {
                                    grid: {
                                        drawOnChartArea: false,
                                    },
                                },
                                y: {
                                    grid: {
                                        drawOnChartArea: true,
                                    },
                                },
                            },
                        },
                        ...props.options,
                    }}
                />
            )}
        </div>
    );
};

const LineChart = withChartHeader(GraphicArea);
export default LineChart;
