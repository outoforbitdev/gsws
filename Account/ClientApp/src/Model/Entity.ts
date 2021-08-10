export class Entity {
    Name: string;
    Environment: string;

    constructor() {
        this.Name = "";
        this.Environment = "";
    }
}

export enum EntityType {
    Being = 1,
    Kingdom = 2,
}

export default Entity;