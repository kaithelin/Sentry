import { PLATFORM } from 'aurelia-pal';

export class index {
    constructor() {

    }

    configureRouter(config, router) {
        this.router = router;
        config.map([
            { route: ['', 'welcome'],   name: 'welcome',    moduleId: PLATFORM.moduleName('welcome') },
            { route: 'login',           name: 'login',      moduleId: PLATFORM.moduleName('login') }
        ])
    }
}