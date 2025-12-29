import { Box, Container, CssBaseline, Typography} from "@mui/material";

import {  useState } from "react";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/dashboard/ActivityDashboard";

import { useActivities } from "../../lib/hooks/useActivities";

function App() {

 
  const [selectedActivity, setSelectedActivity] = useState<Activity | null>(null);
  const [editMode, setEditMode] = useState(false);

  const { activities, isPending } = useActivities();    


  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities!.find(a => a.id === id) || null);
  }

  const handleCancelSelectActivity = () => {
    setSelectedActivity(null);
  }

  const handleOpenForm = (id?: string) => {
    if (id) handleSelectActivity(id);
    else handleCancelSelectActivity();
    setEditMode(true);
  }

  const handleCloseForm = () => {
    setEditMode(false);
  }

  const handleSubmitForm = (activity: Activity) => {
    // if (activity.id) {
    //   setActivities(activities.map(a => a.id !== activity.id ? activity: a));
     
    // } else {
    //   const newActivity = {...activity, id: activities.length.toString()}
    //   setActivities([...activities, newActivity]);
    // }
    console.log(activity);
    setEditMode(false);
  }

  const handleDeleteActivity = (id: string) => {
    //setActivities(activities.filter(a => a.id !== id));
    console.log(id);
  }
  return (
    //can only return one thing, so we wrap it all up in div or fragment
    <Box sx={{bgcolor: '#eeeeee' , minHeight: '100vh'}}>
    <CssBaseline/>

     <NavBar openForm={handleOpenForm}/>
     <Container maxWidth="xl" sx={{ mt: 3 }}>
      {!activities || isPending ? <Typography>Loading activities...</Typography> :(

      <ActivityDashboard
      activities={activities}
      selectActivity={handleSelectActivity}
      cancelSelectActivity={handleCancelSelectActivity}
      selectedActivity={selectedActivity}
      editMode={editMode}
      closeForm={handleCloseForm}
      openForm={handleOpenForm}
      submitForm={handleSubmitForm}
      deleteActivity={handleDeleteActivity}
      /> )}
      </Container>
    </Box>
  );
}

export default App
