# Datacom Code Test
Objective: Build a simple job application tracker with ASP.Net Core Web API and a React or Angular frontend.
Author: Leigh Dawson

## UI
React, Vite, typescript and SWC application.
Configured to run under http://localhost:3000. CORS has been configured for this address.

I have intentionally minimalized the use of third party libraries and kept to pure html/css/typescript with the exceptions being:
  Axios - For HTTP communication with API.
  @tanstack/react-query - State management wrapper.
  sass - CSS Preprocessor

Item 4. (Implement a dropdown menu for updating job status). Wasn't sure what was expected here. 
  ? An application menu with the option to edit a list items status (only available when row selected) or
  ? A context menu when right clicking on row item.
Either way I implemented the editing of status via the row edit option.

I have not included any unit, integration tests.


## Web API
.Net 9 Core console application using minimal API pattern.
Configured to run on http://localhost:4000. CORS expects the React UI on localhost:3000 (this can be changed in appsettings.json).

Originally I used the EntityFrameworkCore.InMemory package as a datastore but I wanted to prepopulate with test data using
migrations and this option did not support that so I have used Sqlite. The database is created under the current users AppData/Local
folder. The included database can either be copied to this location or create the database by opening the project in visual studio
and running the EF cmd "Update-Database" (from Powershell) or "dotnet ef database update" (from .NET CLI).

I have also intentionally minimalized the use of third party libraries including manually mapping between db entities and dto rather than using something like Auto Mapper. One exception has been:
  MiniValidation - Validation library.

No Authorization or Authentication has been implemented.

I have not included any unit, integration tests.

## To run
Given the purpose of this app I have assumed a dev environment setup.

### Web API
Open the tracker.api solution file in visual studio (dependencies should install - resolve any issues).
You can either create the Sqlite database or copy the included file (JobApplicationTracker.db) file to the current users appdata/local folder.
To Create the Sqlite database execute either "Update-Database" (from Package Manager console/Powershell) or "dotnet ef database update" (from .NET CLI, project folder)
Run the application

### UI
Open the tracker folder in Visual Studio Code.
Run "npm install" to load dependant modules.
Run the application using "npm run dev" (this is configered to run on port 3000).
