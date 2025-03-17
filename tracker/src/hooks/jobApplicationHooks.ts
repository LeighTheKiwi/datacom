// ****************************************************
// Hooks for interacting with the tracker.api endpoints
// Will use react-query to leverage off result caching.
// ****************************************************

import axios, { AxiosError, AxiosResponse } from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

import config from "../config";
import { Error, JobApplication } from "../types";

// Get a single Job Application
const useFetchJobApplication = (id: number) => {

    return useQuery<JobApplication, AxiosError>({
      queryKey: ["jobApplications", id],
      queryFn: () =>
        axios.get(`${config.baseApiUrl}/applications/${id}`).then((resp) => resp.data)
    });
};

// Get a list of all Job Applications
const useFetchJobApplications = () => {

    return useQuery<JobApplication[], AxiosError>({
        queryKey: ["jobApplications"],
        queryFn: () =>
            axios.get(`${config.baseApiUrl}/applications`).then((resp) => resp.data)
    });
};

// Create a Job Application
// Note: AppliedDate is set on server
const useCreateJobApplication = () => {

    const queryClient = useQueryClient();
    
    return useMutation<AxiosResponse, AxiosError<Error>, JobApplication>({
        mutationFn: (h) => axios.post(`${config.baseApiUrl}/applications`, h),
        onSuccess: () => 
            queryClient.invalidateQueries({ queryKey: ["jobApplications"] })
    });
};

// Update a Job Application
// Note: AppliedDate cannot be edited.
const useUpdateJobApplication = () => {

    const queryClient = useQueryClient();
    
    return useMutation<AxiosResponse, AxiosError<Error>, JobApplication>({
        mutationFn: (h) => axios.put(`${config.baseApiUrl}/applications`, h),
        onSuccess: () => 
            queryClient.invalidateQueries({ queryKey: ["jobApplications"] })        
    });
};

export {
    useFetchJobApplication,
    useFetchJobApplications,
    useCreateJobApplication,
    useUpdateJobApplication
}