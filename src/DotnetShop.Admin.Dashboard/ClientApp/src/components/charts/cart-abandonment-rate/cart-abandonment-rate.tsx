import React from "react";
import withChartHeader, { ChartProps } from "../chart-layout/chart-layout";

interface CartAbandonmentRateChartProps extends ChartProps {
    demo: string;
}

const CartAbandonmentRateChart: React.FC<CartAbandonmentRateChartProps> = (props) => {
    return (
        <div>
            <p>{props.demo}</p>
        </div>
    );
};

const CartAbandonmentRate = withChartHeader(CartAbandonmentRateChart);
export default CartAbandonmentRate;
