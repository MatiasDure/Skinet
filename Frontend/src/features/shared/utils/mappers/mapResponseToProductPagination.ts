import type { Pagination } from "../../types/Pagination";
import type { Product } from "../../types/Product";
import { mapResponseToProduct } from "./mapResponseToProduct";

export function mapResponseToProductPagination(json: any) : Pagination<Product> {
    return {
        Page: json.page,
        Limit: json.limit,
        Count: json.count,
        Items: json.items.map((it: any) => mapResponseToProduct(it))
    }
}