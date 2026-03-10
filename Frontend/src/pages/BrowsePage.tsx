import { useState } from "react";
import Browse from "../features/browse/components/Browse";
import FilterModal from "../features/browse/components/FilterModal";
import { Button } from "@mui/material";
import { FilterList } from "@mui/icons-material";
import { useFilters } from "../features/browse/hooks/useFilters";

export default function BrowsePage() {
    const [IsFilterOpen, setIsFilterOpen] = useState<boolean>(false);
    const {data: filters, isLoading, error} = useFilters();

    return (
        <div style={{display: "flex", flexDirection: "column"}}>
            <Button 
                variant="outlined" 
                startIcon={<FilterList />} 
                sx={{alignSelf: "end"}}
                onClick={() => setIsFilterOpen(true)}
            >
                Filters
            </Button>
            { IsFilterOpen && <FilterModal onClose={() => setIsFilterOpen(false)} filters={filters} isOpen={IsFilterOpen}/> }
            
            <Browse />
        </div>
    )
}