import {
    closestCenter,
    DndContext,
    DragCancelEvent,
    DragEndEvent,
    DragOverlay,
    DragStartEvent,
    MouseSensor,
    UniqueIdentifier,
    useSensor,
    useSensors,
} from "@dnd-kit/core";
import { SortableContext } from "@dnd-kit/sortable";
import React, { useState } from "react";
import { ImageModel } from "./image-model";
import ImageBox from "./image-box";
import PlusIcon from "../shared/icons/plus.svg";

const GridImageGallery: React.FC = () => {
    const [images, setImages] = useState<ImageModel[]>([
        {
            id: "740f5670-9373-4fdb-8b93-caf2a8e6726a",
            imageUrl: "/assets/CupT Badge.png",
            thumbnail: true,
            imageName: "CupT Badge",
        } as ImageModel,
        {
            id: "2193137b-1c46-49e1-a6f0-f0a68bf99670",
            imageUrl: "/assets/CupT T-Shirt.png",
            thumbnail: false,
            imageName: "CupT T-Shirt",
        } as ImageModel,
        {
            id: "893f0115-71b9-4018-ba61-125585deb54d",
            imageUrl: "/assets/CupT White Mug.png",
            thumbnail: false,
            imageName: "CupT White Mug",
        } as ImageModel,
        {
            id: "2e4d2d5b-55b5-42fa-b7d6-700999752bad",
            imageUrl: "/assets/NET Blue Sweatshirt.png",
            thumbnail: false,
            imageName: "NET Blue Sweatshirt",
        } as ImageModel,
        {
            id: "08c35b8d-d287-433f-bce8-dd265cf727d3",
            imageUrl: "/assets/Roslyn Red Badge.png",
            thumbnail: false,
            imageName: "Roslyn Red Badge",
        } as ImageModel,
    ]);
    const [activeId, setActiveId] = useState<UniqueIdentifier | null>(null);

    const sensors = useSensors(useSensor(MouseSensor));

    const handleDragStart = (event: DragStartEvent) => {
        setActiveId(event.active.id);
    };

    const handleDragEnd = (event: DragEndEvent): void => {
        const { active, over } = event;

        if (active.id !== over?.id) {
            setImages((prevImages) => {
                const oldIndex = prevImages.findIndex((image) => image.id === active.id);
                const newIndex = prevImages.findIndex((image) => image.id === over?.id);

                const updatedImages = [...prevImages];
                const [movedImage] = updatedImages.splice(oldIndex, 1);
                updatedImages.splice(newIndex, 0, movedImage);

                return updatedImages;
            });
        }

        setActiveId(null);
    };

    const handleDragCancel = (event: DragCancelEvent): void => {
        setActiveId(null);
    };

    return (
        <DndContext
            sensors={sensors}
            collisionDetection={closestCenter}
            onDragStart={handleDragStart}
            onDragEnd={handleDragEnd}
            onDragCancel={handleDragCancel}
        >
            <SortableContext items={images}>
                <div className="image-gallery">
                    <div className="image-gallery__label">Image</div>
                    <div
                        className={
                            images?.length == 0
                                ? "image-gallery__panel image-gallery__panel--empty"
                                : "image-gallery__panel"
                        }
                    >
                        {images.map((image, index) => (
                            <ImageBox
                                key={image.id}
                                image={
                                    {
                                        id: image.id,
                                        imageName: image.imageName,
                                        imageUrl: image.imageUrl,
                                        thumbnail: image.thumbnail,
                                    } as ImageModel
                                }
                            />
                        ))}
                        {images?.length != 0 ? (
                            <div className="upload-box" onClick={() => {}}>
                                <div className="upload-box__content">
                                    <img src={PlusIcon} />
                                </div>
                            </div>
                        ) : (
                            <button>Upload new</button>
                        )}
                    </div>
                </div>
            </SortableContext>
            <DragOverlay adjustScale={true}>
                {activeId ? <ImageBox image={images.find((i) => i.id == activeId) as ImageModel} /> : null}
            </DragOverlay>
        </DndContext>
    );
};

export default GridImageGallery;
