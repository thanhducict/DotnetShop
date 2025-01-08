import React from "react";

const UploadDialog: React.FC = () => {
    return (
        <div className="upload-dialog">
            <div className="upload-dialog__content">
                <span className="upload-dialog__close">&times;</span>
                <p>Some text in the Modal..</p>
            </div>
        </div>
    );
};

export default UploadDialog;
