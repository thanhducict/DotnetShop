import React from "react";
import Chart from "chart.js/auto";
import { CategoryScale } from "chart.js";
import { useState } from "react";
import { Data } from "./Data";
import "./global-style.css";
import PieChart from "./components/PieChart";

Chart.register(CategoryScale);

const App: React.FC = () => {
    const [chartData, setChartData] = useState({
        labels: Data.map((data: any) => data.year),
        datasets: [
            {
                label: "Users Gained ",
                data: Data.map((data: any) => data.userGain),
                backgroundColor: ["rgba(75,192,192,1)", "&quot;#ecf0f1", "#50AF95", "#f3ba2f", "#2a71d0"],
                borderColor: "black",
                borderWidth: 2,
            },
        ],
    });

    return (
        <div className="App">
            <PieChart chartData={chartData} />
        </div>
    );
};

export default App;
