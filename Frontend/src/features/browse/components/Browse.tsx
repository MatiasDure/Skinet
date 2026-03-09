import { useBrowse } from "../hooks/useBrowse"

export default function Browse() {
    const {data, isLoading, error} = useBrowse();

    if(isLoading) return <>Loading...</>
    if(error) return <>Error...</>

    return (
        <div>

        </div>
    )
}