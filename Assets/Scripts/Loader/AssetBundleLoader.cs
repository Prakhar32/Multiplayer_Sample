using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;

public class AssetBundleLoader
{
    private AssetBundle _assetBundle;

    public async Task LoadBundle()
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(Constants.AssetbundlePath);
        await processRequest(request);
        _assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        request.Dispose();
    }

    private async Task processRequest(UnityWebRequest request)
    {
        await request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
            throw new HttpRequestException(request.error);
    }

    public AssetBundle GetLoadedBundle()
    {
        return _assetBundle;
    }
}
