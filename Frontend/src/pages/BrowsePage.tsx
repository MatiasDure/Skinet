import { useState } from "react";
import Browse from "../features/browse/components/Browse";
import FilterModal from "../features/browse/components/FilterModal";
import { Button } from "@mui/material";
import { FilterList } from "@mui/icons-material";
import { useFilters } from "../features/browse/hooks/useFilters";
import { useBrowse } from "../features/browse/hooks/useBrowse";

export default function BrowsePage() {
    const [IsFilterOpen, setIsFilterOpen] = useState<boolean>(false);
    const [selectedFilters, setSelectedFilters] = useState<Record<string, string[]>>({});
    const { data: filters, isLoading, error } = useFilters();
    const { data: products, isLoading: areProductsLoading, error: productsError} = useBrowse(selectedFilters);

    return (
        <div style={{ display: "flex", flexDirection: "column", gap: 12 }}>
            <Button
                variant="outlined"
                startIcon={<FilterList />}
                sx={{ alignSelf: "end" }}
                onClick={() => setIsFilterOpen(true)}
            >
                Filters
            </Button>

            {isLoading && <div>Loading filters...</div>}
            {error && <div style={{ color: "red" }}>Error loading filters: {error}</div>}

            <div style={{ fontSize: 12, color: "#555" }}>
                Selected filters: {Object.entries(selectedFilters).map(([key, values]) => `${key}: ${values.length} selected`).join(" | ") || "None"}
            </div>

            {IsFilterOpen && (
                <FilterModal
                    onClose={() => setIsFilterOpen(false)}
                    filters={filters}
                    isOpen={IsFilterOpen}
                    onApply={setSelectedFilters}
                />
            )}

            <Browse 
                data={products}
                isLoading={areProductsLoading}
                error={productsError}
            />
        </div>
    );
}