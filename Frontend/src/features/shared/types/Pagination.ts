export type Pagination<T> = {
    Page: number,
    Limit: number,
    Count: number,
    Data: T[],
}