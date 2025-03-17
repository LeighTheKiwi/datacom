import "./JobApplicationForm.scss";

import { useState } from "react";
import { JobApplication, Status } from "../types";
import DropDownList from "../common/DropDownList";

type Args = {
    JobApplication: JobApplication;
    submitted: (JobApplication: JobApplication) => void;
};

const JobApplicationForm = ({ JobApplication, submitted }: Args) => {

    const [jobApplicationState, setJobApplicationState] = useState({ ...JobApplication });

    const handleOnSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();
        
        jobApplicationState.appliedDate = new Date();
        submitted(jobApplicationState);
    };

    return (
        <form>
            <div className="t-form-group">
                <label htmlFor="companyName">Company Name</label>
                <input
                    type="text"
                    placeholder="Company Name"
                    value={jobApplicationState.companyName}
                    onChange={(e) =>
                        setJobApplicationState({ ...jobApplicationState, companyName: e.target.value })
                    }
                />
            </div>
            <div className="t-form-group">
                <label htmlFor="companyName">Position</label>
                <input
                    type="text"
                    placeholder="Position"
                    value={jobApplicationState.position}
                    onChange={(e) =>
                        setJobApplicationState({ ...jobApplicationState, position: e.target.value })
                    }
                />
            </div>
            <div className="t-form-group">
                <label htmlFor="statusId">Status</label>
                <DropDownList 
                    id="statusId"
                    data={
                        Object.entries(Status)
                            .filter(x => isNaN(parseInt(x[0])))
                            .map(([value, key]) => ({ key: key as number, value }))
                    }
                    value={jobApplicationState.statusId} 
                    change={(e) => setJobApplicationState({ ...jobApplicationState, statusId: +e.target.value })}
                />
            </div>
            <button
                disabled={!jobApplicationState.companyName || !jobApplicationState.position || !jobApplicationState.statusId}
                onClick={handleOnSubmit}
            >
                Submit
            </button>
        </form>
    )
}

export default JobApplicationForm;