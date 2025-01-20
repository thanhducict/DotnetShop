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
    items: ContextMenuItem[];
}

export interface ContextMenuItem {
    iconUrl: string;
    name: string;
}

const ContextMenu: React.FC<ContextMenuProps> = (props) => {
    const [isOpen, setIsOpen] = useState<boolean>(false);

    const { refs, floatingStyles, context } = useFloating({
        open: isOpen,
        onOpenChange: setIsOpen,
        middleware: [offset(8), flip()],
        whileElementsMounted: autoUpdate,
    });

    const click = useClick(context);
    const dismiss = useDismiss(context);

    const { getReferenceProps, getFloatingProps } = useInteractions([click, dismiss]);

    return (
        <div className="context-menu">
            <div className="context-menu__trigger" ref={refs.setReference} {...getReferenceProps()}>
                <img src={MoreHorizontal} />
            </div>
            {isOpen && (
                <FloatingFocusManager context={context} modal={false}>
                    <div
                        id="context-menu____content"
                        ref={refs.setFloating}
                        className="context-menu____content"
                        style={floatingStyles}
                        {...getFloatingProps()}
                    >
                        {props.items.map((x, index) => (
                            <div
                                key={index}
                                className="context-menu-item"
                                onClick={() => {
                                    alert(index);
                                }}
                            >
                                <div className="context-menu-item__icon">
                                    <img src={x.iconUrl} />
                                </div>
                                <div className="context-menu-item__name">{x.name}</div>
                            </div>
                        ))}
                    </div>
                </FloatingFocusManager>
            )}
        </div>
    );
};

export default ContextMenu;
