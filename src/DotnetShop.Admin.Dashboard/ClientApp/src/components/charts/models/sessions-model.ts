export interface SessionModel {
    totalSessions: number;
    totalComparedSessions: number;
    sessionsByTime: SessionByTime[];
}

export interface SessionByTime {
    time: string;
    sessionCount: number;
}
