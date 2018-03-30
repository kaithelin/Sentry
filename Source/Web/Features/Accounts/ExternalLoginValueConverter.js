export class ExternalLoginValueConverter {
    toView(value) {
        //window.location.search
        let url = `${window.location.origin}/Accounts/ExternalLogin?tenant=${value.tenant}&authority=${value.id}&${window.location.search.substr(1)}`;
        //debugger;
        return url;
    }
}