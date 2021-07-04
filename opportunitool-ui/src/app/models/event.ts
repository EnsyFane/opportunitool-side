export enum EventName {
}

export class AppEvent {
    name: EventName;
    payload: any;

    constructor(name: EventName, payload?: any) {
        this.name = name;
        this.payload = payload;
    }
}
