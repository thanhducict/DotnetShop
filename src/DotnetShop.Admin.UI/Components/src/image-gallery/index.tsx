import ImageGallery from "./image-gallery";
import { createRoot } from "react-dom/client";
import "./image-gallery.scss";

createRoot(document.getElementById("image-gallery-wrapper")!).render(<ImageGallery />);
