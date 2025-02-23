import React from 'react';
import { useForm } from 'react-hook-form';
import { addCompany } from '../services/api';
import { TextField, Button, Container, Typography } from '@mui/material';

const AddCompanyForm = ({ onCompanyAdded }) => {
  const { register, handleSubmit, formState: { errors }, reset } = useForm();

  const onSubmit = async (data) => {
    try {
      await addCompany(data);
      alert('Company added successfully!');
      reset();
      onCompanyAdded();
    } catch (error) {
      console.error('Error adding company:', error);
      alert('Failed to add company.');
    }
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" component="h2" gutterBottom>
        Add New Company
      </Typography>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextField
          label="Name"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register("name", { required: true })}
          error={!!errors.name}
          helperText={errors.name ? "This field is required" : ""}
        />
        <TextField
          label="Address"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register("address", { required: true })}
          error={!!errors.address}
          helperText={errors.address ? "This field is required" : ""}
        />
        <Button type="submit" variant="contained" color="primary">
          Add Company
        </Button>
      </form>
    </Container>
  );
};

export default AddCompanyForm;