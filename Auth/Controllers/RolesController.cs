using Auth.DTOs;
using Auth.MyModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> CreateRole(RoleDTO role) 
        {
            var result = await _roleManager.FindByNameAsync(role.RoleName);

            if (result == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                return Ok(new ResponseDTO
                {
                    Message = "Role Created",
                    IsSuccess = true,
                    StatusCode = 201
                });
            }

            return Ok(new ResponseDTO
            {
                Message = "Invalid role",
                StatusCode = 403
            });
        }
        [HttpGet]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }
        [HttpPut]
        public async Task<ActionResult<IdentityRole>> UpdateRole(Guid id, RoleDTO newRole)
        {
            var old = await _roleManager.FindByIdAsync(id.ToString());
            if(old != null)
            {
                old.Name = newRole.RoleName;
                return Ok(old);
            }
            else
            {
                return Ok("Role is empty");
            }
        }
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role != null)
            {
                var res = await _roleManager.DeleteAsync(role);
                return Ok("Deleted");
            }
            return Ok("Role not found");
        }
    }
}
