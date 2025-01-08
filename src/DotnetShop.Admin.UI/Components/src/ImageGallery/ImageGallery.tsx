import React, { useState } from "react";
import ImageBox from "./ImageBox";
import { ImageModel } from "./ImageModel";
import UploadBox from "./UploadBox";

const ImageGallery: React.FC = () => {
    const [images, setImages] = useState<ImageModel[]>([
        {
            imageGuid: "740f5670-9373-4fdb-8b93-caf2a8e6726a",
            imageUrl: "/assets/sample.png",
            defaultImage: true,
            imageName: "CupT White 1",
        } as ImageModel,
        {
            imageGuid: "2193137b-1c46-49e1-a6f0-f0a68bf99670",
            imageUrl: "/assets/sample.png",
            defaultImage: true,
            imageName: "CupT White 2",
        } as ImageModel,
        {
            imageGuid: "893f0115-71b9-4018-ba61-125585deb54d",
            imageUrl: "/assets/sample.png",
            defaultImage: true,
            imageName: "CupT White 3",
        } as ImageModel,
        {
            imageGuid: "2e4d2d5b-55b5-42fa-b7d6-700999752bad",
            imageUrl: "/assets/sample.png",
            defaultImage: true,
            imageName: "CupT White 4",
        } as ImageModel,
        {
            imageGuid: "08c35b8d-d287-433f-bce8-dd265cf727d3",
            imageUrl: "/assets/sample.png",
            defaultImage: true,
            imageName: "CupT White 5",
        } as ImageModel,
    ]);
    const [draggedItem, setDraggedItem] = useState<ImageModel | null>();

    const onDragStart = (e: React.DragEvent<HTMLDivElement>, index: number) => {
        setDraggedItem(images[index]);
        e.dataTransfer.effectAllowed = "move";
        e.dataTransfer.setData("text/html", (e.target as HTMLLIElement).parentNode?.textContent!);
        ((e.target as HTMLLIElement).parentNode as HTMLElement).classList.add("hide-image");
        e.dataTransfer.setDragImage((e.target as HTMLLIElement).parentNode as HTMLElement, 20, 20);
    };

    const onDragOver = (e: React.DragEvent<HTMLDivElement>, index: number) => {
        e.preventDefault();
        const draggedOverItem = images[index];

        // // if the item which is not the draggable item is selected to drag
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
    };

    return (
        <div className="image-gallery">
            <div className="image-gallery__label">Image</div>
            <div
                className={images?.length == 0 ? "image-gallery__panel upload-area" : "image-gallery__panel"}
                onDragOver={(e) => e.preventDefault}
            >
                {images.map((item, index) => (
                    <ImageBox
                        /* Do not use index for key, because filtering out the currently dragged item will mess up index */
                        key={item.imageGuid}
                        imageUrl={item.imageUrl}
                        defaultImage={item.defaultImage}
                        imageName={item.imageName}
                        index={index}
                        onDragStartProp={onDragStart}
                        onDragOverProp={onDragOver}
                        onDragEndProp={onDragEnd}
                    />
                ))}

                <UploadBox />
                {images?.length == 0 && <button className="image-gallery__upload">Upload new</button>}
            </div>
        </div>
    );
};

export default ImageGallery;
