import { ShoppingCart } from "@mui/icons-material";
import { Badge, Button, Link } from "@mui/material";
import Logo from "/images/logo.png";

export default function Header() {

    return(
        <header style={{display: "flex", justifyContent: "space-between", alignItems: "center", borderBottom: "1px solid rgba(0,0,0,.2)", paddingBottom: "1rem"}}>
            <div>
                <img src={Logo} alt="Logo" />
            </div>
            <nav style={{display: "flex", gap: "1rem"}}>
                <Link href="#" underline="none">HOME</Link>
                <Link href="#" underline="none">SHOP</Link>
                <Link href="#" underline="none">CONTACT</Link>
            </nav>
            <div style={{display: "flex", gap: "1rem", alignItems: "center", }}>
                <Badge badgeContent={4} color="primary" style={{marginRight: "1rem"}}>
                    <ShoppingCart fontSize="large" />
                </Badge>
                <Button variant="outlined">Login</Button>
                <Button variant="outlined">Login</Button>
            </div>
        </header>
    )
} 