using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Material_Sharing.DAL.Entities;
using Material_Sharing.Models;
using Material_Sharing.ViewModel.UserService;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.ViewModel.EmailService;

namespace Material_Sharing.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailSenderService _emailSenderService;

        public AccountController(
            IUserService userService,
            UserManager<ApplicationUser> userManager,
            IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
            _userService = userService;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            ViewData["ErrorMessage"] = ErrorMessage;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _userService.SignInByEmailAsync(model, Url,
                     nameof(AccountController.ConfirmEmail), "Account", Request.Scheme);
                if (result.IsAuthorized)
                    return RedirectToLocal(returnUrl);
                else
                    ModelState.AddModelError(string.Empty, result.Result);
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(model, Url,
                     nameof(AccountController.ConfirmEmail), "Account", Request.Scheme);
                if (result.Succeeded)
                    return RedirectToLocal(returnUrl);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction(nameof(LectureNoteController.Index),"LectureNote");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _userService.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            SignInExternalResultModel result = await _userService.SignInByExternalLoginAsync( Url,
                     nameof(AccountController.ConfirmEmail), "Account", Request.Scheme);
            if (result.IsAuthorized)
                return RedirectToLocal(returnUrl);
            else if (!result.IsConfirmedEmail)
            {
                ErrorMessage = result.Result;
                return RedirectToAction(nameof(ConfirmEmailError));
            }
            else if (result.IsNewUser)
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = result.LoginProvider;
                return View("ExternalLogin", result.RegisterModel);
            }
            else
                return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(RegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                RegistryIdentityResult result = await _userService.CreateUserExternalLoginAsync(model, Url,
                     nameof(AccountController.ConfirmEmail), "Account", Request.Scheme);
                if (result.IsRegistred)
                    return RedirectToLocal(returnUrl);
                foreach (string error in result.ResultString)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(LectureNoteController.Index),"LectureNote");
            }
            ConfirmEmailResultModel result = await _userService.ConfirmEmailAsync(userId, code);
            return View(result.IsSuccessed ? "ConfirmEmail" : result.ConfirmResults.First());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                ForgotPasswordResultModel result = await _userService.ForgotPasswordAsync(model, Url
                    , nameof(AccountController.ResetPassword), "Account", Request.Scheme);
                if (result.IsSuccesed)
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                else if (result.HasUser)
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                else
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                throw new ApplicationException("A code must be supplied for password reset.");
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ResetPasswordResultModel result = await _userService.ResetPasswordAsync(model);
            if (result.IsSucceded)
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            else
                foreach (string error in result.ResetResults)
                    ModelState.AddModelError(string.Empty, error);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmailError()
        {
            return View();
        }

        #region Helpers
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(LectureNoteController.Index),"LectureNote");
            }
        }

        #endregion
    }
}
