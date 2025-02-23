import axios from "axios";

const API_URL = "http://localhost:5002/api"; // Adjust if needed


export const getCompanies = async () => {
    try {
        const response = await axios.get(`${API_URL}/companies`);

        return response.data;
    } catch (error) {
        console.error("Error fetching companies:", error);
        throw error; // Re-throw the error to be handled by the component
    }
};

export const addCompany = async (company) => {
    try {
        await axios.post(`${API_URL}/companies`, company);
    } catch (error) {
        console.error("Error adding company:", error);
        throw error; // Re-throw the error to be handled by the component
    }
};

export const login = async (credentials) => {
    try {
        const response = await axios.post(`${API_URL}/auth/login`, credentials);
        localStorage.setItem("token", response.data.token);
        return response.data;
    } catch (error) {
        console.error("Error logging in:", error);
        throw error; // Re-throw the error to be handled by the component
    }
};

export const deleteCompany = async (id) => {
    try {
        await axios.delete(`${API_URL}/companies/${id}`);
    } catch (error) {
        console.error("Error deleting company:", error);
        throw error; // Re-throw the error to be handled by the component
    }
};
