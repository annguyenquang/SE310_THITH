import Dialog from "@mui/material/Dialog";
import { useEditProductDialogStore } from "../../core/store/EditProductDialogStore"
import DialogTitle from "@mui/material/DialogTitle";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import TextField from "@mui/material/TextField";
import AttachMoneyOutlined from "@mui/icons-material/AttachMoneyOutlined";
import DialogActions from "@mui/material/DialogActions";
import ButtonGroup from "@mui/material/ButtonGroup";
import Button from "@mui/material/Button";
import React from "react";
import { useProductStore } from "../../core/store/ProductStore";

type EditProductDialogProps = {
}

export const EditProductDialog: React.FC<EditProductDialogProps> = () => {
    const store = useEditProductDialogStore();
    const productStore = useProductStore();
    const onSaveChange = async () => {
        const newName = (document.getElementById("input-product-name") as any).value;
        const newBrand = (document.getElementById("input-product-brand") as any).value;
        const newPrice = (document.getElementById("input-product-price") as any).value;
        const newStock = (document.getElementById("input-product-stock") as any).value;

        await store.updateProduct({
            id: store.product?.id,
            name: newName,
            brand: newBrand,
            price: newPrice,
            stock: newStock,
            pictureUrl: store.product?.pictureUrl ?? ""
        })
        await productStore.loadProduct();
        store.setDialogState(false);
    }

    function closeDialog(): void {
        store.setDialogState(false);
    }

    return (
        <Dialog open={store.open}>
            <DialogTitle>Edit Product</DialogTitle>
            <DialogContent>
                <DialogContentText>After input new value, please click on Save change</DialogContentText>
                <TextField id='input-product-name' autoFocus required margin='dense' variant='outlined' fullWidth label="Name" defaultValue={store.product?.name}></TextField>
                <TextField id='input-product-brand' autoFocus required margin='dense' variant='outlined' fullWidth label="Brand" defaultValue={store.product?.brand}></TextField>
                <TextField id='input-product-price' autoFocus required margin='dense' variant='outlined' fullWidth label="Price" type='number' defaultValue={store.product?.price} slotProps={{
                    input: {
                        startAdornment: <AttachMoneyOutlined></AttachMoneyOutlined>
                    }
                }}></TextField>
                <TextField id='input-product-stock' autoFocus required margin='dense' variant='outlined' fullWidth label="Stock" type='number' defaultValue={store.product?.stock}></TextField>

            </DialogContent>
            <DialogActions>
                <ButtonGroup variant="contained" aria-label="">
                    <Button onClick={closeDialog} color='warning'>Cancel</Button>
                    <Button onClick={onSaveChange}>Save changes</Button>
                </ButtonGroup>
            </DialogActions>
        </Dialog>
    )
}
