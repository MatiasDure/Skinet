export const fetchBrowseProducts = async (signal?: AbortSignal) => {
    const res = await fetch("https://localhost:5001/api/products", {
        method: "GET",
        signal: signal
    });

    if(!res.ok) 
        throw new Error("Something went wrong");
        
    return await res.json();
}