using API.DTO.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotifier notifier, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : base(notifier)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("criar")]
        public async Task<ActionResult> Registrar(RegisterUserDTO registerUserDTO)
        {   
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser 
            { 
                UserName = registerUserDTO.Email, 
                Email =  registerUserDTO.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(registerUserDTO);
            }

            foreach (var error in result.Errors)
            {
                NotifierError(error.Description);
            }

            return CustomResponse(registerUserDTO);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(loginUser);
            }

            if (result.IsLockedOut)
            {
                NotifierError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotifierError("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }
    }
}
}
