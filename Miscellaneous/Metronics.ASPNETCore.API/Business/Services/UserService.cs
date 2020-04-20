﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Metronics.ASPNETCore.API.Core.Domain.Entities;

namespace Metronics.ASPNETCore.API.Business.Services
{
    public interface IUserService
    {
        Task<User> FindByNameAsync(string username);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task UpdateAsync(User user);
        Task<IList<string>> GetUserRoles(User user);
        Task<IdentityResult> CreateAsync(User user);
        Task<User> FindFirstAsync(Expression<Func<User, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<User, bool>> predicate);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        string HashPassword(User user, string password);
        Task<IList<User>> GetUsersInRoleAsync(string role);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<User> ActivateAccount(string usernameOrEmail, string activationCode);
        Task<User> GetProfile(string username);
        Task<bool> ForgotPassword(string usernameOrEmail);
        Task<bool> ResetPassword(User model);
        Task<bool> ChangePassword(string userName, User model);
        Task<IList<string>> GetUserRolesAsync(string username);
        Task<bool> UpdateProfile(string userName, User model);
        Task<bool> IsInRoleAsync(User user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles);
    }

    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;
        //private readonly AppConfig appConfig;
        //private readonly ISMSService _smsSvc;
        //private readonly IServiceHelper _svcHelper;
        //private readonly IMailService _mailSvc;
        public UserService(
            UserManager<User> userManager
            //IServiceHelper svcHelper,
            //IMailService mailSvc, 
            //ISMSService smsSvc,
            //IOptions<AppConfig> _appConfig
            )
        {
            _userManager = userManager;
            //_svcHelper = svcHelper;
            //_mailSvc = mailSvc;
            //appConfig = _appConfig.Value;
            //_smsSvc = smsSvc;
        }

        protected virtual Task<IdentityResult> CreateAsync(User user)
        {
            return _userManager.CreateAsync(user);
        }

        protected virtual Task<IdentityResult> AddToRoleAsync(User user, string role)
        {
            return _userManager.AddToRoleAsync(user, role);
        }

        protected virtual string HashPassword(User user, string password)
        {
            return _userManager.PasswordHasher.HashPassword(user, password);
        }

        protected virtual Task<IdentityResult> CreateAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        protected virtual Task<User> FindFirstAsync(Expression<Func<User, bool>> filter)
        {
            return _userManager.Users.Where(filter).FirstOrDefaultAsync();
        }

        protected virtual Task<bool> ExistAsync(Expression<Func<User, bool>> filter)
        {
            return _userManager.Users.AnyAsync(filter);
        }

        protected virtual Task<User> FindByNameAsync(string username)
        {
            return _userManager.FindByNameAsync(username);
        }

        protected virtual Task<IList<string>> GetUserRoles(User user)
        {
            return _userManager.GetRolesAsync(user);
        }
        public async Task<IList<string>> GetUserRolesAsync(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return await _userManager.GetRolesAsync(user);
        }
        protected virtual Task<User> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        protected virtual Task<IList<User>> GetUsersInRoleAsync(string role)
        {
            return _userManager.GetUsersInRoleAsync(role);
        }

        protected virtual Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        protected virtual Task<bool> CheckPasswordAsync(User user, string password)
        {
            return _userManager.CheckPasswordAsync(user, password);
        }

        protected virtual Task UpdateAsync(User user)
        {
            return _userManager.UpdateAsync(user);
        }

        Task<User> IUserService.FindByNameAsync(string username)
        {
            return FindByNameAsync(username);
        }

        Task<User> IUserService.FindByEmailAsync(string email)
        {
            return FindByEmailAsync(email);
        }

        Task<bool> IUserService.CheckPasswordAsync(User user, string password)
        {
            return CheckPasswordAsync(user, password);
        }

        Task IUserService.UpdateAsync(User user)
        {
            return UpdateAsync(user);
        }

        Task<IList<string>> IUserService.GetUserRoles(User user)
        {
            return GetUserRoles(user);
        }

        Task<IdentityResult> IUserService.CreateAsync(User user)
        {
            return CreateAsync(user);
        }

        Task<User> IUserService.FindFirstAsync(Expression<Func<User, bool>> filter)
        {
            return FindFirstAsync(filter);
        }

