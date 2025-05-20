import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";
import { Bar } from "react-chartjs-2";
import { ChartOptions } from "chart.js";

const GraphicArea: React.FC<ChartProps> = (props) => {
    const CartAbandonmentRateBarOptions: ChartOptions<"bar"> = {
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
                    callback(value: any) {
                        return typeof value === "number" ? this.getLabelForValue(value) : "";
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
        <div className="cart-abandontment-rate-chart">
            {props.isLoading ? (
                <div className="cart-abandontment-rate-chart__loading-spinner">Loading...</div>
            ) : (
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
                    options={CartAbandonmentRateBarOptions}
                />
            )}
        </div>
    );
};

const CartAbandontmentRateBarChart = withChartHeader(GraphicArea);
export default CartAbandontmentRateBarChart;
