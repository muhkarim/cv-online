using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CVOnline.Bases;
using CVOnline.Models;
using CVOnline.Repositories.Data;
using CVOnline.ViewModels;
using Dapper;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;

namespace CVOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        public IConfiguration _configuration;

        DynamicParameters parameters = new DynamicParameters();


        public UsersController(UserRepository userRepository, RoleRepository roleRepository, IConfiguration configuration)
        {
            this._roleRepository = roleRepository;
            this._userRepository = userRepository;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(User model)
        {
            var checkEmail = _userRepository.GetByEmail(model.Email);

            if (checkEmail != null)
            {
                return BadRequest("Email already taken!");
            }
            else
            {
                User user = new User();

                var mypass = model.Password;
                var mysalt = BCryptHelper.GenerateSalt(12);

                user.Email = model.Email;
                user.Password = BCryptHelper.HashPassword(mypass, mysalt);

                var result = await _userRepository.PostAsync(user);

                if (result != null)
                {
                    await _roleRepository.InsertUserRole(user.Id, 2);

                    return Ok("Register Success!");
                }
                else
                {
                    return BadRequest("Failed to register");
                }


            }

        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginViewModel model) 
        {
            var getEmail =  _userRepository.GetByEmail(model.Email);

            if (getEmail == null)
            {
                return BadRequest("Email Wrong!");

            }
            else 
            {
                var check = BCryptHelper.CheckPassword(model.Password, getEmail.Password);

                if (check == false)
                {
                    return BadRequest("Wrong Password!"); ;
                }
                else 
                {
                    // get role from user login
                    using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
                    {
                        var procName = "SP_GetRole";
                        parameters.Add("@email", model.Email);
                        IEnumerable<LoginViewModel> data = connection.Query<LoginViewModel>(procName, parameters, commandType: CommandType.StoredProcedure);
                        foreach (LoginViewModel users in data)
                        {
                            model.RoleName = users.RoleName;
                        }
                    }


                    //  create jwt
                    var claims = new[] {
                    new Claim("Email", model.Email),
                    new Claim("Role", model.RoleName)
                    
                };

                    var signinKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                    int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                    var token = new JwtSecurityToken(
                      issuer: _configuration["Jwt:Site"],
                      audience: _configuration["Jwt:Site"],
                      claims,
                      expires: DateTime.UtcNow.AddDays(3),
                      signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
            }

        }


       
        [HttpGet]
        public async Task<IEnumerable<UserVM>> Get()
        {
            return await _userRepository.Get();
        }

        
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserVM>> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, User model)
        {
            if (model.Email != null || model.Password != null)
            {
                var user = await _userRepository.GetAsync(id);
                
                if (model.Password != user.Password)
                {
                    var newPass = model.Password; // new password
                    var salt = BCryptHelper.GenerateSalt(12);

                    user.Email = model.Email;
                    user.Password = BCryptHelper.HashPassword(newPass, salt); // change to new password

                    await _userRepository.PutAsync(user);
                }

                return Ok("Success updated password!");
            }

            return BadRequest("Failed to update password!");
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }


        [HttpPut]
        [Route("ForgotPassword")]
        public async Task<ActionResult> ForgotPassword(User model) 
        {
            var user = _userRepository.GetByEmail(model.Email);

            var mypass = model.Password;
            var mysalt = BCryptHelper.GenerateSalt(12);
            user.Password = BCryptHelper.HashPassword(mypass, mysalt);

            var result = await _userRepository.PutAsync(user);

            if(result != null) 
            {
                return Ok("Reset Password Succesfully!");
            }

            return BadRequest("Failed to update password");

        }







    }
}