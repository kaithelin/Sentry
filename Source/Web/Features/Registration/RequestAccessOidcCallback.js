/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { OidcClient, UserManager, WebStorageStateStore } from 'oidc-client';

/**
 * 
 */
@inject(Router)
export class RequestAccessOidcCallback {

    /**
     * Initializes a new instance of {Login}
     * @param {Router} router 
     */
    constructor(router) {
        this.router = router;
    }

    activate() {
        let self = this;
        // Todo: handle errors
        // http://localhost:5000/Registration/RequestAccessOidcCallback#error=access_denied&state=72961b6fe32f4e649e0b770f63673698

        let userManager = new UserManager({
            userStore: new WebStorageStateStore({
                prefix: "requestaccess",
                store: window.localStorage
            })
        });
        userManager.signinRedirectCallback().then(user => {
            userManager.storeUser(user);
            self.router.navigateToRoute('RequestAccess', user.state);
        });
    }
}