import React, { useState } from "react";
import Dialog from "../main/Dialog";
import JobApplicationUpdate from "./JobApplicationUpdate";

type Args = {
    id: number;
};

const JobApplicationListItemEdit = ({id}: Args) => {

    const [showDialog, setShowDialog] = useState(false);

    const handleOnEdit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();
        setShowDialog(true);
    };

    const handleOnClose = () => {
        setShowDialog(false);
    }

    return (
        <React.Fragment>
            <span className="t-link" onClick={handleOnEdit} title="edit application">edit</span>
            { showDialog && 
                <Dialog title='Add Application' close={handleOnClose}>
                    <JobApplicationUpdate id={id} submitted={handleOnClose} />
                </Dialog> 
            }
        </React.Fragment>
    )
}

export default JobApplicationListItemEdit;