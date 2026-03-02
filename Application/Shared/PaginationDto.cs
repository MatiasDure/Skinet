namespace Application;

public record PaginationDto<T>(
    int Page,
    int Limit,
    int Count,
    IReadOnlyList<T> Data
);
