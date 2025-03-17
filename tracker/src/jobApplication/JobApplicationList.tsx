import "./JobApplicationList.scss";

import { useFetchJobApplications } from "../hooks/jobApplicationHooks";
import { JobApplication, Status } from "../types";
import JobApplicationListItemEdit from "./JobApplicationListItemEdit";
import MenuBar from "./MenuBar";

const JobApplicationList = () => {

    const { data } = useFetchJobApplications();

    return (
        <div className="t-list">
            <MenuBar />
            <table>
                <thead>
                    <tr>
                        <th>Company Name</th>
                        <th>Position</th>
                        <th>Date Applied</th>
                        <th>Status</th>
                        <th />
                    </tr>
                </thead>
                <tbody>
                    {data && data.map((item: JobApplication) => (
                        <tr key={item.id} className="t-list-item">
                            <td>{item.companyName}</td>
                            <td>{item.position}</td>
                            <td>{item.appliedDate? new Date(item.appliedDate).toDateString() : ""}</td>
                            <td>{Status[item.statusId]}</td>
                            <td><JobApplicationListItemEdit id={item.id} /></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default JobApplicationList;