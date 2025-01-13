import ImageGallery from "./ImageGallery";
import { createRoot } from "react-dom/client";
import "./style.scss";

createRoot(document.getElementById("image-gallery-wrapper")!).render(<ImageGallery />);
