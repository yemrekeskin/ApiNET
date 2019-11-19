using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;
using System;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class AuthController
        : ApiControllerBase
    {
        private readonly JwtTokenConfiguration _jwtTokenConfiguration;

        public AuthController(
            IOptions<JwtTokenConfiguration> jwtTokenConfiguration)
        {
            this._jwtTokenConfiguration = jwtTokenConfiguration.Value;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public ActionResult<LoginOutput> Login([FromBody]LoginInput input)
        {
            var userToVerify = CreateClaimsIdentity(input.UserNameOrEmail, input.Password);
            if (userToVerify == null)
            {
                return BadRequest();
            }

            var token = new JwtSecurityToken
            (
                issuer: _jwtTokenConfiguration.Issuer,
                audience: _jwtTokenConfiguration.Audience,
                claims: userToVerify.Claims,
                expires: _jwtTokenConfiguration.EndDate,
                notBefore: _jwtTokenConfiguration.StartDate,
                signingCredentials: _jwtTokenConfiguration.SigningCredentials
            );

            return Ok(new LoginOutput { Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        private ClaimsIdentity CreateClaimsIdentity(string userNameOrEmail, string password)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            //var userToVerify = await _userManager.FindByNameAsync(userNameOrEmail) ??
            //                   await _userManager.FindByEmailAsync(userNameOrEmail);

            //if (userToVerify == null)
            //{
            //    return null;
            //}

            //if (await _userManager.CheckPasswordAsync(userToVerify, password))
            //{
            //    return new ClaimsIdentity(new GenericIdentity(userNameOrEmail, "Token"), new[]
            //    {
            //        new Claim(JwtRegisteredClaimNames.Sub, userNameOrEmail),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //    });
            //}

            return new ClaimsIdentity(new GenericIdentity(userNameOrEmail, "Token"), new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userNameOrEmail),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                });

            //return null;
        }
    }
}