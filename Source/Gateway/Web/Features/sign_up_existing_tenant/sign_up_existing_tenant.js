import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

@inject(Router)
export class sign_up_existing_tenant {
  email = '';

  constructor(router) {
    this.router = router;
}

  askToJoin() {
    console.log(this.email);
    this.router.navigateToRoute('join_summary', { tenant: '508c1745-5f2a-4b4c-b7a5-2fbb1484346d', application: 'Studio' });
  }
}
