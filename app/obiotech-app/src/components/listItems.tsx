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
  </React.Fragment>
    );

    return (
      <div>   
          {drawer}
      </div>
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
          <ListItemButton sx={{ pl: 4 }} onClick={() => navigate('/rmsd')}>
            <ListItemIcon>
              <AssignmentIcon/>
            </ListItemIcon>
            <ListItemText primary="RMSD" />
          </ListItemButton>
          <ListItemButton  sx={{ pl: 4 }} onClick={() => navigate('/sequence')}>
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
        <div>   
            {drawer}
        </div>
      );
}