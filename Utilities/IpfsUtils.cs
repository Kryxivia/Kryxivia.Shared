using Ipfs.CoreApi;
using Ipfs.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kryxivia.Shared.Utilities
{
    public static class IpfsUtils
    {
        public static IpfsEngine Ipfs = new IpfsEngine();

        public static string GetIpfsGatewayLink(string ipfsUri)
        {
            var ipfsUriSplit = ipfsUri.Split(new string[1] { "ipfs://" }, StringSplitOptions.None);
            if (ipfsUriSplit == null || ipfsUriSplit.Length < 2) return null;

            var ipfsHash = ipfsUriSplit[1];
            if (string.IsNullOrWhiteSpace(ipfsHash)) return null;

            return $"{Constants.IPFS_GATEWAY_PREFIX}/ipfs/{ipfsHash}";
        }

        public static string GetKryxiviaIpfsGatewayLink(string ipfsUri)
        {
            var ipfsUriSplit = ipfsUri.Split(new string[1] { "ipfs://" }, StringSplitOptions.None);
            if (ipfsUriSplit == null || ipfsUriSplit.Length < 2) return null;

            var ipfsHash = ipfsUriSplit[1];
            if (string.IsNullOrWhiteSpace(ipfsHash)) return null;

            return $"{Constants.KRYXIVIA_IPFS_GATEWAY_PREFIX}/ipfs/{ipfsHash}";
        }

        public static async Task<string> GetIpfsHash(string json)
        {
            var options = new AddFileOptions() { OnlyHash = true };
            var fsn = await Ipfs.FileSystem.AddTextAsync(json, options);

            return fsn?.Id;
        }
    }
}
