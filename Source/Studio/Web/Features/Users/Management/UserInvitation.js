/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class UserInvitation extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '764c1b07-d881-4c6d-b1d6-cdd73dec5796',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.tenantId = '00000000-0000-0000-0000-000000000000';
        this.applicationId = '00000000-0000-0000-0000-000000000000';
        this.email = '';
        this.invited = new Date();
        this.validTo = new Date();
        this.status = {};
    }
}