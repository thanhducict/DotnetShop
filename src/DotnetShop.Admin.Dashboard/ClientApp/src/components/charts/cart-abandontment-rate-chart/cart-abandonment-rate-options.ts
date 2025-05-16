import { ChartOptions } from "chart.js";
import dayjs from "dayjs";

export const CartAbandonmentRateOptions: ChartOptions = {
    scales: {
        x: {
            ticks: {
                align: "center",
                maxRotation: 0,
                maxTicksLimit: 5,
                callback(value) {
                    return typeof value === "number" ? dayjs(this.getLabelForValue(value)).format("hh:mm A") : "";
                },
            },
        },
        y: {
            min: 0,
            ticks: {
                maxTicksLimit: 10,
            },
        },
    },
};
