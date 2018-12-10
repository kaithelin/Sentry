import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { SentryCommandCoordinator } from '../SentryCommandCoordinator';
import { AskToJoinTenant } from '../SignUps/AskToJoinTenant';

@inject(Router, SentryCommandCoordinator)
export class sign_up_existing_tenant {
  email = '';

  /**
   * Initializes a new instance of {sign_up_existing_tenant}
   * @param {SentryCommandCoordinator} sentryCommandCoordinator
   */

  constructor(router, sentryCommandCoordinator) {
    this.router = router;
    this._commandCoordinator = sentryCommandCoordinator;
  }

  askToJoin() {
    console.log(this.email);
    //this.router.navigateToRoute('join_summary', { tenant: '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', application: 'Studio' });
    let command = new AskToJoinTenant();
    command.id = '00000000-0000-0000-0000-000000000000'; //ny id
    command.userId = '00000000-0000-0000-0000-000000000000'; //pålogget bruker
    command.userEmail = this.email;

    this._commandCoordinator.handle(command, '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', 'Studio').then(
      result => {
        console.warn(result);
        if (result.success) {
          //Do something, probably redirect to returnUrl¨
          console.log(result);
        } else {
          console.error(result);
        }
      },
      error => {
        console.error('ERROR:', error);
      }
    );
  }
}
