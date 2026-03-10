namespace Application.Products;

public record ProductFilterDto(string Name, IReadOnlyList<string> Values);
