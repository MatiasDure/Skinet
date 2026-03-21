export function parseFiltersToParams(rawFilters: Record<string, string[]>) : URLSearchParams {
    const params = new URLSearchParams();

    for(const key in rawFilters) {
        rawFilters[key].forEach(f => params.append(key,f));
    }
    return params;
}