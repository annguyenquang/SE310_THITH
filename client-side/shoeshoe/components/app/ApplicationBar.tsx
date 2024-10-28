"use client"
import AppBar from '@mui/material/AppBar'
import Toolbar from '@mui/material/Toolbar'
import { Box, Button, Link, Typography } from '@mui/material';
import grey from '@mui/material/colors/grey';

export const ApplicationBar = () => {
    const pages = [
        {
            title: 'products',
            link: '/'
        },
        {
            title: 'admin',
            link: '/admin'
        },

    ]
    return (
        <AppBar position="static" color="warning">
            <Toolbar>
                <Typography variant="h6" color="white">ShoeShoe</Typography>
                <Box sx={{ marginLeft: 5, flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                    {pages.map((page) => (
                        <Button
                            key={page.link}
                            sx={{ my: 2, color: 'white', display: 'block', textTransform: 'none' }}
                        >
                            <Link href={page.link} underline='none'>
                                <Typography fontFamily={'monospace'} sx={{ color: grey[50], textDecoration: 'none' }}  >{page.title}</Typography>
                            </Link>
                        </Button>
                    ))}
                </Box>
            </Toolbar>
        </AppBar >
    )
}