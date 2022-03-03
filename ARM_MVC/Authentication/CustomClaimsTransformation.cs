using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ARM_MVC.Authentication
{
    public class CustomClaimsTransformation : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Proposed to get role names For the current user User.Identity.Name from database here then iterate over the following code To add each 1 as applicable

            if (principal!= null  && principal?.Identity!= null)
            {
                ClaimsIdentity? claimsIdentity = (ClaimsIdentity)principal.Identity;
                var claim = new Claim(claimsIdentity.RoleClaimType,"BasicUser");
                claimsIdentity.AddClaim(claim);
                claim = new Claim(claimsIdentity.RoleClaimType, "Admin");
                claimsIdentity.AddClaim(claim);
                return Task.FromResult(principal);
            }
            throw new NotImplementedException("principle or identity was null!");
        }
    }
}


