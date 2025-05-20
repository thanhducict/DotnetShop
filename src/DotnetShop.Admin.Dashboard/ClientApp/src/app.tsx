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
import { CartAbandonmentRateModel } from "./components/charts/cart-abandontment-rate-chart/cart-abandonment-rate-model";
import SessionsLineChart from "./components/charts/cart-session-chart/sessions-line-chart";
import { Session } from "./components/charts/cart-session-chart/sessions-model";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [isComparisonMode, setIsComparisonMode] = useState<boolean>(false);
    const [customChartType, setCustomChartType] = useState<CustomChartType | undefined>(undefined);
    const [cartAbandonmentRate, setCartAbandonmentRate] = useState<ChartModel>({} as ChartModel);
    const [isCartAbandonmentRateLoading, setIsCartAbandonmentRateLoading] = useState<boolean>(true);
    const [sessions, setSessions] = useState<ChartModel>({} as ChartModel);
    const [isSessionsLoading, setSessionsLoading] = useState<boolean>(true);

    useEffect(() => {
        const cartAbandonmentRateData: CartAbandonmentRateModel = {
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
                data: [3, 0.5],
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

        const sessionsData: Session = {
            totalSessions: 1000,
            totalComparedSessions: 300,
            sessionsByTime: [
                { time: "May 16, 2025 12:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 01:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 02:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 03:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 04:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 05:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 06:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 07:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 08:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 09:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 10:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 11:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 12:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 01:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 02:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 03:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 04:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 05:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 06:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 07:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 08:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 09:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 10:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
                { time: "May 16, 2025 11:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            ],
        };

        let sessionsModel: ChartModel;

        if (isComparisonMode) {
            sessionsModel = {
                charType: CustomChartType.Sessions,
                title: "Sessions",
                generalValue: `${sessionsData.totalSessions}`,
                comparisonValue: `${sessionsData.totalComparedSessions}`,
                labels: ["Last Year", "June 15, 2025 - July 15, 2025"],
                data: [3, 0.5],
            };
        } else {
            sessionsModel = {
                charType: CustomChartType.Sessions,
                title: "Sessions",
                generalValue: `${sessionsData.totalSessions}`,
                labels: sessionsData.sessionsByTime.map((item) => item.time),
                data: sessionsData.sessionsByTime.map((item) => item.sessionCount),
            };
        }

        setCartAbandonmentRate(cartAbandonmentRateModel);
        setIsCartAbandonmentRateLoading(false);

        setSessions(sessionsModel);
        setSessionsLoading(false);
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
                    <div className="dashboard-app__column">
                        {isComparisonMode ? (
                            <></>
                        ) : (
                            <SessionsLineChart
                                chart={sessions}
                                isLoading={isSessionsLoading}
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
                            case CustomChartType.Sessions:
                                return (
                                    <>
                                        {isComparisonMode ? (
                                            <></>
                                        ) : (
                                            <SessionsLineChart
                                                chart={cartAbandonmentRate}
                                                isLoading={isSessionsLoading}
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
