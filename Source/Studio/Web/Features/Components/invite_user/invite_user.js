import { bindable } from "aurelia-framework";

export class invite_user {
  @bindable
  displaybool;

  invitee_email = '';

  displayTheBool() {
    this.displaybool = !this.displaybool;
    this.invitee_email = '';
  }
}
