import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

@inject(Router)
export class known_tenant {
  tenants = [{ name: 'tenant.A' }, { name: 'tenant.B' }, { name: 'tenant.c' }];

  /**
   * Initializes a new instance of {sign_up_existing_tenant}
   * @param router router
   */

  constructor(router) {
    this.router = router;
  }

  activate(tenants) {
    this.tenants;
  }

  askTheOwner() {
    let userprofile = this.router.routes.find(x => x.name === 'join_summary');
    userprofile.almostThere = false;
    this.router.navigateToRoute('join_summary', { tenant: '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', application: 'Studio' });
  }
}
