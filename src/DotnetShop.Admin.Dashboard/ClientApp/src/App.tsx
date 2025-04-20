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
import DashboardModal from "./components/shared/dashboard-modal/dashboard-modal";
import { ChartModel, ChartType } from "./components/charts/chart-model";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, BarElement, Title, Tooltip, Legend, Filler);

const App: React.FC = () => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isOpen, setIsOpen] = useState<boolean>(false);
    const [charts, setCharts] = useState<ChartModel[]>([
        {
            charType: ChartType.LINE,
            title: "Sessions",
            generalValue: "120",
            comparisonValue: "+90 (200%)",
            label: ["12:00 AM", "4:00 AM", "8:00 AM", "12:00 PM", "4:00 PM", "8:00 PM"],
            datasets: [
                {
                    data: [0, 25, 30, 50, 40, 150],
                    borderWidth: 2,
                    borderColor: ["#B3C3FF"],
                    tension: 0.1,
                    pointRadius: 0,
                },
            ],
        },
        {
            charType: ChartType.BAR,
            title: "Sessions",
            generalValue: "120",
            comparisonValue: "+90 (200%)",
            label: ["2024", "May 2025"],
            datasets: [
                {
                    data: [30, 120],
                    backgroundColor: ["#B3C3FF", "#0037FF"],
                    borderColor: ["#B3C3FF", "#0037FF"],
                    borderWidth: 1,
                    maxBarThickness: 70,
                },
            ],
        },
    ]);
    const [fullscreenChart, setFullscreenChart] = useState<ChartModel | null>(null);

    const generateChart = (chartModel: ChartModel | null, isFullScreen: boolean) => {
        switch (chartModel?.charType) {
            case ChartType.LINE:
                return (
                    <LineChart
                        chart={chartModel}
                        isFullScreen={isFullScreen}
                        isLoading={isLoading}
                        setIsOpen={setIsOpen}
                        setFulscreenChart={setFullscreenChart}
                    />
                );
            case ChartType.BAR:
                return (
                    <BarChart
                        chart={chartModel}
                        isFullScreen={isFullScreen}
                        isLoading={isLoading}
                        setIsOpen={setIsOpen}
                        setFulscreenChart={setFullscreenChart}
                    />
                );
            default:
                return <></>;
        }
    };

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter"></div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <div className="dashboard-app__row">
                    {charts.map((chartModel, index) => (
                        <div key={index} className="dashboard-app__column">
                            {generateChart(chartModel, false)}
                        </div>
                    ))}
                </div>
            </div>
            <div className="dashboard-app__modal">
                <DashboardModal
                    isOpen={isOpen}
                    onClose={() => {
                        setIsOpen(false);
                        setFullscreenChart(null);
                    }}
                    title="Modal Title"
                >
                    {generateChart(fullscreenChart, true)}
                </DashboardModal>
            </div>
        </div>
    );
};

export default App;
