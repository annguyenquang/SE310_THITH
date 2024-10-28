"use client"
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import { ProductList } from "../../../components/common/ProductList";
import Container from "@mui/material/Container";
import Grid2 from "@mui/material/Grid2";
import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import IconButton from '@mui/material/IconButton'
import { Add } from "@mui/icons-material";
import green from "@mui/material/colors/green";
import { Product } from "../../../core/model/Product";
import { useProductStore } from "../../../core/store/ProductStore";

const AdminPage = () => {

    const [tabIndex, setTabIndex] = React.useState(0);
    const handleTabChange = (event: React.SyntheticEvent, newIndex: number) => {
        setTabIndex(newIndex);
    };
    const store = useProductStore();

    function addProduct(): void {
        const name = (document.getElementById("create-input-name") as any).value;
        const brand = (document.getElementById("create-input-brand") as any).value;
        const price = (document.getElementById("create-input-price") as any).value;
        const stock = (document.getElementById("create-input-stock") as any).value;
        const product: Product = {
            name: name,
            brand: brand,
            price: price,
            stock: stock,
            pictureUrl: ""
        }
        store.addProduct(product);
    }

    return (
        <Box padding={1}>
            <Tabs value={tabIndex} onChange={handleTabChange} aria-label="admin tabs">
                <Tab label="Product List" />
                <Tab label="Dashboard" />
            </Tabs>
            {tabIndex === 0 &&
                <Container>
                    <Grid2 container spacing={3}>
                        <Grid2 container>
                            <Grid2 size={12}>
                                <IconButton onClick={addProduct} sx={{ color: green[500] }} aria-label="">
                                    <Add ></Add>
                                    ADD PRODUCT
                                </IconButton>
                            </Grid2>
                            <TextField id="create-input-name" label="Name" type="" ></TextField>
                            <TextField id="create-input-brand" label="Brand" type="" ></TextField>
                            <TextField id="create-input-price" type="number" label="Price" ></TextField>
                            <TextField id="create-input-stock" type="number" label="Stock"></TextField>
                        </Grid2>
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