export class Login {
    authorities = [
        { id: '0', name: 'Username & Password', url: '', icon: '' },
        { id: '1', name: 'Google', url: '', icon: '' }
    ];

    id = '';

    constructor() {
    }

    activate(parameters) {
        this.id = parameters.id;
    }
}