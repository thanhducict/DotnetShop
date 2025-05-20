export interface Session {
    totalSessions: number;
    totalComparedSessions: number;
    sessionsByTime: SessionByTime[];
}

export interface SessionByTime {
    time: string;
    sessionCount: number;
}
