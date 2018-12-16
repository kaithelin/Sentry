import { bindable } from "aurelia-framework";

export class container {
    @bindable
    display_invite_dialog = false;

    showInviteDialog() {
        this.display_invite_dialog = true;
    }
}
