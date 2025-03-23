export interface ISomeDataGetResult {
    data: ISomeDataGetModel[];
    totalCount: number;
}
export interface ISomeDataGetModel {
    ordinal: number;
    code: number;
    value: string;
}