import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";
import { Bar } from "react-chartjs-2";
import { ChartOptions } from "chart.js";

const GraphicArea: React.FC<ChartProps> = (props) => {
    const drawOnChartAreaX = props.isFullScreen ? true : false;

    const BarOptions: ChartOptions<"bar"> = {
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
                    drawOnChartArea: drawOnChartAreaX,
                },
                ticks: {
                    align: "center",
                    maxRotation: 0,
                },
            },
            y: {
                grid: {
                    drawOnChartArea: true,
                },
                min: 0,
            },
        },
    };

    return (
        <Bar
            data={{
                labels: props.chart.labels,
                datasets: [
                    {
                        data: props.chart.data,
                        borderWidth: 0,
                        backgroundColor: ["#B3C3FF", "#0037FF"],
                        maxBarThickness: 70,
                    },
                ],
            }}
            height={350}
            options={BarOptions}
        />
    );
};

const BarChart = withChartHeader(GraphicArea);
export default BarChart;
