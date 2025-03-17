import { AxiosError } from "axios";
import { Error } from "./types";
import React from "react";

type Args = {
    error: AxiosError<Error>;
};

const ErrorSummary = ({ error }: Args) => {

  if (error.response?.status !== 400) return <React.Fragment></React.Fragment>;

  const errors = error.response?.data.errors;
  
  return (
    <React.Fragment>
        <div className="t-danger">The following error occurred:</div>
        {Object.entries(errors).map(([key, value]) => (
            <ul key={key}>
                <li>
                    {key}: {value.join(", ")}
                </li>
            </ul>
        ))}
    </React.Fragment>
  );
};

export default ErrorSummary;