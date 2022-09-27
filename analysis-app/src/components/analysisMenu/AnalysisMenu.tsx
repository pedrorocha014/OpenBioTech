import Box from '@mui/material/Box';
import Divider from '@mui/material/Divider';
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemText from '@mui/material/ListItemText';
import Toolbar from '@mui/material/Toolbar';
import { useNavigate } from 'react-router-dom';

function AnalysisMenu() {

  let navigate = useNavigate();

  const drawer = (
        <div>
          <Toolbar />
          <Divider />
          <h4>Analysis</h4>
          <List>
            <ListItem key="ProteinSequence" disablePadding>
              <ListItemButton onClick={() => navigate('/proteinSequence')}>
                <ListItemText primary="Protein Sequence" />
              </ListItemButton>
            </ListItem>
          </List>
          <Divider />
          <h4>Analysis Results</h4>
          <List>
            {['Results'].map((text, index) => (
              <ListItem key={text} disablePadding>
                <ListItemButton onClick={() => navigate('/' + text)} >
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </div>
    );

    return (
        <Box>   
            {drawer}
        </Box>
      );
}


export default AnalysisMenu;