using MPayzWalletAPI.Model.User;

namespace MPayzWalletAPI.DAL.Interface.UserInterface
{
    public interface IUser
    {
        public CreateNewAccount CreateAccount();
        public string GetPassPhase(string mnemonic);
    }
}

