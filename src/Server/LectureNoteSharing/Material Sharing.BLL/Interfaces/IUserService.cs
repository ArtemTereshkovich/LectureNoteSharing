using System.Collections.Generic;
using System.Threading.Tasks;
using Material_Sharing.DAL.Entities;
using Material_Sharing.ViewModel.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Material_Sharing.BLL.Interfaces{
    public interface IUserService 
    {    
        Task<SignInResultModel> SignInByEmailAsync(LoginViewModel loginViewModel,IUrlHelper urlHelper,string callAction, string controller,string scheme);
        Task<SignInExternalResultModel> SignInByExternalLoginAsync(IUrlHelper urlHelper,string callAction, string controller,string scheme);
        Task<RegistryIdentityResult> CreateUserExternalLoginAsync(RegisterViewModel registerViewModel,IUrlHelper urlHelper,string callAction,string controller,string scheme);
        Task<IdentityResult> CreateUserAsync(RegisterViewModel registerViewModel,IUrlHelper urlHelper,string callAction,string controller,string scheme);
        Task Logout();
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider,string redirectUrl);
        Task<ApplicationUserViewModel> GetUserByUsernameAsync(string username);
        Task<ApplicationUserViewModel> GetUserByEmailAsync(string email);
        Task<ApplicationUserViewModel> GetUserByIdAsync(string id);
        Task<ConfirmEmailResultModel> ConfirmEmailAsync(string userId,string code);
        Task<ResetPasswordResultModel> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<ForgotPasswordResultModel> ForgotPasswordAsync(ForgotPasswordViewModel model,IUrlHelper url,string callAction,string controller, string scheme);
    }
}