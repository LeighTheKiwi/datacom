import "./MenuBar.css";

import React, { useState } from "react";
import Dialog from "../main/Dialog";
import JobApplicationCreate from "./JobApplicationCreate";

const MenuBar = () => {
    
    const [showDialog, setShowDialog] = useState(false);

    const handleOnAdd: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();
        setShowDialog(true);
    };

    const handleOnClose = () => {
        setShowDialog(false);
    }

    return (
        <div className="t-menubar">
            <span className="t-link" onClick={handleOnAdd} title="Add Application">add</span>
            { showDialog && 
                <Dialog title="Add Application" close={handleOnClose}>
                    <JobApplicationCreate submitted={handleOnClose} />
                </Dialog> 
            }
        </div>
    )
}

export default MenuBar;