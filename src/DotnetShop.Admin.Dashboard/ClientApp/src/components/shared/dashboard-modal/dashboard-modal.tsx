import React, { ReactNode } from "react";
import "./modal.css"; // Import CSS for styling

interface ModalProps {
    isOpen: boolean;
    onClose: () => void;
    title?: string;
    children: ReactNode;
}

const DashboardModal: React.FC<ModalProps> = (props) => {
    return (
        <>
            {props.isOpen ? (
                <div className="dashboard-modal" onClick={props.onClose}>
                    <div className="dashboard-modal__overlay" onClick={props.onClose}>
                        <button onClick={props.onClose}>&times;</button>
                    </div>
                    <div className="dashboard-modal__content" onClick={(e) => e.stopPropagation()}>
                        <div className="modal-body">{props.children}</div>
                    </div>
                </div>
            ) : (
                <></>
            )}
        </>
    );
};

export default DashboardModal;
