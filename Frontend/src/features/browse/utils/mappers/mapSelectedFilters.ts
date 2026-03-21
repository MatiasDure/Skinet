export function mapSelectedFilters(rawFilters: Record<string, string[]>) : string {
    let filters: string = "";
    let iterations: number = 0;

    for(const key in rawFilters) {
        filters = filters.concat(`${key}=`);
        let values: string[] = rawFilters[key];

        values.forEach((v, index) => {
            filters = filters.concat(index == values.length - 1 ? v : `${v},`);
        });
        iterations++;

        if(Object.entries(rawFilters).length == iterations) break;

        filters = filters.concat("&");
    }
    
    return filters;
}