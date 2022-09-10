using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using UserService.Controllers;
using UserService.Data;
using UserService.Models;

namespace AuthServer.Model
{
    public class UserValidationRequestModel
    {
        private readonly DigitalBookContext _context=new DigitalBookContext();
       
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
       
        public bool IsValidUserInformation(string username,string password)
        {
            if (_context.UserMasters == null)
            {
                return false;
            }
            var encryptedPassword = EncryptionDecryptionController.Encrypt(password == null ? "" : password);
            var user = _context.UserMasters.Where(x=>x.UserName==username && x.UserPassword== encryptedPassword).Select(x=>x.UserId).SingleOrDefault();

            if (user > 0)
                return true;

            return false;
        }
    }
}
