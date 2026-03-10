import { PPRODUCT_FILTERS_MOCK_API_RESPONSE } from "../utils/mocks/filters";

export const fetchProductFilters = async (signal? : AbortSignal) => {
    if(import.meta.env.DEV) {
        return Promise.resolve(PPRODUCT_FILTERS_MOCK_API_RESPONSE);
    } else {
        const res = await fetch("https://localhost:5001/api/products/filters", { 
            method: "GET",
            signal
        });
    
        if(!res.ok) 
            throw new Error("Something went wrong");
            
        return await res.json();
    }
}