import React, { useState } from "react";
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
import "./App.scss";
import LineChart from "./components/charts/line-chart";
import BarChart from "./components/charts/bar-chart";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isFullScreen, setIsFullScreen] = useState<boolean>(false);

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter"></div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <div className="dashboard-app__row">
                    <div className="dashboard-app__column">
                        <LineChart
                            title="Sessions"
                            generalValue="120"
                            comparisonValue="+90 (200%)"
                            label={["12:00 AM", "4:00 AM", "8:00 AM", "12:00 PM", "4:00 PM", "8:00 PM"]}
                            datasets={[
                                {
                                    data: [0, 25, 30, 50, 40, 150],
                                    borderWidth: 2,
                                    borderColor: "#B3C3FF",
                                    tension: 0.1,
                                    pointRadius: 0,
                                },
                            ]}
                            isFullScreen={isFullScreen}
                            isLoading={isLoading}
                        />
                    </div>
                    <div className="dashboard-app__column">
                        <BarChart
                            title="Sessions"
                            generalValue="120"
                            comparisonValue="+90 (200%)"
                            label={["2024", "May 2025"]}
                            datasets={[
                                {
                                    data: [30, 120],
                                    backgroundColor: ["#B3C3FF", "#0037FF"],
                                    borderColor: ["#B3C3FF", "#0037FF"],
                                    borderWidth: 1,
                                    maxBarThickness: 70,
                                },
                            ]}
                            isFullScreen={isFullScreen}
                            isLoading={isLoading}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default App;
