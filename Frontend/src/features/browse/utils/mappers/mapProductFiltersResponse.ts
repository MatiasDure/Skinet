import type { Filter } from "../../types/filter";

export function mapProductFiltersResponse(data: any): Filter {
    return {
        Name: data.name,
        Values: data.values
    }
}