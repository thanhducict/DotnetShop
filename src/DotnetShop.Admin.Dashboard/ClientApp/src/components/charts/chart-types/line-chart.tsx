import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";
import { Line } from "react-chartjs-2";
import { ChartOptions, LineOptions } from "chart.js";
import dayjs from "dayjs";
import * as _ from "lodash";

const GraphicArea: React.FC<ChartProps> = (props) => {
    const maxTicksLimit = props.isFullScreen ? 24 : 5;
    const pointRadius = props.isFullScreen ? 3 : 0;

    const LineOptions: ChartOptions<"line"> = {
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

    const options = props.extraOptions ? _.merge(LineOptions, props.extraOptions) : LineOptions;

    return (
        <Line
            data={{
                labels: props.chart.labels,
                datasets: [
                    {
                        data: props.chart.data,
                        borderWidth: 2,
                        borderColor: ["#B3C3FF"],
                        tension: 0.1,
                        pointRadius: pointRadius,
                    },
                ],
            }}
            height={350}
            options={options}
        />
    );
};

const LineChart = withChartHeader(GraphicArea);
export default LineChart;
