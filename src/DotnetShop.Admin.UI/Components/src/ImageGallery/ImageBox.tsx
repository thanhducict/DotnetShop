import React from "react";
import MoveIcon from "./icons/move.svg";

interface ImageBoxProps {
    imageUrl: string;
    defaultImage: boolean;
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
            >
                {/* <img src={MoveIcon} /> */}
            </div>
            <img className="image-box__image" src={props.imageUrl} alt="CupT White Mug HD" />
            <div className="image-panel">
                <div className="image-panel__info">
                    <div className="image-default">{props.index}</div>
                    <div className="image-name">{props.imageName}</div>
                </div>
                <div className="image-panel__button"></div>
            </div>
        </div>
    );
};

export default ImageBox;
