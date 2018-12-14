import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { SentryCommandCoordinator } from '../SentryCommandCoordinator';
import { SentryQueryCoordinator } from '../SentryQueryCoordinator';
import { SignUpTenant } from '../SignUps/SignUpTenant';
import { AllCountries } from '../SignUps/AllCountries';

@inject(Router, SentryCommandCoordinator, SentryQueryCoordinator)
export class sign_up_new_tenant {
  countries = [];
  tenantName = '';
  tenantUrl = '';
  tenantOwnerEmail = '';
  country = '';
  errors = [];

  /**
   * Initializes a new instance of {sign_up_existing_tenant}
   * @param router router
   * @param {SentryCommandCoordinator} sentryCommandCoordinator
   * @param {SentryQueryCoordinator} sentryQueryCoordinator
   */

  constructor(router, sentryCommandCoordinator, sentryQueryCoordinator) {
    this.router = router;
    this._commandCoordinator = sentryCommandCoordinator;
    this._queryCoordinator = sentryQueryCoordinator;
  }

  activate() {
    this.getAllCountries();
  }

  findOption = value => this.countries.find(x => x.name === value);

  addHttp = url => {
    let string = url;
    if (!~string.indexOf('http' || 'https')) {
      string = 'http://' + string;
    }
    url = string;
    return url;
  };

  getAllCountries() {
    let query = new AllCountries();

    this._queryCoordinator.execute(query).then(result => (this.countries = [...result.items]));
  }

  signUp() {
    let command = new SignUpTenant();
    command.id = '00000000-0000-0000-0000-000000000000'; //ny id
    command.tenantName = this.tenantName;
    command.homePage = this.tenantUrl;
    command.ownerUserId = '00000000-0000-0000-0000-000000000000';
    command.ownerEmail = this.tenantOwnerEmail;
    command.countryId = '00000000-0000-0000-0000-000000000000';
    command.country = this.country.name;

    this._commandCoordinator.handle(command).then(
      result => {
        if (result.success) {
          let userprofile = this.router.routes.find(x => x.name === 'join_summary');
          userprofile.almostThere = true;
          this.router.navigateToRoute('join_summary', { tenant: '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', application: 'Studio' });
          console.log(result);
        } else {
          console.warn(result);
          this.error = result.allValidationMessages;
        }
      },
      error => {
        console.error('ERROR:', error);
      }
    );
  }
}
