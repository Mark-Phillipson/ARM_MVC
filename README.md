# ARM_MVC

Minimum viable product, testing how to do roles authorisation with Windows authentication in MVC .net 6

This is the code that is doing the adding roles or claims to the current user:

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

I have added the authorise annotation to the following views:

        [Authorize(Roles ="BasicUser")]
        public IActionResult Index()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles ="SuperUser")]
        public IActionResult Test()
        {
            return View();
        }
The basic and admin have been automatically assigned to the current user. Whereas the superuser has not. So the 1st 2 should succeed and the Super User should be refused.

I've done a very similar thing with the Blazor server project.

I have also created a vertical menu in the MVC application with 1 level of submenus.

The Blazor Server project references the MVC project.
