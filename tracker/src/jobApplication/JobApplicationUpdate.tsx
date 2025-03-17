import React from "react";
import { useFetchJobApplication, useUpdateJobApplication } from "../hooks/jobApplicationHooks";
import ErrorSummary from "../ErrorSummary";
import JobApplicationForm from "./JobApplicationForm";
import ApiStatus from "../ApiStatus";
import { JobApplication } from "../types";

type Args = {
    id: number;
    submitted: () => void;
};

const JobApplicationUpdate = ({ id, submitted }: Args) => {

    const updateJobApplication = useUpdateJobApplication();
    const { data, status, isSuccess } = useFetchJobApplication(id);

    const handleOnSubmitted = (jobApplication: JobApplication) => {
        updateJobApplication.mutate(jobApplication);
        submitted();
    }

    if (!isSuccess) return <ApiStatus status={status} />;

    return (
        <React.Fragment>
            {updateJobApplication.isError && (
                <ErrorSummary error={updateJobApplication.error} />
            )}
            <JobApplicationForm
                JobApplication={data}
                submitted={handleOnSubmitted}
            />
        </React.Fragment>
    )
}

export default JobApplicationUpdate;