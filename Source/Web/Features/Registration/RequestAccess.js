import { OpenIdConnect } from "aurelia-open-id-connect";
import { inject } from 'aurelia-framework';

@inject(OpenIdConnect)
export class RequestAccess {
    isLoggedIn=false;

    constructor(openIdConnect) {
        this._openIdConnect = openIdConnect;
        
        this._openIdConnect.userManager.getUser()
            .then((user) => {
                if (typeof user === "undefined" || user === null) {
                    this._openIdConnect.login();
                } else {
                    if (user.expired) {
                        this.loginSilent();
                    } else {
                        this.inMemoryUser = user;
                    }

                    this.isLoggedIn = true;
                }
            });        
    }
}