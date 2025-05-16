import React, { useEffect, useState } from "react";
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
    Filler,
    BarElement,
} from "chart.js";
import "./app.scss";
import DashboardModal from "./components/shared/dashboard-modal/dashboard-modal";
import { ChartModel } from "./components/charts/chart-model";
import CartAbandontmentRateChart from "./components/charts/cart-abandontment-rate-chart/cart-abandontment-rate-chart";
import { CustomChartType } from "./components/shared/utils";
import { CartAbandonmentRateOptions } from "./components/charts/cart-abandontment-rate-chart/cart-abandonment-rate-options";
import dayjs from "dayjs";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [customChartType, setCustomChartType] = useState<CustomChartType | undefined>(undefined);
    const [cartAbandonmentRate, setCartAbandonmentRate] = useState<ChartModel>({} as ChartModel);
    const [isCartAbandonmentRateLoading, setIsCartAbandonmentRateLoading] = useState<boolean>(true);

    useEffect(() => {
        const cartAbandonmentRateData = {
            avgRate: 0.5,
            avgComparedRate: 0.3,
            ratesByTime: [
                {
                    time: dayjs("May 16, 2025 12:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 01:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 02:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 03:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 04:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 05:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 06:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 07:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 08:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 09:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 10:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 11:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 12:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 01:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 02:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 03:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 04:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 05:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 06:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 07:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 08:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 09:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 16, 2025 10:00 PM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
                {
                    time: dayjs("May 17, 2025 12:00 AM").format("YYYY-MM-DD HH:mm:ss"),
                    rate: Math.random(),
                },
            ],
        };

        const cartAbandonmentRateModel: ChartModel = {
            charType: CustomChartType.CartAbandonmentRateChart,
            title: "Cart Abandonment Rate",
            generalValue: `${cartAbandonmentRateData.avgRate * 100}`,
            labels: cartAbandonmentRateData.ratesByTime.map((item) => item.time),
            datasets: [
                {
                    data: cartAbandonmentRateData.ratesByTime.map((item) => item.rate),
                    borderWidth: 2,
                    borderColor: ["#B3C3FF"],
                    tension: 0.1,
                    pointRadius: 0,
                },
            ],
        };

        setCartAbandonmentRate(cartAbandonmentRateModel);
        setIsCartAbandonmentRateLoading(false);
    }, []);

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter"></div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <div className="dashboard-app__row">
                    <div className="dashboard-app__column">
                        <CartAbandontmentRateChart
                            chart={cartAbandonmentRate}
                            isLoading={isCartAbandonmentRateLoading}
                            isFullScreen={false}
                            setFullScreenChartType={setCustomChartType}
                            options={CartAbandonmentRateOptions}
                        />
                    </div>
                </div>
            </div>
            <div className="dashboard-app__modal">
                <DashboardModal
                    customChartType={customChartType}
                    onClose={() => {
                        setCustomChartType(undefined);
                    }}
                    title="Modal Title"
                >
                    {(() => {
                        switch (customChartType) {
                            case CustomChartType.CartAbandonmentRateChart:
                                return (
                                    <CartAbandontmentRateChart
                                        chart={cartAbandonmentRate}
                                        isLoading={isCartAbandonmentRateLoading}
                                        isFullScreen={true}
                                        setFullScreenChartType={setCustomChartType}
                                        options={CartAbandonmentRateOptions}
                                    />
                                );
                            default:
                                return <p>No data</p>;
                        }
                    })()}
                </DashboardModal>
            </div>
        </div>
    );
};

export default App;
