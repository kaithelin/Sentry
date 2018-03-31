/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { OpenIdConnect } from "aurelia-open-id-connect";
import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';
import { parseQueryString } from 'aurelia-path';

/**
 * The view model used for dealing with consent
 */
@inject(OpenIdConnect)
export class Consent {
    information={};
    rememberConsent=false;

    /**
     * Initializes a new instance of {Consent}
     * @param {OpenIdConnect} openIdConnect 
     */
    constructor(openIdConnect) {
        this._openIdConnect = openIdConnect;
    }

    /**
     * Method that gets invoked when view and view model is activated
     */
    activate() { 
        let self = this;
        let client = new HttpClient();
        let params = parseQueryString(window.location.search.substr(1));
        this._returnUrl = params.returnUrl;
        client.createRequest('/Consent')
            .asGet()
            .withParams({returnUrl: params.returnUrl})
            .send()
            .then(data => {
                self.information = JSON.parse(data.response);
                self.information.identityScopes.forEach(scope => scope.checked = true);
                self.information.resourceScopes.forEach(scope => scope.checked = true);
            });
    }

    notAllow() {
    }

    allow() {
        let self = this;
        let scopes = this.information.identityScopes.filter(scope => scope.checked).map(scope => scope.name.value);

        let client = new HttpClient();
        client.createRequest("/Consent/Grant")
            .asPost()
            .withContent(scopes)
            .withParams(
                { 
                    returnUrl: this._returnUrl,
                    rememberConsent: this.rememberConsent
                })
            .send();
    }
}