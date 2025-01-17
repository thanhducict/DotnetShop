import React from "react";
import ContextMenu from "../shared/context-menu/context-menu";
import MoveIcon from "../shared/icons/move.svg";
import EditIcon from "../shared/icons/edit.svg";
import TrashIcon from "../shared/icons/trash.svg";

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
                    <ContextMenu
                        items={[
                            { iconUrl: EditIcon, name: "Edit" },
                            { iconUrl: TrashIcon, name: "Trash" },
                        ]}
                    />
                </div>
            </div>
        </div>
    );
};

export default ImageBox;
