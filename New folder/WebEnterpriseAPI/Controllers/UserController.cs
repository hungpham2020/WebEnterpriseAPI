using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnterpriseAPI.Data;
using WebEnterpriseAPI.Model;
using WebEnterpriseAPI.Model.DTO;

namespace WebEnterpriseAPI.Controllers
{
    [Route("api/[controller]/[Action]")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<CustomUser> userManager;
        private readonly CustomContext context;


        public UserController(UserManager<CustomUser> _userManager, CustomContext _context)
        {
            userManager = _userManager;
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetAllStaffs()
        {
            var staffs = await (from u in context.Users
                                join ur in context.UserRoles
                                on u.Id equals ur.UserId
                                join r in context.Roles
                                on ur.RoleId equals r.Id
                                where r.Name == "Staff"
                                select new CustomUser
                                {
                                    Id = u.Id,
                                    UserName = u.UserName,
                                    Email = u.Email,

                                }).ToListAsync();
            return staffs;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetAllCoordinator()
        {
            var coordinators = await (from u in context.Users
                                      join ur in context.UserRoles
                                      on u.Id equals ur.UserId
                                      join r in context.Roles
                                      on ur.RoleId equals r.Id
                                      where r.Name == "Coordinator"
                                      select new CustomUser
                                      {
                                          Id = u.Id,
                                          UserName = u.UserName,
                                          Email = u.Email
                                      }).ToListAsync();
            return coordinators;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetAllAdmin()
        {
            var admins = await (from u in context.Users
                                join ur in context.UserRoles
                                on u.Id equals ur.UserId
                                join r in context.Roles
                                on ur.RoleId equals r.Id
                                where r.Name == "Admin"
                                select new CustomUser
                                {
                                    Id = u.Id,
                                    UserName = u.UserName,
                                    Email = u.Email
                                }).ToListAsync();
            return admins;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomUser>>> GetAllAssurance()
        {
            var assurances = await (from u in context.Users
                                    join ur in context.UserRoles
                                    on u.Id equals ur.UserId
                                    join r in context.Roles
                                    on ur.RoleId equals r.Id
                                    where r.Name == "Assurance"
                                    select new CustomUser
                                    {
                                        Id = u.Id,
                                        UserName = u.UserName,
                                        Email = u.Email
                                    }).ToListAsync();
            return assurances;

        }
        //-------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<bool> AddStaff(UserDTO user)
        {
            var account = new CustomUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(account, "Abc@12345");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(account, "Staff");
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> AddCoodinator(UserDTO user)
        {
            var account = new CustomUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(account, "Abc@12345");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(account, "Coordinator");
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> AddAssurance(UserDTO user)
        {
            var account = new CustomUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(account, "Abc@12345");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(account, "Assurance");
                return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<bool> AddAdmin(UserDTO user)
        {
            var account = new CustomUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(account, "Abc@12345");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(account, "Admin");
                return true;
            }
            return false;
        }
        //-----------------------------------------------------------------

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomUser>> GetUserDetail(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        //------------------------------------------------------------------------

        [HttpPut("{id}")]
        public async Task<ActionResult> EditUser(CustomUser user, string id)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
           context.Entry(user).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {
                if(!context.Users.Any(u => u.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return Ok(new {status = 200, data = user});
        }
        //------------------------------------------------------------------------------------------

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            context.Remove(user);
            await context.SaveChangesAsync();


            return Content("Delete successfully " + user.UserName);
        }

    }
}
