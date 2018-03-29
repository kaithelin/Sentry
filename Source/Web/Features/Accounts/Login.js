export class Login {
    authorities = [
        { id: '0', name: 'Username & Password' },
        { id: '1', name: 'Google' }
    ];

    id = '';

    constructor() {
    }

    activate(parameters) {
        this.id = parameters.id;
    }
}