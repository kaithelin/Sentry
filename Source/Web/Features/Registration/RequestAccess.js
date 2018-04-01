import { OpenIdConnect } from "aurelia-open-id-connect";
import { OidcClient, UserManager, WebStorageStateStore } from 'oidc-client';
import { inject } from 'aurelia-framework';

const _tenant = new WeakMap();
const _application = new WeakMap();

export class RequestAccess {
    isLoggedIn = false;

    constructor() {

        /*
        let tenant = '';
        let application = '';
        let guidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i
        //new Regex("^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
        let segments = window.location.pathname.split('/');
        if( segments.length > 1 )
        {
            if( segments[1].match(guidRegex) ) {
                tenant = segments[1];
            }
        }
        
        if( segments.length > 1 && segments[1].match(guidRegex) ) tenant = segments[1];
        if( segments.length > 2 && segments[2].match(guidRegex) ) application = segments[2];
        */



        //this._openIdConnect = openIdConnect;

        /*
        this._openIdConnect.userManager.getUser()
            .then((user) => {
                if (typeof user === "undefined" || user === null) {
                    this.isLoggedIn = false;
                } else {
                    if (user.expired) {
                        this.loginSilent();
                    } else {
                        this.inMemoryUser = user;
                    }

                    this.isLoggedIn = true;
                }
            });        
        */
    }
    I
    activate(params) {
        // Validate params - guids
        _tenant.set(this, params.tenant);
        _application.set(this, params.application);

        this._userManager = new UserManager({
            accessTokenExpiringNotificationTime: 1,
            authority: `http://localhost:5000/${params.tenant}`,
            automaticSilentRenew: true,
            checkSessionInternal: 10000,
            client_id: params.application,
            filterProtocolClaims: true,
            loadUserInfo: true,
            post_logout_redirect_uri: '',
            redirect_uri: `http://localhost:5000/Registration/RequestAccessOidcCallback`,
            response_type: 'id_token',
            scope: 'openid profile',
            silentRequestTimeout: 10000,
            silent_redirect_uri: '',
            userStore: new WebStorageStateStore({
                prefix: "requestaccess",
                store: window.localStorage
            })
        });

        this._userManager.getUser().then(user => {
            this.isLoggedIn = true;
        });
    }


    login() {

        this._userManager.signinRedirect({
            state: {
                tenant: _tenant.get(this),
                application: _application.get(this)
            }
        }).then(request => {
            window.location = request.url;
        });

        /*
        this._client.createSigninRequest({
            state: {
                tenant: _tenant.get(this),
                application: _application.get(this)
            }
        }).then(request => {
            window.location = request.url;
        });*/
    }
}