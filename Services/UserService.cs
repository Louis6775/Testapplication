/*using System;
using System.Linq;
using DTO;
using Models;
using TestApplication.Data;

namespace Services
{
    public interface IUserService
    {
            Students Authenticate(string username, string password);
            Students Create(Students user, string password);
    }
    public class UserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public Students Authenticate(string username, string password)
        {
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                return null;
            }
            else
            {
                var user = _context.Students.SingleOrDefault(x => x.username == username);
                if(user == null)
                {
                    return null;
                }
                else if (VerifyPasswordHash(password, user.passwordhash, user.passwordsalt))
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
        }

        public Students Create(Students user, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password is required");
            }
            else if(_context.Students.Any(x => x.username == user.username))
            {
                throw new ArgumentException("Username" + " " + user.username + " is already taken");
            }
            else
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.passwordhash = passwordHash;
                user.passwordsalt = passwordSalt;

                _context.Students.Add(user);
                _context.SaveChanges();
                return user;
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(password == null) 
            {
                throw new ArgumentNullException("password");
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string","password");
            }
            else   
            {
                using(var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentException("password");
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string","password");
            }

            else if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid password","password");
            }
            else
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                {
                    var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < ComputeHash.Length; i++)
                    {
                        if(ComputeHash[i] != storedHash[i])
                        {
                            return false;
                        }

                    }
                }
                return true;
            }
        }
    }
}*/