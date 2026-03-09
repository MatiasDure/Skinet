import { BROWSE_MOCK_API_RESPONSE } from "../utils/mocks/browse";

export const fetchBrowseProducts = async (signal?: AbortSignal) => {
    if(import.meta.env.DEV) {
        return Promise.resolve(BROWSE_MOCK_API_RESPONSE);
    } else {
        const res = await fetch("https://localhost:5001/api/products", {
            method: "GET",
            signal: signal
        });
    
        if(!res.ok) 
            throw new Error("Something went wrong");
            
        return await res.json();
    }
}