        Task<bool> IUserService.ExistAsync(Expression<Func<User, bool>> predicate)
        {
            return ExistAsync(predicate);
        }

        Task<IdentityResult> IUserService.CreateAsync(User user, string password)
        {
            return CreateAsync(user, password);
        }

        Task<IdentityResult> IUserService.AddToRoleAsync(User user, string role)
        {
            return AddToRoleAsync(user, role);
        }

        string IUserService.HashPassword(User user, string password)
        {
            return HashPassword(user, password);
        }

        Task<IList<User>> IUserService.GetUsersInRoleAsync(string role)
        {
            return GetUsersInRoleAsync(role);
        }

        Task<string> IUserService.GenerateEmailConfirmationTokenAsync(User user)
        {
            return GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> ActivateAccount(string usernameOrEmail, string activationCode)
        {
            //if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(activationCode)) {
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);
            //}

            //var user = await FindByNameAsync(usernameOrEmail) ?? await FindByEmailAsync(usernameOrEmail);

            //await ValidateUser(user);

            //if (user.IsConfirmed())
            //    throw new LMEGenericException("Your account was activated earlier.");

            //if (activationCode == user.AccountConfirmationCode) {

            //    user.EmailConfirmed = true;
            //    user.PhoneNumberConfirmed = true;

            //    await UpdateAsync(user);
            //}
            //else if (activationCode != user.AccountConfirmationCode)
            //{
            //    throw  new LMEGenericException("Invalid OTP");
            //    //await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_INVALID_OTP);
            //}

            //return user == null ? null : new User
            //{
            //    PhoneNumber = user.PhoneNumber,
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    UserId = user.Id,
            //    Gender = user.Gender,
            //    IsActive = user.IsConfirmed(),
            //    AccountIsDeleted = user.IsDeleted,
            //};
            return default;
        }

        public async Task<User> GetProfile(string username)
        {
            //var user = await _userManager.FindByNameAsync(username);

            //return user is null ? null : new User
            //{
            //    Email = user.Email,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    Gender = user.Gender.ToString(),
            //    NextOfKin = user.NextOfKinName,
            //    NextOfKinPhone = user.NextOfKinPhone,
            //    PhoneNumber = user.PhoneNumber,
            //    ReferralCode = user.ReferralCode,
            //    Address = user.Address,
            //    MiddleName = user.MiddleName,
            //    DateJoined = user.CreationTime.ToString(CoreConstants.DateFormat),
            //    DateOfBirth = user.DateOfBirth,
            //    Referrer = user.Referrer,
            //    userType = user.UserType
            //};
            return default;
        }

        public async Task<bool> ForgotPassword(string usernameOrEmail)
        {
            //if (string.IsNullOrEmpty(usernameOrEmail)) {
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);
            //}

            //var user = await FindByNameAsync(usernameOrEmail) ?? await FindByEmailAsync(usernameOrEmail);

