import React, { useState } from "react";
import Hamburger from "./hamburger.svg";
import "./DragDropList.scss";

const DragDropList: React.FC = () => {
    const [items, setItems] = useState<string[]>(["🍰 Cake", "🍩 Donut", "🍎 Apple", "🍕 Pizza"]);
    const [draggedItem, setDraggedItem] = useState<string>("");

    const onDragStart = (e: React.DragEvent<HTMLDivElement>, index: number) => {
        console.log("onDragStart");
        setDraggedItem(items[index]);
        e.dataTransfer.effectAllowed = "move";
        e.dataTransfer.setData("text/html", (e.target as HTMLLIElement).parentNode?.textContent!);
        e.dataTransfer.setDragImage((e.target as HTMLLIElement).parentNode as HTMLElement, 20, 20);
    };

    const onDragOver = (e: React.DragEvent<HTMLLIElement>, index: number) => {
        e.preventDefault();

        const draggedOverItem = items[index];
        // if the item which is not the draggable item is selected to drag
        if (draggedItem.length == 0) {
            return;
        }
        // if the item is dragged over itself, ignore
        if (draggedItem === draggedOverItem) {
            return;
        }
        // filter out the currently dragged item
        let temp = items.filter((item) => item !== draggedItem);
        // add the dragged item after the dragged over item
        temp.splice(index, 0, draggedItem);
        setItems(temp);
    };

    const onDragEnd = (e: React.DragEvent<HTMLDivElement>) => {
        console.log("onDragEnd");
        ((e.target as HTMLLIElement).parentNode as HTMLElement).classList.remove("hide-item");
        setDraggedItem("");
    };

    return (
        <div className="drag-drop-list">
            <main>
                <h3>List of items</h3>
                <ul>
                    {items.map((item, index) => (
                        /* Do not use index for key, because filtering out the currently dragged item will mess up index */
                        <li
                            key={item}
                            onDragOver={(e: React.DragEvent<HTMLLIElement>) => onDragOver(e, index)}
                            onDrop={(e) => {
                                e.preventDefault();
                            }}
                        >
                            <div
                                className="drag"
                                draggable
                                onDrop={(e) => {
                                    e.preventDefault();
                                }}
                                onDrag={(e) => {
                                    ((e.target as HTMLLIElement).parentNode as HTMLElement).classList.add("hide-item");
                                }}
                                onDragStart={(e: React.DragEvent<HTMLDivElement>) => onDragStart(e, index)}
                                onDragEnd={(e) => onDragEnd(e)}
                            >
                                <Hamburger />
                            </div>
                            <span className="content">{item}</span>
                        </li>
                    ))}
                </ul>
            </main>
        </div>
    );
};

export default DragDropList;
