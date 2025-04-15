import React from "react";
import { useState } from "react";
import { Data } from "./components/charts/cart-abandonment-rate/mock-data";
import "./App.scss";
import CartAbandonmentRate from "./components/charts/cart-abandonment-rate/cart-abandonment-rate";

const App: React.FC = () => {
    const [chartData, setChartData] = useState({
        labels: Data.map((data: any) => data.year),
        datasets: [
            {
                label: "Users Gained ",
                data: Data.map((data: any) => data.userGain),
                backgroundColor: ["#1B41FF1A"],
                borderColor: "#B3C3FF",
                borderWidth: 2,
                fill: true,
                tension: 0.5,
                pointRadius: 0,
            },
        ],
    });

    return (
        <div className="dashboard-app">
            <h2>Dashboard</h2>
            <div className="dashboard-app__filter"></div>
            <div className="dashboard-app__summary"></div>
            <div className="dashboard-app__chart-area">
                <CartAbandonmentRate
                    title="Cart Abandonment Rate"
                    generalValue="3.52%"
                    comparisonValue="-1.14 (33%)"
                    demo="This is where the cart abandonment rate chart will be displayed."
                />
            </div>
        </div>
    );
};

export default App;
