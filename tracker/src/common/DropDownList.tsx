import { KeyValuePair } from "../types";

type Args = {
    id: string | undefined;
    data: KeyValuePair[];
    value: string | number;
    change: (e: React.ChangeEvent<HTMLSelectElement>) => void;
};


const DropDownList = ({ id, data, value, change }: Args) => {
    return (
        <select id={id} defaultValue={value} value={value} onChange={ e => change(e)}>
            {data && data.map((item: KeyValuePair) => (
                <option key={item.key} value={item.key}>{ item.value }</option>
            ))}
        </select>
    )
}

export default DropDownList;