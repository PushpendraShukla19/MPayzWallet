using Microsoft.AspNetCore.Mvc;
using MPayzWalletAPI.DAL.Interface.UserInterface;
using MPayzWalletAPI.DAL.Repository.UserRepository;
using MPayzWalletAPI.Model.User;

namespace MPayzWalletAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUser _user;
        public AccountController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public CreateNewAccount GetPassPhaseWords()
        {
            CreateNewAccount passPhase = _user.CreateAccount();
            return passPhase;
        }

        [HttpGet]
        [Route("GetAddress/{pass}")]
        public string GetAddress(string pass)
        {
            var passPhase = _user.GetPassPhase(pass);
            return passPhase;
        }
    }
}