            //if (user == null)
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);

            //if (user.IsDeleted)
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);

            //if (user.IsDeleted)
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_LOCKED);

            //user.OTP = CommonHelper.RandomDigits(5);
            //await _userManager.UpdateAsync(user);

            ////send sms for otp
            //try
            //{
            //    string message = $"Password Reset OTP: {user.OTP}.";
            //    _smsSvc.SendSMSNow(message, recipient: user.PhoneNumber);
            //}
            //catch (Exception)
            //{

            //}
            //var replacement = new StringDictionary
            //{
            //    ["FirstName"] = user.FirstName,
            //    ["Otp"] = user.OTP
            //};
            //var mail = new Mail(appConfig.AppEmail, "Libmot.com: Password Reset OTP", user.Email)
            //{
            //    BodyIsFile = true,
            //    BodyPath = Path.Combine(_hostingEnvironment.ContentRootPath, CoreConstants.Url.PasswordResetEmail)
            //};

            //await _mailSvc.SendMailAsync(mail, replacement);

            return await Task.FromResult(true);
        }

        public async Task<bool> ResetPassword(User model)
        {
            //if (string.IsNullOrEmpty(model.UserNameOrEmail)) {
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);
            //}

            //var user = await FindByNameAsync(model.UserNameOrEmail) ?? await FindByEmailAsync(model.UserNameOrEmail);

            //await ValidateUser(user);

            //if (user.OTP != model.Code) {
            //    throw new LMEGenericException("Invalid OTP");
            //   // throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_WRONG_OTP);
            //}

            //var changeToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            //var result = await _userManager.ResetPasswordAsync(user, changeToken, model.NewPassword);

            //if (!result.Succeeded) {
            //    throw await _svcHelper.GetExceptionAsync(result.Errors?.FirstOrDefault().Description);
            //}

            //user.OTP = null;
            //await _userManager.UpdateAsync(user);

            return true;
        }

        public async Task<bool> ChangePassword(string usernameOrEmail, User model)
        {
            //if (string.IsNullOrEmpty(usernameOrEmail)) {
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);
            //}

            //var user = await FindByNameAsync(usernameOrEmail) ?? await FindByEmailAsync(usernameOrEmail);

            //await ValidateUser(user);

            //var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            //if (!result.Succeeded) {
            //    throw await _svcHelper.GetExceptionAsync(result.Errors?.FirstOrDefault().Description);
            //}

            return true;
        }

        public Task<bool> IsInRoleAsync(User user, string role)
        {
            if (string.IsNullOrWhiteSpace(role) || user is null)
                throw new ArgumentNullException();

         return   _userManager.IsInRoleAsync(user, role);
        }

        public Task<IdentityResult> RemoveFromRolesAsync(User user, IEnumerable<string> roles)
        {
            if (roles == null || user is null)
                throw new ArgumentNullException();

            return _userManager.RemoveFromRolesAsync(user, roles);
        }

        private async Task ValidateUser(User user)
        {
            //if (user == null)
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);

            //if (user.IsDeleted)
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);

            //if (user.AccountLocked())
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_LOCKED);
        }

        public async Task<bool> UpdateProfile(string usernameOrEmail, User model)
        {
            //if (string.IsNullOrEmpty(usernameOrEmail)) {
            //    throw await _svcHelper.GetExceptionAsync(ErrorConstants.USER_ACCOUNT_NOT_EXIST);
            //}

            //var user = await FindByNameAsync(usernameOrEmail) ?? await FindByEmailAsync(usernameOrEmail);

            //await ValidateUser(user);

            //if (!string.IsNullOrWhiteSpace(model.FirstName) && !string.Equals(user.FirstName, model.FirstName)) {
            //    user.FirstName = model.FirstName;
            //}

            //if (!string.IsNullOrWhiteSpace(model.LastName) && !string.Equals(user.LastName, model.LastName)) {
            //    user.LastName = model.LastName;
            //}

            //if (!string.IsNullOrWhiteSpace(model.PhoneNumber) && !string.Equals(user.PhoneNumber, model.PhoneNumber)) {
            //    user.PhoneNumber = model.PhoneNumber;
            //}

            //if (!string.IsNullOrWhiteSpace(model.MiddleName) && !string.Equals(user.MiddleName, model.MiddleName)) {
            //    user.MiddleName = model.MiddleName;
            //}

            //if (!string.IsNullOrWhiteSpace(model.Address) && !string.Equals(user.Address, model.Address)) {
            //    user.Address = model.Address;
            //}

            //if (!string.IsNullOrWhiteSpace(model.NextOfKin) && !string.Equals(user.NextOfKinName, model.NextOfKin)) {
            //    user.NextOfKinName = model.NextOfKin;
            //}

            //if (!string.IsNullOrWhiteSpace(model.DateOfBirth) && !string.Equals(user.DateOfBirth, model.DateOfBirth)) {
            //    user.DateOfBirth = model.DateOfBirth;
            //}

            //if (!string.IsNullOrWhiteSpace(model.NextOfKinPhone) && !string.Equals(user.NextOfKinPhone, model.NextOfKinPhone)) {
            //    user.NextOfKinPhone = model.NextOfKinPhone;
            //}

            //if (!string.IsNullOrWhiteSpace(model.Title) && !string.Equals(user.Title, model.Title)) {
            //    user.Title = model.Title;
            //}

            //if (!string.IsNullOrWhiteSpace(model.Email) && !string.Equals(user.Email, model.Email) && model.Email.IsValidEmail()) {
            //    user.NextOfKinName = model.Email;
            //}

            //var result = await _userManager.UpdateAsync(user);

            //return result.Succeeded;
            return true;
        }
    }
}
