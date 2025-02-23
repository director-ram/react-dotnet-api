import React, { useEffect, useState } from "react";
import { getCompanies, deleteCompany } from "../services/api";
import AddCompanyForm from "./AddCompanyForm";
import { Container, Typography, List, ListItem, ListItemText, IconButton } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';

const CompanyList = () => {
    const [companies, setCompanies] = useState([]);
    const [error, setError] = useState(null);
    const [refresh, setRefresh] = useState(false);

    useEffect(() => {
        try {
            getCompanies().then(setCompanies);
        } catch (error) {
            setError(error.message);
        }
    }, [refresh]);

    const handleCompanyAdded = () => {
        setRefresh(!refresh);
    };

    const handleDeleteCompany = async (id) => {
        try {
            await deleteCompany(id);
            setRefresh(!refresh);
        } catch (error) {
            console.error("Error deleting company:", error);
            alert("Failed to delete company.");
        }
    };

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <Container className="my-4">
            <Typography variant="h4" component="h2" gutterBottom className="text-center">
                Companies
            </Typography>
            <AddCompanyForm onCompanyAdded={handleCompanyAdded} />
            <List>
                {companies.map((company, index) => (
                    <ListItem key={company.id} secondaryAction={
                        <IconButton edge="end" aria-label="delete" onClick={() => handleDeleteCompany(company.id)}>
                            <DeleteIcon />
                        </IconButton>
                    }>
                        <ListItemText primary={`${index + 1}. ${company.name}`} />
                    </ListItem>
                ))}
            </List>
        </Container>
    );
};

export default CompanyList;
