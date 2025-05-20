import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";
import { Line } from "react-chartjs-2";
import { ChartOptions } from "chart.js";
import dayjs from "dayjs";

const GraphicArea: React.FC<ChartProps> = (props) => {
    const drawOnChartAreaX = props.isFullScreen ? true : false;
    const maxTicksLimit = props.isFullScreen ? 24 : 5;

    const SessionsLineOptions: ChartOptions<"line"> = {
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
                    maxTicksLimit: maxTicksLimit,
                    callback(value: any) {
                        return typeof value === "number" ? dayjs(this.getLabelForValue(value)).format("hh:mm A") : "";
                    },
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
        <div className="sessions-chart">
            {props.isLoading ? (
                <div className="sessions-chart__loading-spinner">Loading...</div>
            ) : (
                <Line
                    data={{
                        labels: props.chart.labels,
                        datasets: [
                            {
                                data: props.chart.data,
                                borderWidth: 2,
                                borderColor: ["#B3C3FF"],
                                tension: 0.1,
                                pointRadius: 0,
                            },
                        ],
                    }}
                    height={350}
                    options={SessionsLineOptions}
                />
            )}
        </div>
    );
};

const SessionsLineChart = withChartHeader(GraphicArea);
export default SessionsLineChart;
