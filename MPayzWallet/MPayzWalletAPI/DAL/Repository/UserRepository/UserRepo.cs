using MPayzWalletAPI.DAL.Interface.UserInterface;
using Algorand;
using Algorand.V2;
using Algorand.Client;
using Account = Algorand.Account;
using Algorand.Algod.Api;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Pkcs;
using MPayzWalletAPI.Model.User;

namespace MPayzWalletAPI.DAL.Repository.UserRepository
{
    public class UserRepo : IUser
    {
        public CreateNewAccount CreateAccount()
        {

            string ALGOD_API_ADDR = "https://testnet-algorand.api.purestake.io/ps2"; //find in algod.net
            string ALGOD_API_TOKEN = "VfIjO0OLbD5COhQ2mgJIx40rJ1vXwpb4apvfdLpm"; //find in algod.token
            AlgodApi algodApiInstance = new AlgodApi(ALGOD_API_ADDR, ALGOD_API_TOKEN);

            Account myAccount = new Account();
            var myMnemonic = myAccount.ToMnemonic();
            CreateNewAccount createNewAccount = new CreateNewAccount()
            {
                Address = myAccount.Address.ToString(),
                Mnemonic = myMnemonic.ToString(),
            };
            return createNewAccount;
        }

        /// <summary>
        /// Converts the 32 byte private key to a 25 word mnemonic, including a checksum.
        /// Refer to the mnemonic package for additional documentation.
        /// </summary>
        /// <returns>return string a 25 word mnemonic</returns>
        public string GetPassPhase(string pass)
        {
            var privatekey = Mnemonic.ToKey(pass);
            Address address = new Address(privatekey);
            return address.ToString();

        }
    }
}
