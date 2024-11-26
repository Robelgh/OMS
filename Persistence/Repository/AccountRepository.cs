using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using System.Buffers.Text;
using Application.Repository;
using Application.DTO.Account;
using Application.Response;
using System.CodeDom.Compiler;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain;

namespace Persistence.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OMSDbContext _context;
        BaseCommandResponseAcccount response;
        private const string SecretKey = "your-very-secure-secret-key";

        public AccountRepository(OMSDbContext context)
        {
            _context = context;
        }


    

        async Task<BaseCommandResponseAcccount> IAccountRepository.IsAuthenticated(AccountDto data)
        {
            response = new BaseCommandResponseAcccount();
            var user = _context.Users
                               .FirstOrDefault(u => u.Name == data.UserName);

            if (user == null)
            {
                response.Success = false;
                response.Message = "Incorrect Password or User Name";
                response.Status = "200";
            }
            else
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(data.Password, user.Passworded);

                if (isPasswordValid)
                {
                    response.Success = true;
                    response.Token = GenerateToken(user);
                    response.Status = "200";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Incorrect Password or User Name";
                    response.Status = "200";
                }
            }

            return response;

         
        }

        public string GenerateToken(Users data)
        {
            
            var expirationTime = DateTime.UtcNow.AddMinutes(10); ;

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, data.Name),
            new Claim(ClaimTypes.Role, data.Role),
            new Claim(ClaimTypes.NameIdentifier,data.ID.ToString()),
            new Claim(ClaimTypes.Expiration, expirationTime.ToString("yyyy-MM-dd HH:mm:ss"))
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Generate256BitKey()));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",
                claims: claims,
                expires: expirationTime,
                signingCredentials: creds 
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string Generate256BitKey()
        {
            byte[] key = new byte[32]; 

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }

            return Convert.ToBase64String(key);
        }


    }
}
