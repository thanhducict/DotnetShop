import React, { useEffect, useRef, useState } from "react";
import MoreHorizontal from "../icons/more-horizontal.svg";

interface ContextMenuProps {
    items: ContextMenuItem[];
}

export interface ContextMenuItem {
    iconUrl: string;
    name: string;
}

const ContextMenu: React.FC<ContextMenuProps> = (props) => {
    const [isVisible, setIsVisible] = useState(true); // Manages the visibility state of the popover
    const popoverRef = useRef<HTMLDivElement>(null); // Reference to the popover element
    const triggerRef = useRef<HTMLDivElement>(null); // Reference to the button element that triggers the popover

    useEffect(() => {
        const handleClickOutside = (event: any) => {
            if (
                popoverRef.current &&
                !popoverRef.current.contains(event.target) &&
                !triggerRef.current?.contains(event.target)
            ) {
                setIsVisible(false); // Close the popover if clicked outside
            }
        };

        document.addEventListener("mousedown", handleClickOutside);
        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, []);

    return (
        <div className="context-menu">
            <div
                ref={triggerRef}
                onClick={() => {
                    setIsVisible(!isVisible);
                }}
                className="context-menu__trigger"
                aria-haspopup="true"
                aria-expanded={isVisible}
                aria-controls="context-menu____content"
            >
                <img src={MoreHorizontal} />
            </div>
            {isVisible && (
                <div
                    id="context-menu____content"
                    ref={popoverRef}
                    className="context-menu____content"
                    role="dialog"
                    aria-modal="true"
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
            )}
        </div>
    );
};

export default ContextMenu;
