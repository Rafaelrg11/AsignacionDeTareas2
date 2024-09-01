using AsignacionDeTareas2.DTOs;
using AsignacionDeTareas2.Models;
using AsignacionDeTareas2.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AsignacionDeTareas2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly ApplicationDbcontext _context;

        private readonly string _secretkey;

        public readonly UsersOperations _operations;
        public UsersController(IConfiguration configuration, UsersOperations operations, ApplicationDbcontext context)
        {
            _context = context;
            _operations = operations;
            _secretkey = configuration.GetSection("Jwt").GetSection("Key").ToString();


        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] ValidationUserDto usersDto)
        {
            var users = (from d in _context.Users
                         where d.password == usersDto.password
                         && d.emailUser == usersDto.EmailUser
                         select d).FirstOrDefault();

            if (users != null)
            {
                var keyBytes = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretkey));

                var claims = new List<Claim>{
                    new Claim(JwtRegisteredClaimNames.Sub, users.emailUser),
                    new Claim("identificador de usuario", users.idUser.ToString()),
                    new Claim("identificador del rol", users.IdRol.ToString())
                    };

                var creds = new SigningCredentials(keyBytes, SecurityAlgorithms.HmacSha256);

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescription);

                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { Bearer = tokenCreated });
            }

            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { Bearer = "" });
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            await _operations.GetUsers();

            var allUsers = await _context.Users.Select(a => new UsersDto
            {
                idUser = a.idUser,
                IdRol = a.IdRol,
                nameUser = a.nameUser,
                emailUser = a.emailUser,
                password = a.password,
                rolDto = new RolDto2
                {
                    IdRol = a.IdRol,
                    nombre = a.Rol.nombre
                },
                tasksDto2 = a.tasks.Select(a => new TasksDto2
                {
                    idTask = a.idTask,
                    idProyect = a.idProyect,
                    idUser = a.idUser,
                    nameTask = a.nameTask,
                    descriptionTask = a.descriptionTask,
                    dateTask = a.dateTask,
                    dateTaskCompletion = a.dateTaskCompletion,
                    state = a.state
                }).ToList()
            }).ToListAsync();

            return Ok(allUsers);
        }

        [HttpGet("GetUser/{idUser}")]
        public async Task<IActionResult> GetUSer(int idUser)
        {
            await _operations.GetUser(idUser);

            var user = await _context.Users.Where(a => a.idUser == idUser).Select(a => new UsersDto
            {
                idUser = a.idUser,
                IdRol = a.IdRol,
                nameUser = a.nameUser,
                emailUser = a.emailUser,
                password = a.password,
                rolDto = new RolDto2
                {
                    IdRol = a.IdRol,
                    nombre = a.Rol.nombre
                },
                tasksDto2 = a.tasks.Select(a => new TasksDto2
                {
                    idTask = a.idTask,
                    idProyect = a.idProyect,
                    idUser = a.idUser,
                    nameTask = a.nameTask,
                    descriptionTask = a.descriptionTask,
                    dateTask = a.dateTask,
                    dateTaskCompletion = a.dateTaskCompletion,
                    state = a.state
                }).ToList()
            }).ToListAsync();

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDto2 usersDto)
        {
            Users users = new Users()
            {
                nameUser = usersDto.nameUser,
                emailUser = usersDto.emailUser,
                password = usersDto.password,
                IdRol = usersDto.IdRol,
            };

            var operation = await _operations.CreateUser(users);

            return Ok(operation);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<bool> UpdateUser(UserDto2 usersDto)
        {
            var result = await _operations.UpdateUser(usersDto);

            return result;
        }

        [HttpDelete("DeleteUser/{idUser}")]
        public async Task<bool> DeleteUser(int idUser)
        {
            var result = await _operations.DeleteUser(idUser);

            return result;
        }
    }
}
