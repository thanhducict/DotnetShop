import React from "react";
import MoveIcon from "./icons/move.svg";
import PopoverMenu from "./PopoverMenu";
import Edit from "./icons/edit.svg";
import Trash from "./icons/trash.svg";

interface ImageBoxProps {
    imageUrl: string;
    thumbnail: boolean;
    imageName: string;
    index: number;
    onDragStartProp: (e: React.DragEvent<HTMLDivElement>, index: number) => void;
    onDragOverProp: (e: React.DragEvent<HTMLDivElement>, index: number) => void;
    onDragEndProp: (e: React.DragEvent<HTMLDivElement>) => void;
}

const ImageBox: React.FC<ImageBoxProps> = (props) => {
    return (
        <div
            className="image-box"
            onDragOver={(e: React.DragEvent<HTMLDivElement>) => props.onDragOverProp(e, props.index)}
        >
            <div
                className="image-box__drag"
                draggable
                onDragStart={(e: React.DragEvent<HTMLDivElement>) => props.onDragStartProp(e, props.index)}
                onDragEnd={props.onDragEndProp}
                style={{ backgroundImage: `url(${MoveIcon})` }}
            ></div>
            <img className="image-box__image" src={props.imageUrl} alt="CupT White Mug HD" />
            <div className="image-panel">
                <div className="image-panel__info">
                    {props.thumbnail ? (
                        <div className="image-panel__thumbnail">{props.imageUrl.split(".")[1].toUpperCase()}</div>
                    ) : (
                        <div className="image-panel__image">{props.imageUrl.split(".")[1].toUpperCase()}</div>
                    )}
                    <div className="image-panel__image-name">{props.imageName}</div>
                </div>
                <div className="image-panel__button">
                    <PopoverMenu
                        items={[
                            { iconUrl: Edit, name: "Edit" },
                            { iconUrl: Trash, name: "Trash" },
                        ]}
                    />
                </div>
            </div>
        </div>
    );
};

export default ImageBox;
