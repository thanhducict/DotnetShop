import React from "react";
import "./chart-layout.scss";
import ContextMenu from "../../shared/context-menu/context-menu";
import MaximizeIcon from "../../../icons/maximize.svg";
import DownloadIcon from "../../../icons/download.svg";
import { ChartModel } from "../chart-model";
import { CustomChartType } from "../../shared/utils";

export interface ChartProps {
    chart: ChartModel;
    options?: any;
    isLoading: boolean;
    isFullScreen: boolean;
    setFullScreenChartType: React.Dispatch<React.SetStateAction<CustomChartType | undefined>>;
}

const withChartHeader = <P extends ChartProps>(WrappedComponent: React.ComponentType<P>) => {
    const ComponentWithHeader: React.FC<P> = (props) => {
        return (
            <div className="chart-container">
                <div className="chart-container__header">
                    <div className="chart-header-tile">{props.chart.title}</div>
                    <div className="chart-header-ellipsis">
                        {props.isFullScreen ? (
                            <></>
                        ) : (
                            <ContextMenu
                                commands={[
                                    {
                                        iconUrl: MaximizeIcon,
                                        label: "View full screen",
                                        action: () => {
                                            props.setFullScreenChartType(props.chart.charType);
                                        },
                                    },
                                    {
                                        iconUrl: DownloadIcon,
                                        label: "Export as .CSV",
                                        action: () => {},
                                    },
                                ]}
                            />
                        )}
                    </div>
                </div>
                <div className="chart-container__general-value">
                    <p>{props.chart.generalValue}</p>
                    {props.chart.comparisonValue && (
                        <p style={props.chart.comparisonValue.includes("-") ? { color: "red" } : { color: "green" }}>
                            {props.chart.comparisonValue}
                        </p>
                    )}
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
