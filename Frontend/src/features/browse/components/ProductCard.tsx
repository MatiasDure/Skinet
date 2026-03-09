import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import type { Product } from "../../shared/types/Product";

type Props = {
    product: Product
}

export default function ProductCard({product} : Props) {
    return(
        <Card sx={{display: "flex" , flexDirection: "column", height: "100%", justifyContent: "space-between"}}>
            <CardMedia component="img" image={product.PictureUrl} alt={product.Name}></CardMedia>
            <CardContent>
                <Typography gutterBottom variant="h6">{product.Name}</Typography>
                <Typography>${product.Price.toFixed(2)}</Typography>
            </CardContent>
            <CardActions>
                <Button variant="outlined" disableElevation fullWidth startIcon={<AddShoppingCartIcon />}>
                    add to cart
                </Button>
            </CardActions>
        </Card>
    )
}