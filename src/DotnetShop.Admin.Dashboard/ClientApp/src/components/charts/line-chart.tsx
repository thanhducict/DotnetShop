import React from "react";
import withChartHeader, { ChartProps } from "./chart-layout/chart-layout";
import { Line } from "react-chartjs-2";

interface LineChartProps extends ChartProps {
    isLoading: boolean;
}

const GraphicArea: React.FC<LineChartProps> = (props) => {
    return (
        <div className="line-chart">
            {props.isLoading ? (
                <div className="line-chart__loading-spinner">Loading...</div>
            ) : (
                <Line
                    data={{
                        labels: props.chart.label,
                        datasets: props.chart.datasets,
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
