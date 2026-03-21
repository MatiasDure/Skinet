import { useEffect, useState } from "react";
import type { Product } from "../../shared/types/Product";
import type { Pagination } from "../../shared/types/Pagination";
import { mapResponseToProductPagination } from "../../shared/utils/mappers/mapResponseToProductPagination";
import { fetchBrowseProducts } from "../api/fetchBrowseProducts";
import { mapSelectedFilters } from "../utils/mappers/mapSelectedFilters";

export function useBrowse(filters: Record<string, string[]>) {
    const [data, setData] = useState<Pagination<Product> | null>(null);
    const [error, setError] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    useEffect(() => {
        const abort = new AbortController();

        const fetchProducts = async () => {
            try{
                const json = await fetchBrowseProducts(mapSelectedFilters(filters));
                setData(mapResponseToProductPagination(json));
            } catch(ex) {
                setError((ex as Error).message);
            } finally {
                setIsLoading(false);
                console.log("Run again");
            }
        }

        fetchProducts();

        return () => {
            abort.abort();
        }
    }, [filters]);
    
    return {
        data,
        isLoading,
        error
    }
}