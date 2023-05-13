import { UncontrolledAccordion, AccordionItem,AccordionHeader,AccordionBody, Button, Card } from "reactstrap"
import {BLACK, DIRTY_WHITE, LIGHT_GRAY, SLATE, WHITE} from "../../Utils/Constants";

export const UserMoochPostDetails = ({userId,membershipId,moochPostId,isMooched,availabilityStartDate,availabilityEndDate}) => 
{
    let startDate = new Date(availabilityStartDate)
    let endDate = new Date(availabilityEndDate)
    return <>
    <Card style={{color: `${WHITE}`,
        backgroundColor: `${SLATE}`,
        border: `2px solid ${LIGHT_GRAY}`,
        padding: '15px',
        margin: '5px'
      }}>
    <div>User Id : {userId}</div>
    <div>Membership Id : {membershipId}</div>
    <div>Mooch Post Id : {moochPostId}</div>
    <div>Mooched : {isMooched ? "True" : "False"}</div>
    <div>Availability Start : {startDate.toLocaleDateString()}</div>        
    <div>End Date : {endDate.toLocaleDateString()}</div>
    </Card>
    </>
   
}


