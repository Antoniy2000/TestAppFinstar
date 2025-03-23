import http from "../http-common";
import { ISomeDataGetResult } from "../models/data/someDataGetResult";
import IDataLoadParameters from "../models/options/dataLoadParameters";

const getData = async (loadParams: IDataLoadParameters) => {
    const res = await http.get<ISomeDataGetResult>("/TestAppFinstar/GetData"
        + `?skip=${loadParams?.skip}`
        + `&take=${loadParams.take}`
        + (loadParams.valueContains ? `&valueContains=${loadParams?.valueContains}` : "")
        );
    return res.data;
};

const TestAppFinstarService = {
    getData
};

export default TestAppFinstarService;