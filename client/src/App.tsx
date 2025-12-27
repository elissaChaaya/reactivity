import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {

  const [activities, setActivities] = useState<Activity[]>([]); //using the type we created in index.d.ts file (typescript)


  useEffect( () => { //this function will execute when the component above it mounts 
     axios.get<Activity[]>('https://localhost:5001/api/activities') //axios used instead of fetch, the .then for response conversion is removed
     .then( response => setActivities(response.data)) //returns a JS promise, to unwrap the promise .then is used
     return () => {}
  }, [])
  return (
    //can only return one thing, so we wrap it all up in div or fragment
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {" "}
        //using list from materialUI
        {activities.map(
          (
            activity //to loop over we use map, map is used on arrays
          ) => (
            <ListItem key={activity.id}>
              <ListItemText>{activity.title}</ListItemText>
            </ListItem>
          )
        )}
      </List>
    </>
  );
}

export default App
