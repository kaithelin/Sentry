import { PLATFORM } from 'aurelia-pal';
import style from '../styles/style.scss';
import { OpenIdConnect, OpenIdConnectRoles } from 'aurelia-open-id-connect';
import { inject } from 'aurelia-dependency-injection';

@inject(OpenIdConnect)
export class app {
    constructor(openIdConnect) {
        this._openIdConnect = openIdConnect;
    }

    configureRouter(config, router) {
        config.options.pushState = true;
        config.map([
            { route: ['', ':tenant/:application', ':tenant/:application/welcome'], name: 'welcome', moduleId: PLATFORM.moduleName('welcome'), layoutView: PLATFORM.moduleName('layout.html') },
            { route: ':tenant/:application/Accounts/Login', name: 'Login', moduleId: PLATFORM.moduleName('Gateway/Accounts/Login') },
            { route: ':tenant/:application/Accounts/Consent', name: 'Consent', moduleId: PLATFORM.moduleName('Gateway/Accounts/Consent') },
            { route: ':tenant/:application/login_vendors', name: 'Login vendors', moduleId: PLATFORM.moduleName('login_vendors/login_vendors') },
            { route: ':tenant/:application/sign_up_existing_tenant', name: 'sign up exisisting tenant', moduleId: PLATFORM.moduleName('sign_up_existing_tenant/sign_up_existing_tenant') },
            { route: ':tenant/:application/known_tenant', name: 'known tenant', moduleId: PLATFORM.moduleName('known_tenant/known_tenant') },
            { route: ':tenant/:application/join_summary', name: 'join summary', moduleId: PLATFORM.moduleName('join_summary/join_summary') },
            { route: ':tenant/:application/sign_up', name: 'sign up', moduleId: PLATFORM.moduleName('sign_up/sign_up') },
            { route: ':tenant/:application/sign_up_new_tenant', name: 'sign up new tenant', moduleId: PLATFORM.moduleName('sign_up_new_tenant/sign_up_new_tenant') },
            {
                route: ['Registration/RequestAccessOidcCallback', ':tenant/:application/:client/Registration/RequestAccess'],
                name: 'RequestAccess',
                moduleId: PLATFORM.moduleName('Gateway/Registration/RequestAccess')
            },
            {
                route: ':tenant/:application/Registration/Requests',
                name: 'Requests',
                moduleId: PLATFORM.moduleName('Gateway/Registration/Requests'),
                settings: { cssClass: 'wide-column' }
            }
        ]);

        this._openIdConnect.configure(config);

        this.router = router;
    }
}

//http://localhost:5000/be4c4da6-5ede-405f-a947-8aedad564b7f/CBS/25c7ddac-dd1b-482a-8638-aaa909fd1f1c/Registration/RequestAccess
