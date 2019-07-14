import * as React from "react";
import Job from "../models/Job";
import '../css/main.css';
import '../css/colors.css';

interface State {
    jobs: Array<Job>; 
}

interface IJobItemProps {
    job: Job;
    onClick: ((job: Job) => void)
}

function JobItem(props: IJobItemProps) {
    let rowColor = props.job.status.replace(/\s/g, '').toLowerCase();
    return (
        <tr className={rowColor} onClick={() => props.onClick(props.job)}>
            <td>{props.job.id}</td>
            <td>{props.job.name}</td>
            <td>{props.job.floor}</td>
            <td>{props.job.status}</td>
            <td>{props.job.roomType.name}</td>
        </tr>
    );
}

class JobList extends React.Component<{}, State> {
   constructor() {
       super();

       this.state = { 
           jobs: [] 
       };

       this.updateJobStatus = this.updateJobStatus.bind(this);
   }
   
   public componentDidMount() {
       const loadData = async () => {
           const results: any = await fetch(`http://localhost:5000/api/jobs`);
           const data: any = await results.json();
           const jobs: Array<Job> = data.items;
           this.setState({ jobs: jobs });
       };

       loadData();
   }
   
   public updateJobStatus(job: Job) {
       // Shortcut taken, there's a better way.
       if (job.status !== 'In Progress' && job.status !== 'Delayed') {
           return;
       }
       
       const updateStatus = async () => {
          const results: any = await fetch(`http://localhost:5000/api/jobs/status`, {
              method: 'PUT',
              body: JSON.stringify({job}),
              headers: {
                  'Content-Type': 'application/json'
              }
          });
        
          const data: any = await results.json();
          const success: boolean = data.success;
          
          if (success) {
              job.status = 'Complete';
              this.setState({ 
                  jobs: this.state.jobs
              });
          }
          else {
              alert("Failed to complete job");
          }
       };

       updateStatus();
   }
   
   public render() {
       return(
           <div>
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
                        { this.state.jobs.map(j => <JobItem key={j.id} job={j} onClick={this.updateJobStatus} />)}
                    </tbody>
                </table>
           </div>  
       );
   }
}

export default JobList;