using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var userClaims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user, userClaims);
            return new SuccessDataResult<AccessToken>(token);
        }

        public IDataResult<User> Login(UserForLoginDTO userForLogin)
        {
            var userToCheck = _userService.GetByEmail(userForLogin.Email);
            var result = BusinessRules.Run(UserExists(userForLogin.Email), Validate(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt));
            if (result != null) return new ErrorDataResult<User>(result.Message);
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDTO userForRegister, string password)
        {
            var result = BusinessRules.Run(UserExists(userForRegister.Email));
            if (result == null) return new ErrorDataResult<User>(result.Message);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegister.Firstname,
                LastName = userForRegister.Lastname,
                Email = userForRegister.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {

            var mail = _userService.GetByEmail(email);
            if (mail!=null)
            {
                return new SuccessResult(Messages.UserAlreadyExists);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IResult Validate(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (HashingHelper.VerifyPasswordHash(passwordHash, passwordSalt, password)) return new SuccessResult();
            return new ErrorResult(Messages.UserValidationError);
        }
    }
}
