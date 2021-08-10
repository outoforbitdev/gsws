import React, { ChangeEventHandler, Component } from 'react';
import { EntityType, Entity } from '../Model/Entity';

interface ListDisplayProps {
    currentList?: string,
}

interface ListDisplayState {
    currentList?: string,
}

export class ListDisplay extends Component<ListDisplayProps, ListDisplayState> {

    constructor(props: ListDisplayProps) {
        super(props);
        this.state = {
            currentList: props.currentList,
        }
    }

    render() {
        return (
            <div>{this.state.currentList}</div>
        );
    }

    componentDidMount() {
        
    }
}

export default ListDisplay;