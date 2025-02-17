import React, { useState } from "react";
import MoreHorizontal from "../icons/more-horizontal.svg";
import {
    autoUpdate,
    flip,
    FloatingFocusManager,
    offset,
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
    execute: () => void;
}

const ContextMenu: React.FC<ContextMenuProps> = (props) => {
    const [isVisible, setIsVisible] = useState<boolean>(false);

    const { refs, floatingStyles, context } = useFloating({
        open: isVisible,
        onOpenChange: setIsVisible,
        middleware: [offset(8), flip()],
        whileElementsMounted: autoUpdate,
    });

    const click = useClick(context);
    const dismiss = useDismiss(context);

    const { getReferenceProps, getFloatingProps } = useInteractions([click, dismiss]);

    return (
        <div className="context-menu" ref={refs.setReference} {...getReferenceProps()}>
            <div className="context-menu__trigger">
                <img src={MoreHorizontal} />
            </div>
            {isVisible && (
                <FloatingFocusManager context={context} modal={false}>
                    <div
                        id="context-menu__content"
                        ref={refs.setFloating}
                        className="context-menu__content"
                        style={floatingStyles}
                        {...getFloatingProps()}
                    >
                        {props.commands.map((c, index) => (
                            <div
                                key={index}
                                className="context-menu-item"
                                onClick={() => {
                                    c.execute();
                                    setIsVisible(false);
                                }}
                            >
                                <div className="context-menu-item__icon">
                                    <img src={c.iconUrl} />
                                </div>
                                <div className="context-menu-item__name">{c.label}</div>
                            </div>
                        ))}
                    </div>
                </FloatingFocusManager>
            )}
        </div>
    );
};

export default ContextMenu;
