import { create } from "zustand";
import { Product } from "../model/Product";

type ProductStoreState = {
    products: Product[]
}
type ProductStoreAction = {
    loadProduct: () => Promise<void>
    updateProduct: (product: Product) => Promise<Product>
    deleteProduct: (id: string) => Promise<Product>
    addProduct: (product: Product) => Promise<Product>
}

export const useProductStore = create<ProductStoreState & ProductStoreAction>((set, get) => (
    {
        products: [],
        loadProduct: async () => {
            const res = await ProductService.getProducts();
            set({ products: res })
        },
        updateProduct: async (product: Product) => {
            const updated = await ProductService.updateProduct(product);
            await get().loadProduct();
            return updated;
        },
        deleteProduct: async (id: string) => {
            const deleted = await ProductService.deleteProduct(id);
            await get().loadProduct();
            return deleted;
        },
        addProduct: async (product: Product) => {
            const newProduct = await ProductService.addProduct(product);
            await get().loadProduct();
            return newProduct;
        }
    }
))
type ProductService = {
    getProducts: () => Promise<Product[]>
    getProductById: (id: string) => Promise<Product>
    updateProduct: (product: Product) => Promise<Product>
    deleteProduct: (id: string) => Promise<Product>
    addProduct: (product: Product) => Promise<Product>
}
export const ProductService: ProductService = {
    getProducts: async () => {
        const url = 'https://localhost:7265/api/Shoe/GetAllShoe';
        const res = await fetch(url);
        const json = await res.json();
        return json;
    },
    getProductById: async (id: string) => {
        const url = 'https://localhost:7265/api/Shoe/GetShoeById/' + id;
        const res = await fetch(url);
        const json = await res.json();
        return json;
    },
    updateProduct: async (product: Product) => {
        const url = "https://localhost:7265/api/Shoe/UpdateShoe";
        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Set the Content-Type header to application/json
            },
            body: JSON.stringify(product),
        })
        if (res) {
            return await res.json();
        }
    },
    deleteProduct: async (id: string) => {
        const url = "https://localhost:7265/api/Shoe/DeleteShoe/" + id;
        const res = await fetch(url, {
            method: 'DELETE',
        })
        if (res) {
            return await res.json();
        }
    },
    addProduct: async (product: Product) => {
        const url = "https://localhost:7265/api/Shoe/CreateShoe";
        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json' // Set the Content-Type header to application/json
            },
            body: JSON.stringify(product),
        }
        )
        return await res.json();
    }
}