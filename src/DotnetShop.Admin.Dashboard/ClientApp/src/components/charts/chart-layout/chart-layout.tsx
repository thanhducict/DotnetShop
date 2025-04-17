import React from "react";
import "./chart-layout.scss";
import ContextMenu from "../../shared/context-menu/context-menu";
import MaximizeIcon from "../../../icons/maximize.svg";
import DownloadIcon from "../../../icons/download.svg";

export interface ChartHeaderProps {
    title: string;
    generalValue: string;
    comparisonValue?: string;
    isFullScreen: boolean;
}

const withChartHeader = <P extends ChartHeaderProps>(WrappedComponent: React.ComponentType<P>) => {
    const ComponentWithHeader: React.FC<P> = (props) => {
        return (
            <div className="chart-container">
                <div className="chart-container__header">
                    <div className="chart-header-tile">{props.title}</div>
                    <div className="chart-header-ellipsis">
                        <ContextMenu
                            commands={[
                                {
                                    iconUrl: MaximizeIcon,
                                    label: "View full screen",
                                    action: () => {},
                                },
                                { iconUrl: DownloadIcon, label: "Export as .CSV", action: () => {} },
                            ]}
                        />
                    </div>
                </div>
                <div className="chart-container__general-value">
                    <p>{props.generalValue}</p>
                    {props.comparisonValue && (
                        <p style={props.comparisonValue.includes("-") ? { color: "red" } : { color: "green" }}>
                            {props.comparisonValue}
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
