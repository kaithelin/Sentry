/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Read;

namespace Web.Features.Accounts
{


    /// <summary>
    /// 
    /// </summary>
    [SecurityHeaders]
    public class AccountsController : Controller
    {
        readonly IIdentityServerInteractionService _interaction;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interaction"></param>
        /// <param name="schemeProvider"></param>
        public AccountsController(
            IIdentityServerInteractionService interaction,
            IAuthenticationSchemeProvider schemeProvider)
        {
            _interaction = interaction;
            _schemeProvider = schemeProvider;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Accounts/Authorities")]
        public async Task<IActionResult> Authorities()
        {
            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(_ => 
                    !string.IsNullOrEmpty(_.DisplayName)
                )
                .Select( _ => new Authority
                {
                    Name = _.DisplayName,
                    AuthenticationScheme = _.Name
                })
                ;

            // Allow remember login?
            return Json(providers);
        }
    }
}