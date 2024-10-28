"use client"
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { Box, Container, Grid2, TextField } from '@mui/material';
import React from 'react';
import { ProductList } from '../../components/common/ProductList';


export default function Home() {

  return (
    <Box padding={1}>
      <Container>
        <Grid2 container spacing={3}>
          <TextField
            fullWidth
            label="Search"
          />
          <ProductList></ProductList>
        </Grid2>
      </Container>
    </Box>
  );
}
