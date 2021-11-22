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
    public class Web3Settings
    {
        public int ChainId { get; set; }
        public string NodeUrl { get; set; }
        public string PrivateKey { get; set; }
        public string NftContractAddr { get; set; }

        public long NftContractDeployedBlock { get; set; }

        public Web3Settings() { }

        public Web3Settings(int chainId, string nodeUrl, string privateKey, string nftContractAddr)
        {
            ChainId = chainId;
            NodeUrl = nodeUrl;
            PrivateKey = privateKey;
            NftContractAddr = nftContractAddr;
        }


        public BigInteger ChainIdAsBigInt => new BigInteger(ChainId);
        public Account Account => new Account(PrivateKey, ChainIdAsBigInt);
        public Web3 Web3(bool withSigner = false)
        {
            Web3 web3;

            if (!withSigner) web3 = new Web3(NodeUrl);
            else web3 = new Web3(Account, NodeUrl);

            if (!EnvironmentUtils.IsEip1559TxnSupported()) web3.TransactionManager.UseLegacyAsDefault = true;

            return web3;
        }
    }
}
