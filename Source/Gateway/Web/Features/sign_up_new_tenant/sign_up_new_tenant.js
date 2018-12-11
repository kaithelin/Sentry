import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { SentryCommandCoordinator } from '../SentryCommandCoordinator';
import { SignUpTenant } from '../SignUps/SignUpTenant';

@inject(Router, SentryCommandCoordinator)
export class sign_up_new_tenant {
  tenantName = '';
  tenantUrl = '';
  tenantOwnerEmail = '';
  country = '';

  /**
   * Initializes a new instance of {sign_up_existing_tenant}
   * @param router router
   * @param {SentryCommandCoordinator} sentryCommandCoordinator
   */

  constructor(router, sentryCommandCoordinator) {
    this.router = router;
    this._commandCoordinator = sentryCommandCoordinator;
  }

  signUp() {
    let command = new SignUpTenant();
    command.id = '00000000-0000-0000-0000-000000000000'; //ny id
    command.tenantName = this.tenantName;
    command.homePage = this.tenantUrl;
    command.ownerUserId = '00000000-0000-0000-0000-000000000000';
    command.ownerEmail = this.tenantOwnerEmail;
    command.countryId = '00000000-0000-0000-0000-000000000000';
    command.country = this.country;

    this._commandCoordinator.handle(command).then(
      result => {
        if (result.success) {
          this.router.navigateToRoute('join_summary', { tenant: '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', application: 'Studio' });
          console.log(result);
        } else {
          console.warn(result);
        }
      },
      error => {
        console.error('ERROR:', error);
      }
    );
  }
}
