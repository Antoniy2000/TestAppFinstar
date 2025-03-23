import { useEffect, useState } from "react";
import TestAppFinstarService from "../services/testAppFinstarService";
import Column from "antd/es/table/Column";
import { Input, Table } from "antd";
import { ISomeDataGetModel } from "../models/data/someDataGetResult";

export const SomeDataTable = () => {
    const [skip, setSkip] = useState(0);
    const [pageSize, setPageSize] = useState(20);
    const [totalCount, setTotalCount] = useState(pageSize);
    const [valueFilter, setValueFilter] = useState<string>();
    const [data, setData] = useState<ISomeDataGetModel[]>();
    const [loading, setLoading] = useState(false);

    useEffect(() => { fetchData() }, [ skip, valueFilter, pageSize ]);
    
    const fetchData = async () => {
        setLoading(true);
        
        const result = await TestAppFinstarService.getData({ skip: skip, take: pageSize, valueContains: valueFilter});
        setData(result.data);
        setTotalCount(result.totalCount);

        setLoading(false);
    };

    const pagination = { 
        total: totalCount + 1, 
        pageSize: pageSize, 
        current: skip, 
        onChange: (page:number, pageSize:number) => 
        { 
            setPageSize(pageSize);
            setSkip((page - 1) * pageSize);
        } 
    }

    return (
        <Table<ISomeDataGetModel> 
            dataSource={data}
            loading={loading}
            rowKey={(x => x.ordinal)}
            pagination={pagination}>
            <Column 
                title="Ordinal" 
                dataIndex="ordinal" />
            <Column 
                title="Code" 
                dataIndex="code" />
            <Column 
                filterDropdown={<Input value={valueFilter} onChange={e => setValueFilter(e.target.value)}/>} 
                title="Value" 
                dataIndex="value" />
        </Table>
    )
}