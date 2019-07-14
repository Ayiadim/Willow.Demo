import RoomType from "../models/RoomType";

interface Job {
    id: string;
	contractorId: number;
    name: string;
    status: string;
	floor: number;
	room: number;
	delayReason: string;
	dateCreated: Date;
	dateCompleted: Date;
	dateDelayed: Date;
    statusNum: number;
    rJobId: number;
    roomType: RoomType;
}

export default Job;