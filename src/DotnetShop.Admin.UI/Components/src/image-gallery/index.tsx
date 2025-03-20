import ImageGallery from "./image-gallery";
import { createRoot } from "react-dom/client";
import "./image-gallery.scss";

let imageGallery = document.getElementById("image-gallery-wrapper");
if (imageGallery) {
    createRoot(imageGallery).render(<ImageGallery />);
}
