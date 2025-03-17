import "./header.css";

import reactLogo from "../assets/react.svg";
import viteLogo from "/vite.svg";

const Header = () => {
    return (
        <div className="t-header">
            <div>
                <a href="https://vite.dev" target="_blank">
                    <img src={viteLogo} className="t-logo" alt="Vite logo" />
                </a>
                <a href="https://react.dev" target="_blank">
                    <img src={reactLogo} className="t-logo react" alt="React logo" />
                </a>
            </div>
            <h2>Job Application Tracker</h2>
        </div>
    )
}

export default Header;