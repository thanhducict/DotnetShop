import { formatComparisonValue } from "../../app";
import { CustomChartType } from "../shared/utils";
import { CartAbandonmentRateModel } from "./models/cart-abandonment-rate-model";
import { ChartModel } from "./models/chart-model";

export const getCartAbandonmentRateMockData = (isComparisonMode: boolean) => {
    const cartAbandonmentRateData: CartAbandonmentRateModel = {
        avgRate: 0.5,
        avgComparedRate: 3.0,
        ratesByTime: [
            { time: "May 16, 2025 12:00 AM", rate: 0.42 },
            { time: "May 16, 2025 01:00 AM", rate: 0.38 },
            { time: "May 16, 2025 02:00 AM", rate: 0.51 },
            { time: "May 16, 2025 03:00 AM", rate: 0.47 },
            { time: "May 16, 2025 04:00 AM", rate: 0.1 },
            { time: "May 16, 2025 05:00 AM", rate: 0.49 },
            { time: "May 16, 2025 06:00 AM", rate: 0.53 },
            { time: "May 16, 2025 07:00 AM", rate: 0.41 },
            { time: "May 16, 2025 08:00 AM", rate: 0.46 },
            { time: "May 16, 2025 09:00 AM", rate: 0.52 },
            { time: "May 16, 2025 10:00 AM", rate: 0.2 },
            { time: "May 16, 2025 11:00 AM", rate: 0.48 },
            { time: "May 16, 2025 12:00 PM", rate: 0.5 },
            { time: "May 16, 2025 01:00 PM", rate: 0.39 },
            { time: "May 16, 2025 02:00 PM", rate: 0.54 },
            { time: "May 16, 2025 03:00 PM", rate: 0.43 },
            { time: "May 16, 2025 04:00 PM", rate: 0.56 },
            { time: "May 16, 2025 05:00 PM", rate: 0.45 },
            { time: "May 16, 2025 06:00 PM", rate: 0.51 },
            { time: "May 16, 2025 07:00 PM", rate: 0.3 },
            { time: "May 16, 2025 08:00 PM", rate: 0.53 },
            { time: "May 16, 2025 09:00 PM", rate: 0.4 },
            { time: "May 16, 2025 10:00 PM", rate: 0.55 },
            { time: "May 16, 2025 11:00 PM", rate: 0.05 },
        ],
    };

    let cartAbandonmentRateModel: ChartModel;

    if (isComparisonMode) {
        cartAbandonmentRateModel = {
            charType: CustomChartType.CartAbandonmentRateChart,
            title: "Cart Abandonment Rate",
            generalValue: `${cartAbandonmentRateData.avgRate}%`,
            comparisonValue: formatComparisonValue(
                cartAbandonmentRateData.avgRate,
                cartAbandonmentRateData.avgComparedRate
            ),
            labels: ["Last Year", "June 15, 2025 - July 15, 2025"],
            data: [0.5, 3],
        };
    } else {
        cartAbandonmentRateModel = {
            charType: CustomChartType.CartAbandonmentRateChart,
            title: "Cart Abandonment Rate",
            generalValue: `${cartAbandonmentRateData.avgRate * 100}`,
            labels: cartAbandonmentRateData.ratesByTime.map((item) => item.time),
            data: cartAbandonmentRateData.ratesByTime.map((item) => item.rate),
        };
    }

    return cartAbandonmentRateModel;
};
