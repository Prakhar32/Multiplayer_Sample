using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;
using System.Collections;

internal class AssetBundleLoader
{
    private AssetBundle _assetBundle;

    internal AssetBundleLoader(MonoBehaviour mono)
    {
        if (mono == null)
            throw new System.NullReferenceException();
    }

    public IEnumerator LoadBundle()
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(
            BootstrapSceneConstants.AssetbundlePath, new Hash128());
        yield return processRequest(request);
        _assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        request.Dispose();
    }

    private IEnumerator processRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
            throw new HttpRequestException(request.error);
    }

    public AssetBundle GetLoadedBundle()
    {
        return _assetBundle;
    }
}
