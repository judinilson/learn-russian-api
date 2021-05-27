﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using learn_Russian_API.Helpers;
using learn_Russian_API.Models.Users;
using learn_Russian_API.Models.Users.GlobalUser.Get;
using learn_Russian_API.Models.Users.GlobalUser.Update;
using learn_Russian_API.Models.Users.Student.Create;
using learn_Russian_API.Models.Users.Teacher.Create;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;
using learn_Russian_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;



namespace learn_Russian_API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private IUserService _userService;
        //private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public UserController(
            IUserService userService, 
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.password);

            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
          
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Id.ToString()), 
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                
                
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
            
                //return basic user info and authetication token
                return Ok(new
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Role = user.Role,
                    Token = tokenString
                });
            
        }
        
        
       


        [AllowAnonymous]
        [HttpPost("register-Teacher")]
        public IActionResult RegisterTeacher([FromBody] TeacherUserCreateRequest model)
        {
            //map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
        
        [AllowAnonymous]
        [HttpPost("register-Student")]
        public IActionResult RegisterStudent([FromBody] StudentUserCreateRequest model)
        {
            //map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

       
        
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserGetResponse>>(users);
            
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            object model = null;
            if (user.Role == Role.Teacher)
            {
                 model = _mapper.Map<UserTeacherGetResponse>(user);
            }
            if (user.Role == Role.Student)
            {
                 model = _mapper.Map<UserStudentGetResponse>(user);
            }
            
            
            return Ok(model);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserUpdateRequest model)
        {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            
            try
            {
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
        
        

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return Ok();
        }
        
        
        
    }

}