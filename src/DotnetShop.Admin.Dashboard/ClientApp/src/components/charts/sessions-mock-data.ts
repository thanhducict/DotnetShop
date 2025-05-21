import { CustomChartType } from "../shared/utils";
import { ChartModel } from "./models/chart-model";
import { SessionModel } from "./models/sessions-model";

export const getSessionsMockData = (isComparisonMode: boolean) => {
    const sessionsData: SessionModel = {
        totalSessions: 1000,
        totalComparedSessions: -65,
        sessionsByTime: [
            { time: "May 16, 2025 12:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 01:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 02:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 03:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 04:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 05:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 06:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 07:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 08:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 09:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 10:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 11:00 AM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 12:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 01:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 02:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 03:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 04:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 05:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 06:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 07:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 08:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 09:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 10:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
            { time: "May 16, 2025 11:00 PM", sessionCount: Math.floor(Math.random() * 100) + 50 },
        ],
    };

    let sessionsModel: ChartModel;

    if (isComparisonMode) {
        sessionsModel = {
            charType: CustomChartType.Sessions,
            title: "Sessions",
            generalValue: `${sessionsData.totalSessions}`,
            comparisonValue: `${sessionsData.totalComparedSessions}`,
            labels: ["Last Year", "June 15, 2025 - July 15, 2025"],
            data: [100, 35],
        };
    } else {
        sessionsModel = {
            charType: CustomChartType.Sessions,
            title: "Sessions",
            generalValue: `${sessionsData.totalSessions}`,
            labels: sessionsData.sessionsByTime.map((item) => item.time),
            data: sessionsData.sessionsByTime.map((item) => item.sessionCount),
        };
    }

    return sessionsModel;
};
