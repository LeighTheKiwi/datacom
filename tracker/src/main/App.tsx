import './App.scss'

import React from 'react';
import Header from './Header';
import JobApplicationList from '../JobApplication/JobApplicationList';

function App() {
    return (
        <React.Fragment>
            <Header />
            <JobApplicationList />
        </React.Fragment>
    )
}

export default App
