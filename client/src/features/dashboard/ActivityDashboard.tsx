import { Grid2} from "@mui/material";
import ActivityList from "./ActivityList";
import ActivityDetails from "../activities/details/activityDetails";
import ActivityForm from "../activities/form/ActivityForm";
type Props = {
    activities: Activity[];
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    selectedActivity: Activity | null;    
    openForm: (id?: string) => void;
    editMode: boolean;
    closeForm: () => void;
 
    deleteActivity: (id: string) => void;
}
export default function ActivityDashboard({activities, selectActivity, cancelSelectActivity,
   selectedActivity, openForm, editMode, closeForm, deleteActivity}: Props) {
  return (
    <Grid2 container spacing={3}>
      <Grid2 size={7}>
        <ActivityList
          activities={activities}
          selectActivities={selectActivity}
          deleteActivity={deleteActivity}
        />
      </Grid2>

      <Grid2 size={5}>
        {selectedActivity && !editMode &&(
          <ActivityDetails
            selectedActivity={selectedActivity}
            cancelSelectActivity={cancelSelectActivity}
            openForm={openForm}
            
          
          />
        )}
        {editMode && 
        <ActivityForm closeForm={closeForm} activity = {selectedActivity}
    />}
      </Grid2>
    </Grid2>
  );
}
