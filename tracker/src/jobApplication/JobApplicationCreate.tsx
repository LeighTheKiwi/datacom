import React from "react";
import { useCreateJobApplication } from "../hooks/jobApplicationHooks";
import ErrorSummary from "../ErrorSummary";
import JobApplicationForm from "./JobApplicationForm";
import { JobApplication, Status } from "../types";

type Args = {
    submitted: () => void;
};

const JobApplicationCreate = ({ submitted }: Args) => {

    const createJobApplication = useCreateJobApplication();

    const handleOnSubmitted = (jobApplication: JobApplication) => {
        createJobApplication.mutate(jobApplication);
        submitted();
    }

    return (
        <React.Fragment>
            {createJobApplication.isError && (
                <ErrorSummary error={createJobApplication.error} />
            )}
            <JobApplicationForm
                JobApplication={{
                    id: 0,
                    companyName: "",
                    position: "",
                    statusId: Status.Offer
                }}
                submitted={handleOnSubmitted}
            />
        </React.Fragment>
    )
}

export default JobApplicationCreate;