export const deepMerge = (target: any, source: any) => {
    for (const key in source) {
        if (typeof source[key] === "object" && source[key] !== null) {
            if (target[key] === undefined) {
                target[key] = Array.isArray(source[key]) ? [] : {};
            }
            deepMerge(target[key], source[key]);
        } else {
            target[key] = source[key];
        }
    }
    return target;
};

export const sharedOptions = {
    responsive: true,
    maintainAspectRatio: false,
    aspectRatio: 2,
    plugins: {
        legend: {
            display: false,
        },
    },
    scales: {
        x: {
            grid: {
                drawOnChartArea: false,
            },
        },
        y: {
            grid: {
                drawOnChartArea: true,
            },
        },
    },
};

export enum CustomChartType {
    CartAbandonmentRateChart = "CartAbandonmentRateChart",
}
