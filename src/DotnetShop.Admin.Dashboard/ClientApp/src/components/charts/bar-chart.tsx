import React from "react";
import withChartHeader, { ChartHeaderProps } from "./chart-layout/chart-layout";
import { Bar } from "react-chartjs-2";

interface BarChartProps extends ChartHeaderProps {
    isLoading: boolean;
    label: string[];
    datasets: any;
    options?: any;
}

const GraphicArea: React.FC<BarChartProps> = (props) => {
    return (
        <div className="bar-chart">
            {props.isLoading ? (
                <div className="bar-chart__loading-spinner">Loading...</div>
            ) : (
                <Bar
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

const BarChart = withChartHeader(GraphicArea);
export default BarChart;
