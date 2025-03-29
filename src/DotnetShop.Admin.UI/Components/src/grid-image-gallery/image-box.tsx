import React from "react";
import ContextMenu from "../shared/context-menu/context-menu";
import MoveIcon from "../shared/icons/move.svg";
import EditIcon from "../shared/icons/edit.svg";
import TrashIcon from "../shared/icons/trash.svg";
import { ImageModel } from "./image-model";
import { useSortable } from "@dnd-kit/sortable";
import { CSS } from "@dnd-kit/utilities";

interface ImageBoxProps {
    image: ImageModel;
    children?: React.ReactNode;
}

const ImageBox: React.FC<ImageBoxProps> = (props) => {
    const sortable = useSortable({ id: props.image.id });
    const { attributes, listeners, isDragging, setNodeRef, transform, transition } = sortable;

    const style = {
        transform: CSS.Transform.toString(transform),
        transition,
    };

    return (
        <div className={isDragging ? "image-box image-box--dragging" : "image-box"} ref={setNodeRef} style={style}>
            <div
                className="image-box__drag"
                style={{ backgroundImage: `url(${MoveIcon})` }}
                {...attributes}
                {...listeners}
            ></div>
            <img className="image-box__image" src={props.image.imageUrl} alt="CupT White Mug HD" />
            <div className="image-panel">
                <div className="image-panel__info">
                    {props.image.thumbnail ? (
                        <div className="image-panel__thumbnail">{props.image.imageUrl.split(".")[1].toUpperCase()}</div>
                    ) : (
                        <div className="image-panel__image">{props.image.imageUrl.split(".")[1].toUpperCase()}</div>
                    )}
                    <div className="image-panel__image-name">{props.image.imageName}</div>
                </div>
                <div className="image-panel__button">
                    <ContextMenu
                        commands={[
                            { iconUrl: EditIcon, label: "Edit", execute: () => {} },
                            { iconUrl: TrashIcon, label: "Trash", execute: () => {} },
                        ]}
                    />
                </div>
            </div>
        </div>
    );
};

export default ImageBox;
