import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";
import { Line } from "react-chartjs-2";
import { deepMerge, sharedOptions } from "../../shared/utils";

const GraphicArea: React.FC<ChartProps> = (props) => {
    const getOptions = () => {
        let options = deepMerge(sharedOptions, props.options);

        if (props.isFullScreen) {
            options = deepMerge(options, {
                scales: {
                    x: {
                        grid: {
                            drawOnChartArea: true,
                        },
                        ticks: {
                            maxTicksLimit: 24,
                        },
                    },
                },
            });

            return options;
        } else {
            return options;
        }
    };

    return (
        <div className="cart-abandontment-rate-chart">
            {props.isLoading ? (
                <div className="cart-abandontment-rate-chart__loading-spinner">Loading...</div>
            ) : (
                <Line
                    data={{
                        labels: props.chart.labels,
                        datasets: props.chart.datasets,
                    }}
                    height={350}
                    options={getOptions()}
                />
            )}
        </div>
    );
};

const CartAbandontmentRateChart = withChartHeader(GraphicArea);
export default CartAbandontmentRateChart;
