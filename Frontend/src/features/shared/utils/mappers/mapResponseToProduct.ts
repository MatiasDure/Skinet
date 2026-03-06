import type { Product } from "../../types/Product";

export function mapResponseToProduct(json: any) : Product {
    return {
        Id: json.id,
        Name: json.name,
        Description: json.description,
        Price:json.price,
        PictureUrl: json.pictureUrl,
        Type: json.type,
        Brand: json.brand,
        QuantityInStock:json.quantityInStock,
    }
}