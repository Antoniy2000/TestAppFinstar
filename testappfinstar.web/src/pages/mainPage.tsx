import { Layout } from "antd"
import { Content } from "antd/es/layout/layout";
import Title from "antd/es/typography/Title";
import { SomeDataTable } from "../components/someDataTable";


export const MainPage = () => {
    return (
        <Layout>
            <Title style={{textAlign: "center"}}>
                Main Page
            </Title>
            <Content>
                <SomeDataTable />
            </Content>
        </Layout>
    );
}