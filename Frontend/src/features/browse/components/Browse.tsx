import { useBrowse } from "../hooks/useBrowse"
import ProductCard from "./ProductCard";


export default function Browse() {
    const {data, isLoading, error} = useBrowse();

    if(isLoading) return <>Loading...</>
    if(error) return <>Error...</>

    return (
        <div style={{display: "grid", gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr", gap: ".8rem"}}>
            {data?.Data.map(d => {
                return <ProductCard product={d} />
            })}
        </div>
    )
}