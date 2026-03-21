import type { Pagination } from "../../shared/types/Pagination";
import type { Product } from "../../shared/types/Product";
import { useBrowse } from "../hooks/useBrowse"
import ProductCard from "./ProductCard";

type Props = {
    data: Pagination<Product> | null,
    isLoading: boolean,
    error: string | null
}

export default function Browse(props : Props) {
    const {data, isLoading, error} = props;

    console.log(data);

    if(isLoading) return <>Loading...</>
    if(error) return <>Error... {error}</>

    return (
        <div style={{display: "grid", gridTemplateColumns: "1fr 1fr 1fr 1fr 1fr", gap: ".8rem"}}>
            {data?.Data.map(d => {
                return <ProductCard key={d.Id} product={d} />
            })}
        </div>
    )
}