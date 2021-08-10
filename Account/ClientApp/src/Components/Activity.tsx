import React, { ChangeEventHandler, Component, Fragment } from 'react';
import { EntityType, Entity } from '../Model/Entity';
import ListList from './ListList';
import ListDisplay from './ListDisplay';

interface ActivityProps {

}

interface ActivityState {
    lists: string[],
    currentList?: string,
}

export class Activity extends Component<ActivityProps, ActivityState> {

    constructor(props: ActivityProps) {
        super(props);
        this.state = {
            lists: ["List 1", "List 2"]
        }
    }

    render() {
        return (
            <Fragment>
                <ListList lists={this.state.lists} changeList={this.__changeList} />
                <ListDisplay currentList={this.state.currentList} />
            </Fragment>
        );
    }

    componentDidMount() {
            
    }

    private __changeList(newList: string) {
        this.setState({ currentList: newList });
    }
}

export default Activity;