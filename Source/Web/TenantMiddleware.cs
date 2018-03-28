/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web
{

    /// <summary>
    /// 
    /// </summary>
    public class TenantMiddleware
    {
        readonly Regex _guidRegex = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
        readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// /// <param name="_next"></param>
        public TenantMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            //context.Request.PathBase = new PathString("/be4c4da6-5ede-405f-a947-8aedad564b7f");
            await _next(context);
        }
    }
}