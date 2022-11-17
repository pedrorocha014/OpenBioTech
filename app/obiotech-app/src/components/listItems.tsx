import * as React from 'react';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import { useNavigate } from 'react-router-dom';
import HomeIcon from '@mui/icons-material/Home';
import AnnouncementIcon from '@mui/icons-material/Announcement';
import ArticleIcon from '@mui/icons-material/Article';
import CallIcon from '@mui/icons-material/Call';
import AssignmentIcon from '@mui/icons-material/Assignment';
import { Box, Collapse, List } from '@mui/material';
import { ExpandLess, ExpandMore } from '@mui/icons-material';


export function MainListItems() {

  let navigate = useNavigate();

  const drawer = (
    <React.Fragment>
    <ListItemButton  onClick={() => navigate('/')}>
      <ListItemIcon>
        <HomeIcon />
      </ListItemIcon>
      <ListItemText primary="Home" />
    </ListItemButton>
    {/* <ListItemButton onClick={() => navigate('/lastUpdates')}>
      <ListItemIcon>
        <AnnouncementIcon />
      </ListItemIcon>
      <ListItemText primary="Last Updates" />
    </ListItemButton>
    <ListItemButton onClick={() => navigate('/documentation')}>
      <ListItemIcon>
        <ArticleIcon />
      </ListItemIcon>
      <ListItemText primary="Documentation" />
    </ListItemButton>
    <ListItemButton onClick={() => navigate('/contactUs')}>
      <ListItemIcon>
        <CallIcon />
      </ListItemIcon>
      <ListItemText primary="Contact Us" />
    </ListItemButton> */}
  </React.Fragment>
    );

    return (
        <Box>   
            {drawer}
        </Box>
      );
}

export function ToolsListItems() {
  const [openTools, setToolsOpen] = React.useState(false);
  let navigate = useNavigate();

  const handleCalculatorClick = () => {
    setToolsOpen(!openTools);
  };

  const drawer = (
    <React.Fragment>
      <List>
      <ListItemButton onClick={handleCalculatorClick}>
        <ListItemIcon>
          <AssignmentIcon />
        </ListItemIcon>
        <ListItemText primary="Tools" />
        {openTools ? <ExpandLess/> : <ExpandMore/>} 
      </ListItemButton>
      <Collapse in={openTools} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          <ListItemButton sx={{ pl: 4 }}>
            <ListItemIcon>
              <AssignmentIcon/>
            </ListItemIcon>
            <ListItemText primary="RMSD" />
          </ListItemButton>
          <ListItemButton  sx={{ pl: 4 }} onClick={() => navigate('/proteinSequence')}>
            <ListItemIcon>
              <AssignmentIcon />
            </ListItemIcon>
            <ListItemText primary="Sequence" />
          </ListItemButton>
        </List>
      </Collapse>
    </List>
  </React.Fragment>
    );

    return (
        <Box>   
            {drawer}
        </Box>
      );
}