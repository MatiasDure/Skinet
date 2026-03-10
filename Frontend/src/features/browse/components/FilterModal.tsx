import { Dialog, DialogTitle } from "@mui/material";
import { type Filter } from "../types/filter";

type Props = {
    filters: Filter[],
    isOpen: boolean,
    onClose: () => void
}

export default function Filter(props: Props) {
    const {filters, isOpen, onClose} = props;

    return (
        <Dialog open={isOpen} onClose={onClose}>
            <DialogTitle>
                Filters
            </DialogTitle>
        </Dialog>
    )
}