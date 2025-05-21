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
import { CustomChartType } from "./components/shared/utils";
import { getCartAbandonmentRateMockData } from "./components/charts/cart-abandonment-rate-mock-data";
import { getSessionsMockData } from "./components/charts/sessions-mock-data";
import BarChart from "./components/charts/chart-types/bar-chart";
import LineChart from "./components/charts/chart-types/line-chart";
import { ChartModel } from "./components/charts/models/chart-model";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [isComparisonModel, setIsComparisonModel] = useState<boolean>(false);
    const [customChartType, setCustomChartType] = useState<CustomChartType | undefined>(undefined);
    const [cartAbandonmentRate, setCartAbandonmentRate] = useState<ChartModel>({} as ChartModel);
    const [isCartAbandonmentRateLoading, setIsCartAbandonmentRateLoading] = useState<boolean>(true);
    const [sessions, setSessions] = useState<ChartModel>({} as ChartModel);
    const [isSessionsLoading, setSessionsLoading] = useState<boolean>(true);

    useEffect(() => {
        const cartAbandonmentRateModel = getCartAbandonmentRateMockData(isComparisonModel);
        const sessionsModel = getSessionsMockData(isComparisonModel);

        setCartAbandonmentRate(cartAbandonmentRateModel);
        setIsCartAbandonmentRateLoading(false);

        setSessions(sessionsModel);
        setSessionsLoading(false);
    }, [isComparisonModel]);

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter">
                <button onClick={() => setIsComparisonModel(!isComparisonModel)}>
                    {isComparisonModel ? "Disable Comparison Mode" : "Enable Comparison Mode"}
                </button>
            </div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <div className="dashboard-app__row">
                    <div className="dashboard-app__column">
                        {isComparisonModel ? (
                            <BarChart
                                chart={sessions}
                                isLoading={isSessionsLoading}
                                isFullScreen={false}
                                setFullScreenChartType={setCustomChartType}
                            />
                        ) : (
                            <LineChart
                                chart={sessions}
                                isLoading={isSessionsLoading}
                                isFullScreen={false}
                                setFullScreenChartType={setCustomChartType}
                            />
                        )}
                    </div>
                    <div className="dashboard-app__column">
                        {isComparisonModel ? (
                            <BarChart
                                chart={cartAbandonmentRate}
                                isLoading={isCartAbandonmentRateLoading}
                                isFullScreen={false}
                                setFullScreenChartType={setCustomChartType}
                            />
                        ) : (
                            <LineChart
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
                                        {isComparisonModel ? (
                                            <BarChart
                                                chart={cartAbandonmentRate}
                                                isLoading={isCartAbandonmentRateLoading}
                                                isFullScreen={true}
                                                setFullScreenChartType={setCustomChartType}
                                            />
                                        ) : (
                                            <LineChart
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
                                        {isComparisonModel ? (
                                            <BarChart
                                                chart={sessions}
                                                isLoading={isSessionsLoading}
                                                isFullScreen={true}
                                                setFullScreenChartType={setCustomChartType}
                                            />
                                        ) : (
                                            <LineChart
                                                chart={sessions}
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
