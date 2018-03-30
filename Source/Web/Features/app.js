import { PLATFORM } from 'aurelia-pal';
import style from '../styles/style.scss';

export class index {
    constructor() {

    }

    configureRouter(config, router) {
        config.options.pushState = true;
        config.map([
            { route: ['', 'welcome'], name: 'welcome', moduleId: PLATFORM.moduleName('welcome') },
            { route: ':tenant/Accounts/Login', name: 'Login', moduleId: PLATFORM.moduleName('Accounts/Login') },
            { route: ':tenant/Accounts/Consent', name: 'Consent', moduleId: PLATFORM.moduleName('Accounts/Consent') },
            { route: ':tenant/:application/Registration/RequestAccess', name: 'RequestAccess', moduleId: PLATFORM.moduleName('Registration/RequestAccess') }
        ]);
        this.router = router;
    }
}