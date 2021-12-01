using Kryxivia.Shared.Utilities;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Kryxivia.Shared.Settings
{
    public class Web3NetworkSettings
    {
        public string PrivateKey { get; set; }
        public string NodeUrl { get; set; }

        public string NftContractAddr { get; set; }
        public long NftContractStartBlock { get; set; }
    }

    public class Web3Settings
    {
        public Web3NetworkSettings Testnet { get; set; }
        public Web3NetworkSettings Mainnet { get; set; }

        public Account TestnetAccount => new Account(Testnet?.PrivateKey, new BigInteger(97));
        public Account MainnetAccount => new Account(Mainnet?.PrivateKey, new BigInteger(56));

        public Web3 TestnetWeb3(bool withSigner = false)
        {
            Web3 web3;

            if (!withSigner) web3 = new Web3(Testnet?.NodeUrl);
            else web3 = new Web3(TestnetAccount, Testnet?.NodeUrl);

            if (!EnvironmentUtils.IsEip1559TxnSupported()) web3.TransactionManager.UseLegacyAsDefault = true;

            return web3;
        }

        public Web3 MainnetWeb3(bool withSigner = false)
        {
            Web3 web3;

            if (!withSigner) web3 = new Web3(Mainnet?.NodeUrl);
            else web3 = new Web3(MainnetAccount, Mainnet?.NodeUrl);

            if (!EnvironmentUtils.IsEip1559TxnSupported()) web3.TransactionManager.UseLegacyAsDefault = true;

            return web3;
        }
    }
}
