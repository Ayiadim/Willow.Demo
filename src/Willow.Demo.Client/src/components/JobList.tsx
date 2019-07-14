import * as React from "react";
import Job from "../models/Job";
import '../css/main.css';
import '../css/colors.css';

interface State {
    jobs: Array<Job>; 
}

interface IJobItemProps {
    job: Job;
}

function JobItem(props: IJobItemProps) {
	let rowColor = props.job.status.trim().toLowerCase();
    return (
        <tr className={rowColor} onClick={UpdateJobStatus(props.job)}>
            <td>{props.job.id}</td>
            <td>${props.job.name}</td>
            <td>{props.job.floor}</td>
            <td>{props.job.status}</td>
            <td>{props.job.roomType.name}</td>
        </tr>
    );
}

function UpdateJobStatus(job: Job) {
    let response = await fetch(`http://localhost:5000/api/jobs/status`, {
	    method: 'PUT',
	    body: Json.stringify(job),
	    headers: {
		    'Content-Type': 'application/json'
	    }
    });
	
	return response.success;
}

class JobList extends React.Component<{}, State> {
   constructor() {
       super();

       this.state = { 
           jobs: [] 
       };
   }
   
   public componentDidMount() {
       const loadData = async () => {
        const results = await fetch(`http://localhost:5000/api/jobs`);
        const data: Array<Job> = await results.json();
        this.setState({ jobs: data })
       };

       loadData();
   }
   
   public render() {        
       return(
           <div>
               <div><strong>Jobs:</strong></div>
               <table className='table'>
                   <thead>
                       <tr>
                           <th>JobID</th>
                           <th>Name</th>
                           <th>Floor</th>
                           <th>Status</th>
                           <th>Room Name</th>
                       </tr>
                    </thead>
                    <tbody>
                        { this.state.jobs.map(j => <JobItem key={j.id} job={j} />)}
                    </tbody>
                </table>
           </div>  
       );
   }
}

export default JobList;