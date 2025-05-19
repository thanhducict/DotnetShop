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
import CartAbandontmentRateLineChart from "./components/charts/cart-abandontment-rate-chart/cart-abandontment-rate-line-chart";
import { CustomChartType } from "./components/shared/utils";
import CartAbandontmentRateBarChart from "./components/charts/cart-abandontment-rate-chart/cart-abandontment-rate-bar-chart";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [isComparisonMode, setIsComparisonMode] = useState<boolean>(false);
    const [customChartType, setCustomChartType] = useState<CustomChartType | undefined>(undefined);
    const [cartAbandonmentRate, setCartAbandonmentRate] = useState<ChartModel>({} as ChartModel);
    const [isCartAbandonmentRateLoading, setIsCartAbandonmentRateLoading] = useState<boolean>(true);

    useEffect(() => {
        const cartAbandonmentRateData = {
            avgRate: 0.5,
            avgComparedRate: 0.3,
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
                generalValue: `${cartAbandonmentRateData.avgRate * 100}`,
                labels: ["Last Year", "June 15, 2025 - July 15, 2025"],
                datasets: [
                    {
                        data: [3, 0.5],
                        borderWidth: 0,
                        backgroundColor: ["#B3C3FF", "#0037FF"],
                        tension: 0.1,
                        pointRadius: 0,
                        maxBarThickness: 70,
                    },
                ],
            };
        } else {
            cartAbandonmentRateModel = {
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
        }

        setCartAbandonmentRate(cartAbandonmentRateModel);
        setIsCartAbandonmentRateLoading(false);
    }, [isComparisonMode]);

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter">
                <button onClick={() => setIsComparisonMode(!isComparisonMode)}>
                    {isComparisonMode ? "Disable Comparison Mode" : "Enable Comparison Mode"}
                </button>
            </div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <div className="dashboard-app__row">
                    <div className="dashboard-app__column">
                        {isComparisonMode ? (
                            <CartAbandontmentRateBarChart
                                chart={cartAbandonmentRate}
                                isLoading={isCartAbandonmentRateLoading}
                                isFullScreen={false}
                                setFullScreenChartType={setCustomChartType}
                            />
                        ) : (
                            <CartAbandontmentRateLineChart
                                chart={cartAbandonmentRate}
                                isLoading={isCartAbandonmentRateLoading}
                                isFullScreen={false}
                                setFullScreenChartType={setCustomChartType}
                            />
                        )}
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
                                    <>
                                        {isComparisonMode ? (
                                            <CartAbandontmentRateBarChart
                                                chart={cartAbandonmentRate}
                                                isLoading={isCartAbandonmentRateLoading}
                                                isFullScreen={true}
                                                setFullScreenChartType={setCustomChartType}
                                            />
                                        ) : (
                                            <CartAbandontmentRateLineChart
                                                chart={cartAbandonmentRate}
                                                isLoading={isCartAbandonmentRateLoading}
                                                isFullScreen={true}
                                                setFullScreenChartType={setCustomChartType}
                                            />
                                        )}
                                    </>
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
