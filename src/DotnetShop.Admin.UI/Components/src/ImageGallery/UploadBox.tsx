import React from "react";
import Plus from "./icons/plus.svg";

const UploadBox: React.FC = () => {
    return (
        <div className="upload-box upload-area">
            <img src={Plus} />
        </div>
    );
};

export default UploadBox;
