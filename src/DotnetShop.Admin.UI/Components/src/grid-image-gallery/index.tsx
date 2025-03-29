import GridImageGallery from "./grid-image-gallery";
import { createRoot } from "react-dom/client";
import "./grid-image-gallery.scss";

let gridImageGallery = document.getElementById("grid-image-gallery-wrapper");
if (gridImageGallery) {
    createRoot(gridImageGallery).render(<GridImageGallery />);
}
