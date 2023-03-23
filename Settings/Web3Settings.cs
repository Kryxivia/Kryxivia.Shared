using Kryxivia.Shared.Utilities;
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
        public string NodeUrl { get; set; }

        public string NftContractAddr { get; set; }
        public long NftContractStartBlock { get; set; }

        public string KxsContractAddr { get; set; }
        public long KxsContractStartBlock { get; set; }

        public string KxaContractAddr { get; set; }
        public long KxaContractStartBlock { get; set; }
    }

    public class Web3Settings
    {
        public Web3NetworkSettings Testnet { get; set; }
        public Web3NetworkSettings Mainnet { get; set; }

        public string TargetNetwork { get; set; }

        public Account TestnetAccount(string privateKey)
        {
            if (string.IsNullOrWhiteSpace(privateKey)) return null;
            return new Account(privateKey, new BigInteger(80001));
        }

        public Account MainnetAccount(string privateKey)
        {
            if (string.IsNullOrWhiteSpace(privateKey)) return null;
            return new Account(privateKey, new BigInteger(137));
        }

        public Web3 TestnetWeb3(string privateKey = null)
        {
            if (Testnet == null || string.IsNullOrEmpty(Testnet?.NftContractAddr)) return null;

            Web3 web3;
 
            if (privateKey == null) web3 = new Web3(Testnet?.NodeUrl);
            else web3 = new Web3(TestnetAccount(privateKey), Testnet?.NodeUrl);

            if (!EnvironmentUtils.IsEip1559TxnSupported()) web3.TransactionManager.UseLegacyAsDefault = true;

            return web3;
        }

        public Web3 MainnetWeb3(string privateKey = null)
        {
            if (Mainnet == null || string.IsNullOrEmpty(Mainnet?.NftContractAddr)) return null;

            Web3 web3;

            if (privateKey == null) web3 = new Web3(Mainnet?.NodeUrl);
            else web3 = new Web3(MainnetAccount(privateKey), Mainnet?.NodeUrl);

            if (!EnvironmentUtils.IsEip1559TxnSupported()) web3.TransactionManager.UseLegacyAsDefault = true;

            return web3;
        }

        public bool IsTargetTestnet => TargetNetwork == "Testnet";
        public bool IsTargetMainnet => TargetNetwork == "Mainnet";
    }
}
