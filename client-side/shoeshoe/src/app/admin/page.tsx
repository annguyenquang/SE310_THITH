"use client"
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import { ProductList } from "../../../components/common/ProductList";
import Container from "@mui/material/Container";
import Grid2 from "@mui/material/Grid2";
import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";

const AdminPage = () => {
    const [tabIndex, setTabIndex] = React.useState(0);
    const handleTabChange = (event: React.SyntheticEvent, newIndex: number) => {
        setTabIndex(newIndex);
    };
    return (
        <Box padding={1}>
            <Tabs value={tabIndex} onChange={handleTabChange} aria-label="admin tabs">
                <Tab label="Product List" />
                <Tab label="Dashboard" />
            </Tabs>
            {tabIndex === 0 &&
                <Container>
                    <Grid2 container spacing={3}>
                        <TextField
                            fullWidth
                            label="Search"
                        />
                        <ProductList isAdmin></ProductList>
                    </Grid2>
                </Container>
            }
            {tabIndex == 1 &&
                <Container>
                    This is the dashboard
                </Container>
            }
        </Box>
    );
}

export default AdminPage;