import React, { useEffect, useRef, useState } from "react";
import MoreHorizontal from "./icons/more-horizontal.svg";

interface PopoverMenuProps {
    items: PopoverMenuItem[];
}

export interface PopoverMenuItem {
    iconUrl: string;
    name: string;
}

const PopoverMenu: React.FC<PopoverMenuProps> = (props) => {
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
        <div className="popover-menu">
            <div
                ref={triggerRef}
                onClick={() => {
                    setIsVisible(!isVisible);
                }}
                className="popover-menu__trigger"
                aria-haspopup="true"
                aria-expanded={isVisible}
                aria-controls="popover-menu____content"
            >
                <img src={MoreHorizontal} />
            </div>
            {isVisible && (
                <div
                    id="popover-menu____content"
                    ref={popoverRef}
                    className="popover-menu____content"
                    role="dialog"
                    aria-modal="true"
                >
                    {props.items.map((x, index) => (
                        <div
                            key={index}
                            className="popover-menu-item"
                            onClick={() => {
                                alert(index);
                            }}
                        >
                            <div className="popover-menu-item__icon">
                                <img src={x.iconUrl} />
                            </div>
                            <div className="popover-menu-item__name">{x.name}</div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default PopoverMenu;
