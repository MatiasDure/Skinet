import { useEffect, useMemo, useState } from "react";
import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Button,
    FormControl,
    FormLabel,
    FormGroup,
    FormControlLabel,
    Checkbox,
    Divider,
    Typography
} from "@mui/material";
import { type Filter } from "../types/filter";

type SelectedFilters = Record<string, string[]>;

type Props = {
    filters: Filter[];
    isOpen: boolean;
    onClose: () => void;
    onApply?: (selected: SelectedFilters) => void;
};

export default function Filter(props: Props) {
    const { filters, isOpen, onClose, onApply } = props;
    const [selectedValues, setSelectedValues] = useState<Record<string, Set<string>>>({});

    useEffect(() => {
        const init: Record<string, Set<string>> = {};
        filters.forEach(f => {
            init[f.Name] = new Set();
        });
        setSelectedValues(init);
    }, [filters]);

    const selected = useMemo<SelectedFilters>(() => {
        const output: SelectedFilters = {};
        for (const key of Object.keys(selectedValues)) {
            output[key] = Array.from(selectedValues[key]);
        }
        return output;
    }, [selectedValues]);

    const handleToggle = (filterName: string, value: string) => {
        setSelectedValues(prev => {
            const next = { ...prev };
            const values = new Set(prev[filterName] ?? []);

            if (values.has(value)) {
                values.delete(value);
            } else {
                values.add(value);
            }

            next[filterName] = values;
            return next;
        });
    };

    const handleClear = () => {
        const next: Record<string, Set<string>> = {};
        filters.forEach(f => {
            next[f.Name] = new Set();
        });
        setSelectedValues(next);
    };

    const handleApply = () => {
        if (onApply) {
            onApply(selected);
        }
        onClose();
    };

    return (
        <Dialog open={isOpen} onClose={onClose} fullWidth maxWidth="sm">
            <DialogTitle>Filters</DialogTitle>
            <DialogContent>
                {filters.length === 0 ? (
                    <Typography variant="body2" color="text.secondary">
                        No filters available.
                    </Typography>
                ) : (
                    filters.map(filter => (
                        <FormControl key={filter.Name} component="fieldset" sx={{ mt: 2, width: "100%" }}>
                            <FormLabel component="legend">{filter.Name}</FormLabel>
                            <FormGroup>
                                {filter.Values.map(value => (
                                    <FormControlLabel
                                        key={`${filter.Name}-${value}`}
                                        control={
                                            <Checkbox
                                                checked={selectedValues[filter.Name]?.has(value) ?? false}
                                                onChange={() => handleToggle(filter.Name, value)}
                                            />
                                        }
                                        label={value}
                                    />
                                ))}
                            </FormGroup>
                            <Divider sx={{ mt: 1 }} />
                        </FormControl>
                    ))
                )}
            </DialogContent>
            <DialogActions>
                <Button onClick={handleClear}>Clear</Button>
                <Button onClick={handleApply} variant="contained">
                    Apply
                </Button>
            </DialogActions>
        </Dialog>
    );
}