import React, { useState } from "react";
import MoreHorizontal from "../../../icons/more-horizontal.svg";
import {
    autoUpdate,
    FloatingFocusManager,
    offset,
    shift,
    useClick,
    useDismiss,
    useFloating,
    useInteractions,
} from "@floating-ui/react";
import "./context-menu.scss";

interface ContextMenuProps {
    commands: ContextMenuCommand[];
}

export interface ContextMenuCommand {
    iconUrl: string;
    label: string;
    action: () => void;
}

const ContextMenu: React.FC<ContextMenuProps> = (props) => {
    const [isVisible, setIsVisible] = useState<boolean>(false);

    const { refs, floatingStyles, context } = useFloating({
        open: isVisible,
        onOpenChange: setIsVisible,
        middleware: [offset({ mainAxis: 3, crossAxis: -85 })],
        whileElementsMounted: autoUpdate,
    });

    const click = useClick(context);
    const dismiss = useDismiss(context);

    const { getReferenceProps, getFloatingProps } = useInteractions([click, dismiss]);

    return (
        <div className="dashboard-context-menu" ref={refs.setReference} {...getReferenceProps()}>
            <div className="dashboard-context-menu__trigger">
                <img src={MoreHorizontal} />
            </div>
            {isVisible && (
                <FloatingFocusManager context={context} modal={false}>
                    <div
                        id="dashboard-context-menu__content"
                        ref={refs.setFloating}
                        className="dashboard-context-menu__content"
                        style={floatingStyles}
                        {...getFloatingProps()}
                    >
                        {props.commands.map((c, index) => (
                            <div
                                key={index}
                                className="dashboard-context-menu-item"
                                onClick={() => {
                                    c.action();
                                    setIsVisible(false);
                                }}
                            >
                                <div className="dashboard-context-menu-item__icon">
                                    <img src={c.iconUrl} />
                                </div>
                                <div className="dashboard-context-menu-item__name">{c.label}</div>
                            </div>
                        ))}
                    </div>
                </FloatingFocusManager>
            )}
        </div>
    );
};

export default ContextMenu;
