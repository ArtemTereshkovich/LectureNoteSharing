using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.EmailService;
using Material_Sharing.ViewModel.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IMapper _mapper;
        public UserService(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSenderService emailSenderService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSenderService = emailSenderService;
        }
        public AuthenticationProperties ConfigureExternalAuthenticationProperties(
            string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        public async Task<IdentityResult> CreateUserAsync(
            RegisterViewModel registerViewModel,
            IUrlHelper urlHelper,
            string callAction,
            string controller,
            string scheme)
        {
            ApplicationUser newuser = _mapper.Map<RegisterViewModel, ApplicationUser>(registerViewModel);
            IdentityResult result = await _userManager.CreateAsync(newuser, password: registerViewModel.Password);
            if (result.Succeeded)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(newuser.Email);
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callBackUrl = GenerateCallbackLink(urlHelper, callAction, controller, user.Id, code, scheme);
                await _emailSenderService.SendEmailConfirmationAsync(new EmailConfirmationModel { Email = user.Email, Link = callBackUrl });
                return result;
            }
            return result;
        }

        public Task Logout()
        {
            return _signInManager.SignOutAsync();
        }

        private async Task<ApplicationUserViewModel> getUserByUsernameAsync(string username)
        {
            return _mapper.Map<ApplicationUser,ApplicationUserViewModel>(await _userManager.FindByNameAsync(username));
        }

        private async Task<ApplicationUserViewModel> getUserByEmailAsync(string email)
        {
            return _mapper.Map<ApplicationUser,ApplicationUserViewModel>(await _userManager.FindByEmailAsync(email));
        }

        private async Task<ApplicationUserViewModel> getUserByIdAsync(string id)
        {
            return _mapper.Map<ApplicationUser,ApplicationUserViewModel>(await _userManager.FindByIdAsync(id));
        }

        public async Task<SignInResultModel> SignInByEmailAsync(LoginViewModel loginViewModel,IUrlHelper urlHelper,string callAction, string controller,string scheme)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(loginViewModel.Login);
            if (user == null)
                user = await _userManager.FindByNameAsync(loginViewModel.Login);
            if (user == null)
                return new SignInResultModel
                {
                    IsAuthorized = false,
                    Result = "No user with this Username of Email",
                    User = null
                };
            if (!await _userManager.IsEmailConfirmedAsync(user)){
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callBackUrl = GenerateCallbackLink(urlHelper, callAction, controller, user.Id, code, scheme);
                await _emailSenderService.SendEmailConfirmationAsync(new EmailConfirmationModel { Email = user.Email, Link = callBackUrl });  
                return new SignInResultModel
                {
                    IsAuthorized = false,
                    Result = "You must have a confirmed email to log in.",
                    User = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user)
                };
            }
            var result = await _signInManager.PasswordSignInAsync(
                user,
                loginViewModel.Password,
                loginViewModel.RememberMe,
                lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return new SignInResultModel
                {
                    IsAuthorized = true,
                    Result = "Success",
                    User = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user)
                };
            }
            else
            {
                return new SignInResultModel
                {
                    IsAuthorized = false,
                    Result = result.ToString(),
                    User = null
                };
            }
        }

        public async Task<ApplicationUserViewModel> GetUserByUsernameAsync(string username)
        {
            return _mapper.Map<ApplicationUser, ApplicationUserViewModel>(await _userManager.FindByNameAsync(username));
        }

        public async Task<ApplicationUserViewModel> GetUserByEmailAsync(string email)
        {
            return _mapper.Map<ApplicationUser, ApplicationUserViewModel>(await _userManager.FindByEmailAsync(email));
        }

        public async Task<ApplicationUserViewModel> GetUserByIdAsync(string id)
        {
            return _mapper.Map<ApplicationUser, ApplicationUserViewModel>(await _userManager.FindByIdAsync(id));
        }

        public async Task<RegistryIdentityResult> CreateUserExternalLoginAsync(RegisterViewModel registerViewModel, IUrlHelper urlHelper, string callAction, string controller, string scheme)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                var list = new List<string>();
                list.Add("Error with External provider service");
                return new RegistryIdentityResult
                {
                    IsRegistred = false,
                    ResultString = list,
                    User = null
                };
            }
            var result = await CreateUserAsync(registerViewModel, urlHelper,
                    callAction, controller, scheme);
            if (result.Succeeded)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(registerViewModel.Username);
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    return new RegistryIdentityResult
                    {
                        IsRegistred = true,
                        ResultString = new List<string>(),
                        User = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user)
                    };
                }
                else
                {
                    var list = new List<string>();
                    foreach (var error in result.Errors)
                    {
                        list.Add(error.Description);
                    }
                    return new RegistryIdentityResult
                    {
                        IsRegistred = false,
                        ResultString = list,
                        User = null
                    };
                }
            }
            else
            {
                var list = new List<string>();
                foreach (var error in result.Errors)
                {
                    list.Add(error.Description);
                }
                return new RegistryIdentityResult
                {
                    IsRegistred = false,
                    ResultString = list,
                    User = null
                };
            }
        }

        public async Task<SignInExternalResultModel> SignInByExternalLoginAsync(IUrlHelper urlHelper,string callAction, string controller,string scheme)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return new SignInExternalResultModel
                {
                    IsAuthorized = false,
                    IsNewUser = false,
                    RegisterModel = null,
                    Result = "Error External Provider."
                };
            }
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user != null && !await _userManager.IsEmailConfirmedAsync(user))
            {                
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callBackUrl = GenerateCallbackLink(urlHelper, callAction, controller, user.Id, code, scheme);
                await _emailSenderService.SendEmailConfirmationAsync(new EmailConfirmationModel { Email = user.Email, Link = callBackUrl });                
                return new SignInExternalResultModel
                {
                    IsAuthorized = false,
                    IsConfirmedEmail = false,
                    IsNewUser = false,
                    RegisterModel = null,
                    Result = $"You haven't confirmed Email {user.Email}."
                };
            }
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
             isPersistent: false, bypassTwoFactor: true);
            var registerViewModel = new RegisterViewModel
            {
                Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                Username = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? info.Principal.FindFirstValue(ClaimTypes.Name),
                Name = info.Principal.FindFirstValue(ClaimTypes.Name),
                Surname = info.Principal.FindFirstValue(ClaimTypes.Surname)
            };
            if (result.Succeeded)
            {
                return new SignInExternalResultModel
                {
                    IsConfirmedEmail = true,
                    LoginProvider = info.LoginProvider,
                    IsAuthorized = true,
                    IsNewUser = false,
                    Result = "Success.",
                    RegisterModel = registerViewModel
                };
            }
            else if (!result.IsLockedOut)
            {
                return
                 new SignInExternalResultModel
                 {
                     IsConfirmedEmail = true,
                     LoginProvider = info.LoginProvider,
                     IsAuthorized = false,
                     IsNewUser = true,
                     Result = "Some error with you account.",
                     RegisterModel = registerViewModel
                 };
            }
            return new SignInExternalResultModel
            {
                IsConfirmedEmail = false,
                LoginProvider = info.LoginProvider,
                IsAuthorized = false,
                IsNewUser = false,
                Result = "Locked Out Account",
                RegisterModel = registerViewModel
            };
        }

        public async Task<ConfirmEmailResultModel> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                var list = new List<string>();
                list.Add($"Unable to load user with ID '{userId}'.");
                return new ConfirmEmailResultModel
                {
                    HasUser = false,
                    IsSuccessed = false,
                    ConfirmResults = list
                };
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                var list = new List<string>();
                list.Add("Success");
                return new ConfirmEmailResultModel
                {
                    HasUser = true,
                    IsSuccessed = true,
                    ConfirmResults = list
                };
            }
            else
            {
                var list = new List<string>();
                foreach (var error in result.Errors)
                    list.Add(error.Description);
                return new ConfirmEmailResultModel
                {
                    HasUser = true,
                    IsSuccessed = false,
                    ConfirmResults = list
                };
            }
        }

        public async Task<ResetPasswordResultModel> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                var list = new List<string>();
                list.Add($"Unable to load user with Email '{model.Email}'.");
                return new ResetPasswordResultModel
                {
                    IsSucceded = false,
                    HasUser = false,
                    ResetResults = list
                };
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                var list = new List<string>();
                list.Add("Succeded");
                return new ResetPasswordResultModel
                {
                    IsSucceded = true,
                    HasUser = true,
                    ResetResults = list
                };
            }
            else
            {
                var list = new List<string>();
                foreach (var error in result.Errors)
                    list.Add(error.Description);
                return new ResetPasswordResultModel
                {
                    IsSucceded = false,
                    HasUser = true,
                    ResetResults = list
                };
            }
        }

        public async Task<ForgotPasswordResultModel> ForgotPasswordAsync(ForgotPasswordViewModel model, IUrlHelper url, string callAction, string controller, string scheme)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return new ForgotPasswordResultModel
                {
                    IsSuccesed = false,
                    HasUser = false,
                    ForgotResult = "Error to access current user."
                };
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = GenerateCallbackLink(url, callAction, controller, user.Id, code, scheme);
            await _emailSenderService.SendEmailResetPasswordAsync(new EmailResetPasswordModel { Email = model.Email, Link = callbackUrl });
            return new ForgotPasswordResultModel
            {
                IsSuccesed = true,
                HasUser = true,
                ForgotResult = "Success"
            };
        }

        private string GenerateCallbackLink(
            IUrlHelper urlHelper,
            string callAction,
            string controller,
            string userId,
            string code,
            string scheme)
        {
            return urlHelper.Action(
                action: callAction,
                controller: controller,
                values: new { userId, code },
                protocol: scheme);
        }

    }
}