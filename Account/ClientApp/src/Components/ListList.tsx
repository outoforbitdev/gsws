import React, { ChangeEventHandler, Component } from 'react';
import { EntityType, Entity } from '../Model/Entity';

interface ListListProps {
    lists: string[],
    changeList: ChangeList,
}

type ChangeList = (newList: string) => void;

interface ListListState {
    lists: string[],
}

export class ListList extends Component<ListListProps, ListListState> {

    constructor(props: ListListProps) {
        super(props);
        this.state = {
            lists: props.lists,
        }
    }

    render() {
        return (
            <table>
                {this.state.lists.map(list => <tr><td>{list}</td></tr>)}
            </table>
        );
    }

    componentDidMount() {
        
    }
}

export default ListList;