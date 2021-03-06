﻿/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readmodels';

export class UserInvitation extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: '554306b5-0dab-4a04-9ef0-5addaacd85e2',
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