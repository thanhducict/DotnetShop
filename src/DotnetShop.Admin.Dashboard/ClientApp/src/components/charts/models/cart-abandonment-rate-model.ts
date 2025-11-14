export interface CartAbandonmentRateModel {
    avgRate: number;
    avgComparedRate: number;
    ratesByTime: CartAbandonmentRateByTime[];
}

export interface CartAbandonmentRateByTime {
    time: string;
    rate: number;
}
