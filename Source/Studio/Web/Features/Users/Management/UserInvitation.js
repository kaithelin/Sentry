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
           id: '30036973-27a6-4c62-89f1-27857d13ae15',
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