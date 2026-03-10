import { useEffect, useState } from "react";
import type { Filter } from "../types/filter";
import { fetchProductFilters } from "../api/fetchProductFilters";
import { mapProductFiltersResponse } from "../utils/mappers/mapProductFiltersResponse";

export function useFilters() {
    const [data, setData] = useState<Filter[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const abort = new AbortController();

        const fetchFilters = async () => {
            try {
                const json: any[] = await fetchProductFilters();
                setData(json.map(f => mapProductFiltersResponse(f)))
            } catch(ex) {
                setError((ex as Error).message);
            } finally {
                setIsLoading(false);
            }
        }

        fetchFilters();

        return () => {
            abort.abort();
        }
    }, []);


    return {
        data,
        isLoading,
        error
    }
}