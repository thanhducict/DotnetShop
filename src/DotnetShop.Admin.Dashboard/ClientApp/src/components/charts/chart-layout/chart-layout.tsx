import React from "react";
import Ellipsis from "../../../icons/more-horizontal.svg";
import "./chart-layout.scss";

export interface ChartProps {
    title: string;
    generalValue: string;
    comparisonValue?: string;
}

const withChartHeader = <P extends ChartProps>(WrappedComponent: React.ComponentType<P>) => {
    const ComponentWithHeader: React.FC<P> = (props) => {
        return (
            <div className="chart-container">
                <div className="chart-container__header">
                    <div className="cart-abandonment-tile">{props.title}</div>
                    <div className="cart-abandonment-ellipsis">
                        <Ellipsis />
                    </div>
                </div>
                <div className="chart-container__general-value">
                    {props.generalValue}
                    {props.comparisonValue && <div>{props.comparisonValue}</div>}
                </div>
                <div className="chart-container__body">
                    <WrappedComponent {...(props as P)} />
                </div>
            </div>
        );
    };

    return ComponentWithHeader;
};

export default withChartHeader;
