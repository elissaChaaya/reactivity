import { Box } from "@mui/material";
import ActivityCard from "./ActivityCard";
type Props = {
    activities: Activity[]
    selectActivities: (id: string) => void;
    deleteActivity: (id: string) => void;

}
export default function ActivityList({activities, selectActivities, deleteActivity}: Props) {
  return (
    <Box sx={{display: 'flex', flexDirection: 'column', gap: 3  }}>
        {activities.map(activity => ( <ActivityCard key={activity.id} activity={activity} selectActivity={selectActivities} deleteActivity={deleteActivity}/> ))}
    </Box>
  )
}
