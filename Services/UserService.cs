using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using learn_Russian_API.Helpers;
using learn_Russian_API.Models.Users.GlobalUser.Get;
using learn_Russian_API.Presistence;
using learn_Russian_API.Presistence.Entities;

namespace learn_Russian_API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable GetAll();
        User GetById(long id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(long id);
    }

    public class UserService :IUserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable GetAll()
        {
            /*
            var teacherUser = from user in _context.Users
                where true
                join teacher in _context.Teachers
                    on user.Id equals teacher.userId
                select new { user, teacher};
            
           
           var studentUser =from user in _context.Users
               where true
               join student in _context.Students
                   on user.Id equals student.userId
               select new { user, student };*/
            
         

            /*var teacherUser = from user in _context.Users.ToList()
                where true
                join teacher in _context.Teachers.ToList()
                    on user.Id equals teacher.userId
                orderby user.Id
                select new
                {
                    _user = new {user.Id,user.FirstName,user.LastName,user.Username,user.Password}, 
                    _teacher = new {teacher.Id,teacher.Subject,teacher.userId,teacher.Role},
                };

            var studentUser =from user in _context.Users.ToList()
                where true
                join student in _context.Students.ToList()
                    on user.Id equals student.userId
                select new
                {
                    _user = new {user.Id,user.FirstName,user.LastName,user.Username,user.Password}, 
                    _student = new {student.Id,student.CountryId,student.TeacherGroupId,student.userId,student.Role}

                };

            IEnumerable users = new[] {new {teacherUser, studentUser}}.ToList();*/
            
            return _context.Users;
        }

     


        public User GetById(long id)
        {
           
            return _context.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");
            
            if(_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\"is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);
            
            if(user == null)
                throw new AppException("User not found");
            
            //update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                //throw error if the new username is already taken 
                if(_context.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username" + userParam.Username + "is already taken");
                
                user.Username = userParam.Username;
            }
            
            //update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;
            
            //update group if exist
            if (userParam.TeacherGroupId != null && user.TeacherGroupId != null)
            {
                user.TeacherGroupId = userParam.TeacherGroupId;
            }
            
            //update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password,out passwordHash,out passwordSalt);
    
                
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Password = password;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}