/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

/**
 * The view model for the Login view
 */
@inject(Router)
export class Login {
    authorities = []
    tenant = '';

    /**
     * Initializes a new instance of {Login}
     * @param {Router} router 
     */
    constructor(router) {
        this.router = router;
    }

    /**
     * Method that gets called when view and view model is attached.
     * The reason for using this rather than activate/activated is that this particular feature
     * is being used as both a stand alone view and can be used as partial to other views
     */
    attached() {
        let self = this;
        let params = this.router.currentInstruction.params;
        this.tenant = params.tenant;

        let client = new HttpClient();
        client.get('/Accounts/Authorities')
            .then(data => {
                let authorities = JSON.parse(data.response);
                authorities.forEach(authority => {
                    self.authorities.push(authority);
                });
            });
    }
}