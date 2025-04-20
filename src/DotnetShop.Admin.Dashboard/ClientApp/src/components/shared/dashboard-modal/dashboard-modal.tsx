import React, { ReactNode } from "react";
import "./dashboard-modal.scss";
import X from "../../../icons/x.svg";

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
                    <div className="dashboard-modal__content" onClick={(e) => e.stopPropagation()}>
                        <img src={X} className="dashboard-modal__close-button" onClick={props.onClose} />
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
