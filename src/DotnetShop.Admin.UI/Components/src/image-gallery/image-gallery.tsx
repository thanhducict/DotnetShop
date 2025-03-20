import React, { useEffect, useState } from "react";
import ImageBox from "./image-box";
import { ImageModel } from "./image-model";
import PlusIcon from "../shared/icons/plus.svg";

const ImageGallery: React.FC = () => {
    const [images, setImages] = useState<ImageModel[]>([
        {
            imageGuid: "740f5670-9373-4fdb-8b93-caf2a8e6726a",
            imageUrl: "/assets/CupT Badge.png",
            thumbnail: true,
            imageName: "CupT Badge",
        } as ImageModel,
        {
            imageGuid: "2193137b-1c46-49e1-a6f0-f0a68bf99670",
            imageUrl: "/assets/CupT T-Shirt.png",
            thumbnail: false,
            imageName: "CupT T-Shirt",
        } as ImageModel,
        {
            imageGuid: "893f0115-71b9-4018-ba61-125585deb54d",
            imageUrl: "/assets/CupT White Mug.png",
            thumbnail: false,
            imageName: "CupT White Mug",
        } as ImageModel,
        {
            imageGuid: "2e4d2d5b-55b5-42fa-b7d6-700999752bad",
            imageUrl: "/assets/NET Blue Sweatshirt.png",
            thumbnail: false,
            imageName: "NET Blue Sweatshirt",
        } as ImageModel,
        {
            imageGuid: "08c35b8d-d287-433f-bce8-dd265cf727d3",
            imageUrl: "/assets/Roslyn Red Badge.png",
            thumbnail: false,
            imageName: "Roslyn Red Badge",
        } as ImageModel,
        {
            imageGuid: "740f5670-9373-4fdb-8b93-caf2a8e6726b",
            imageUrl: "/assets/CupT Badge.png",
            thumbnail: true,
            imageName: "CupT Badge",
        } as ImageModel,
        {
            imageGuid: "2193137b-1c46-49e1-a6f0-f0a68bf99671",
            imageUrl: "/assets/CupT T-Shirt.png",
            thumbnail: false,
            imageName: "CupT T-Shirt",
        } as ImageModel,
        {
            imageGuid: "893f0115-71b9-4018-ba61-125585deb54e",
            imageUrl: "/assets/CupT White Mug.png",
            thumbnail: false,
            imageName: "CupT White Mug",
        } as ImageModel,
        {
            imageGuid: "2e4d2d5b-55b5-42fa-b7d6-700999752bae",
            imageUrl: "/assets/NET Blue Sweatshirt.png",
            thumbnail: false,
            imageName: "NET Blue Sweatshirt",
        } as ImageModel,
        {
            imageGuid: "08c35b8d-d287-433f-bce8-dd265cf727d4",
            imageUrl: "/assets/Roslyn Red Badge.png",
            thumbnail: false,
            imageName: "Roslyn Red Badge",
        } as ImageModel,
    ]);
    const [draggedItem, setDraggedItem] = useState<ImageModel | null>();
    const [draggedItemIndex, setDraggedItemIndex] = useState<number>(-1);
    const [draggedOverItemIndex, setDraggedOverItemIndex] = useState<number>(-1);
    const [isUploadDialogShown, setIsUploadDialogShown] = useState<boolean>(false);

    const onDragStart = (e: React.DragEvent<HTMLDivElement>, index: number) => {
        setDraggedItem(images[index]);
        setDraggedItemIndex(index);
        e.dataTransfer.effectAllowed = "move";
        e.dataTransfer.setData("text/html", (e.target as HTMLLIElement).parentNode?.textContent!);
        ((e.target as HTMLLIElement).parentNode as HTMLElement).classList.add("hide-image");
        e.dataTransfer.setDragImage((e.target as HTMLLIElement).parentNode as HTMLElement, 20, 20);
    };

    const onDragOver = (e: React.DragEvent<HTMLDivElement>, index: number) => {
        e.preventDefault();
        setDraggedOverItemIndex(index);
        const draggedOverItem = images[index];

        // if the item which is not the draggable item is selected to drag
        if (draggedItem == null) {
            return;
        }

        // if the item is dragged over itself, ignore
        if (draggedItem.imageGuid === draggedOverItem.imageGuid) {
            return;
        }

        // filter out the currently dragged item
        let temp = images.filter((item) => item.imageGuid !== draggedItem.imageGuid);

        // add the dragged item after the dragged over item
        const draggedItemAfter = images.find((i) => i.imageGuid === draggedItem.imageGuid);
        temp.splice(index, 0, draggedItemAfter!);
        setImages(temp);
    };

    const onDragEnd = (e: React.DragEvent<HTMLDivElement>) => {
        ((e.target as HTMLLIElement).parentNode as HTMLElement).classList.remove("hide-image");
        setDraggedItem(null);
        setDraggedItemIndex(-1);
        const all = document.querySelectorAll(".image-box__drag");

        Array.prototype.slice.call(all).forEach((e) => {
            e?.classList.remove("hide-drag-icon");
        });
    };

    useEffect(() => {
        const all = document.querySelectorAll(".image-box__drag");
        all[draggedItemIndex]?.classList.add("hide-drag-icon");
    }, [images]);

    return (
        <>
            <div className="image-gallery">
                <div className="image-gallery__label">Image</div>
                <div
                    className={
                        images?.length == 0
                            ? "image-gallery__panel image-gallery__panel--empty"
                            : "image-gallery__panel"
                    }
                    onDragOver={(e) => e.preventDefault()}
                    onDrop={(e) => e.preventDefault()}
                >
                    {images.map((item, index) => (
                        <ImageBox
                            /* Do not use index for key, because filtering out the currently dragged item will mess up index */
                            key={item.imageGuid}
                            imageUrl={item.imageUrl}
                            thumbnail={item.thumbnail}
                            imageName={item.imageName}
                            index={index}
                            onDragStartProp={onDragStart}
                            onDragOverProp={onDragOver}
                            onDragEndProp={onDragEnd}
                        />
                    ))}

                    {images?.length != 0 && (
                        <div className="upload-box" onClick={() => {}}>
                            <div className="upload-box__content">
                                <img src={PlusIcon} />
                            </div>
                        </div>
                    )}
                    {images?.length == 0 && <button>Upload new</button>}
                </div>
            </div>
        </>
    );
};

export default ImageGallery;
